using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace IPS
{
	public partial class SettingsForm : Form
	{

        bool overrideServer = true;

        public SettingsForm()
		{

			InitializeComponent();

            LoadAsync();

            if (string.IsNullOrEmpty(comboBoxDb.Text)) {
				comboBoxDb.Select();
			}
			
			if ((string.IsNullOrEmpty(comboBoxDbSrv.Text)) || (comboBoxDbSrv.Text == Program.INFO_LOADING)) {
				comboBoxDbSrv.Select();
			}
			
			if (string.IsNullOrEmpty(textBoxDbPass.Text)) {
				textBoxDbPass.Select();
			}
			
			if (string.IsNullOrEmpty(textBoxDbUsr.Text)) {
				textBoxDbUsr.Select();
			}
			
		}

        async void LoadAsync()
        {
            await LoadServerList();
        }

        async Task LoadServerList()
        {
            if (overrideServer)
                comboBoxDbSrv.Text = Program.INFO_LOADING;

            try
            {

                var registryViewArray = new[] { RegistryView.Registry32, RegistryView.Registry64 };
                foreach (var registryView in registryViewArray)
                {
                    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                    using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server"))
                    {
                        var instances = (key == null) ? null : (string[])key.GetValue("InstalledInstances");
                        if (instances != null)
                        {
                            foreach (var element in instances)
                            {
                                if (element == "MSSQLSERVER")
                                {
                                    comboBoxDbSrv.Items.Add(System.Environment.MachineName);
                                }
                                else
                                {
                                    comboBoxDbSrv.Items.Add(System.Environment.MachineName + @"\" + element);
                                }
                            }
                        }
                    }
                }

                await Task.Run(() =>
                {
                    using (DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources())
                    {
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                Invoke(new Action(() =>
                                {
                                    if (!comboBoxDbSrv.Items.Contains(row[0] + "\\" + row[1]))
                                        comboBoxDbSrv.Items.Add(row[0] + "\\" + row[1]);
                                }));
                            }
                        }
                    }

                });

                if (comboBoxDbSrv.Items.Count > 0)
                {
                    if (overrideServer)
                    {
                        comboBoxDbSrv.SelectedIndex = 0;
                        ValidateSQL();
                    }
                }
                else
                    comboBoxDbSrv.Text = "Brak lokalnych serwerów";

            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania listy serwerów:\n" + e.Message);
            }
        }

        async void ButtonSaveSettings_Click(object sender, EventArgs e)
		{

            if (await SaveSettings())
            {
                if (Program.mainForm == null)
                    Program.mainForm = new MainForm();
                Program.mainForm.Show();
                Hide();
            }

        }
		
		bool LoadSettings()
		{
			bool overrideServer = true;
			
			try {
			
				if (!string.IsNullOrEmpty(Settings.Default.sql_server.Trim())) {
					comboBoxDbSrv.Text = Settings.Default.sql_server?.Trim();
                    overrideServer = false;
				}
				
				textBoxDbUsr.Text = Settings.Default.sql_username?.Trim();
				textBoxDbPass.Text = Settings.Default.sql_password?.DecryptString();
				comboBoxDb.Text = Settings.Default.sql_database?.Trim();
				checkBoxSetAsSent.Checked = Settings.Default.setAsSent;
				textBoxENadawcaEmail1.Text = Settings.Default.enadawca_user1?.Trim();
				textBoxENadawcaPass1.Text = Settings.Default.enadawca_password1?.DecryptString();
                textBoxENadawcaEmail2.Text = Settings.Default.enadawca_user2?.Trim();
                textBoxENadawcaPass2.Text = Settings.Default.enadawca_password2?.DecryptString();

                if (Settings.Default.enadawca_mode > 0) {
					switch (Settings.Default.enadawca_mode) {
						case 1:
							radioButtonModeIntegrated.Checked = true;
							break;
						case 2:
							radioButtonModeXML.Checked = true;
							break;
					}
				}

			} catch (Exception e) {
				MessageBox.Show("Wystąpił błąd podczas wczytywania ustawień:\n" + e.Message + e.StackTrace);
			}
			
			return overrideServer;
		}
		
		async Task<bool> SaveSettings()
		{
			try {
			
				Settings.Default.sql_server = (comboBoxDbSrv.Text == "") ? "" : comboBoxDbSrv.Text.Trim();
				Settings.Default.sql_username = (textBoxDbUsr.Text == "") ? "" : textBoxDbUsr.Text.Trim();
				Settings.Default.sql_password = (textBoxDbPass.Text == "") ? "" : textBoxDbPass.Text.Trim().EncryptString();
				Settings.Default.sql_database = (comboBoxDb.Text == "") ? "" : comboBoxDb.Text.Trim();
				Settings.Default.setAsSent = checkBoxSetAsSent.Checked;
                Settings.Default.enadawca_user1 = (textBoxENadawcaEmail1.Text == "") ? "" : textBoxENadawcaEmail1.Text.Trim();
                Settings.Default.enadawca_password1 = (textBoxENadawcaPass1.Text == "") ? "" : textBoxENadawcaPass1.Text.Trim().EncryptString();
                Settings.Default.enadawca_user2 = (textBoxENadawcaEmail2.Text == "") ? "" : textBoxENadawcaEmail2.Text.Trim();
                Settings.Default.enadawca_password2 = (textBoxENadawcaPass2.Text == "") ? "" : textBoxENadawcaPass2.Text.Trim().EncryptString();

                if (radioButtonModeIntegrated.Checked) {
					Settings.Default.enadawca_mode = 1;
				}
				else if (radioButtonModeXML.Checked) {
					Settings.Default.enadawca_mode = 2;
				}

				Settings.Default.Save();

			} catch (Exception e) {
				MessageBox.Show("Wystąpił błąd podczas zapisywania ustawień:\n" + e.Message);
			}

            if (!Program.dataProvided(new String[] { comboBoxDbSrv.Text, textBoxDbUsr.Text, textBoxDbPass.Text, comboBoxDb.Text })) { 
                MessageBox.Show("Pomyślnie zapisano ustawienia.\nAby uruchomić aplikację uzupełnij pozostałe pola.");
                return false;
            }
				
			if (!await DatabaseCorrect()) {
				MessageBox.Show("W podanej bazie nie znaleziono odpowiednich danych.\nUpewnij się, że wybrano prawidłową bazę danych (Sello).");
				Settings.Default.sql_database = "";
				Settings.Default.Save();
				return false;
			}
			
			return true;
						
		}

        async Task LoginToDatabase()
        {
            try
            {
                DataTable data = await SubiektRequest("SELECT name FROM master.sys.databases", true);
                comboBoxDb.Items.Clear();

                if (data != null)
                {
                    foreach (DataRow dataRow in data.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            comboBoxDb.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił błąd:\n" + e.Message);
                comboBoxDb.Text = "";
                comboBoxDb.Items.Clear();
            }
        }

        async Task<DataTable> SubiektRequest(string command, bool noDatabase = false)
        {
            String[] data = (noDatabase) ?
                new String[] { comboBoxDbSrv.Text, textBoxDbUsr.Text, textBoxDbPass.Text }
                : new String[] { comboBoxDbSrv.Text, textBoxDbUsr.Text, textBoxDbPass.Text, comboBoxDb.Text };

            if (Program.dataProvided(data))
            {
                string connectionString;

                connectionString = (noDatabase) ?
                    @"Data source=" + comboBoxDbSrv.Text + "; User id=" + textBoxDbUsr.Text + "; Password=" + textBoxDbPass.Text + ";"
                    : @"Data source=" + comboBoxDbSrv.Text + "; Database=" + comboBoxDb.Text + "; User id=" + textBoxDbUsr.Text + "; Password=" + textBoxDbPass.Text + ";";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlComand = connection.CreateCommand())
                    {
                        try
                        {
                            await connection.OpenAsync();
                            sqlComand.CommandText = command;
                            var adapter = new System.Data.SqlClient.SqlDataAdapter(sqlComand);
                            var dataset = new DataSet();
                            await Task.Run(() => adapter.Fill(dataset));
                            DataTable dt_result = dataset.Tables[0];
                            return dt_result;
                        }
                        catch (SqlException sqle)
                        {
                            MessageBox.Show("Wystąpił błąd:\n" + sqle.Message);
                            return null;
                        }
                    }
                }
            }
            return null;
        }

		bool DataProvided()
		{
			return ((comboBoxDbSrv.Text != "") && (comboBoxDbSrv.Text != Program.INFO_LOADING) && (comboBoxDbSrv.Text != Program.INFO_BRAK_SERWEROW) && (textBoxDbUsr.Text != ""));
		}
		
		async void ValidateSQL()
		{
			if ((textBoxDbUsr.Text != "") && (comboBoxDbSrv.Text != Program.INFO_LOADING) && (comboBoxDbSrv.Text != Program.INFO_BRAK_SERWEROW)) {
				comboBoxDb.Enabled = true;
				comboBoxDb.Text = Program.INFO_DATABASE_LIST;
                await LoginToDatabase();
            } else {
				comboBoxDb.Enabled = false;
				comboBoxDb.Text = "";
			}
		}
		
		void TextBoxDbPass_TextChanged(object sender, EventArgs e)
		{
			ValidateSQL();
		}
		void TextBoxDbUsr_TextChanged(object sender, EventArgs e)
		{
			ValidateSQL();
		}

		void CheckBoxSetAsSent_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxSetAsSent.Checked)
				MessageBox.Show("Uwaga, ta funkcja nie tworzy automatycznych wiadomości e-mail do klientów, informujących o wysłaniu przesyłki.\n" +
				"Jeśli chcesz, by Sello wysyłało wiadomości, odznacz tą opcję i oznaczaj przesyłki jako wysłane ręcznie w Sello (ta aplikacja po prostu zapisze numery przesyłek w Sello).");
		}
		
		void ComboBoxDbSrv_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValidateSQL();
		}
	
		async void ComboBoxDb_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (!await DatabaseCorrect())
                MessageBox.Show("W podanej bazie nie znaleziono odpowiednich danych.\nUpewnij się, że wybrano prawidłową bazę danych (Sello).");
		}

        async Task<bool> DatabaseCorrect()
        {
            if (Program.dataProvided(new String[] { comboBoxDbSrv.Text, textBoxDbUsr.Text, textBoxDbPass.Text, comboBoxDb.Text }))
            {

                using (SqlConnection connection = new SqlConnection(@"Data source=" + comboBoxDbSrv .Text + ";database=" + comboBoxDb.Text + ";User id=" + textBoxDbUsr.Text + ";Password=" + textBoxDbPass.Text + ";"))
                {
                    using (SqlCommand sqlComand = connection.CreateCommand())
                    {
                        try
                        {
                            await connection.OpenAsync();
                            sqlComand.CommandText = "SELECT COUNT(*) FROM pc__Package";
                            Int32 count = (Int32)sqlComand.ExecuteScalar();
                            return (count > 0);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }
            else
                return false;
        }

        private void ComboBoxDbSrv_Leave(object sender, EventArgs e)
        {
            ValidateSQL();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            overrideServer = LoadSettings();
        }
    }
	
	
}
