using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IPS
{
	public partial class SettingsForm : Form
	{

        bool overrideServer = true;

        public SettingsForm()
		{
			InitializeComponent();
            LoadAsync();
		}

        async void LoadAsync()
        {
            await LoadServerList();
            ValidateSQL();
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
                textBoxDHLLogin.Text = Settings.Default.dhl_login?.Trim();
                textBoxDHLPassword.Text = Settings.Default.dhl_password?.DecryptString();

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

        bool RequiredDataProvided()
        {
            String[] requiredFields = new String[] { comboBoxDbSrv.Text, textBoxDbUsr.Text, comboBoxDb.Text };
            String[] optionalData1 = new String[] { textBoxENadawcaEmail1.Text, textBoxENadawcaPass1.Text };
            String[] optionalData2 = new String[] { textBoxDHLLogin.Text, textBoxDHLPassword.Text };
            List<string[]> optionalFields = new List<string[]> { optionalData1, optionalData2 };

            return Program.dataProvided(requiredFields, optionalFields);
        }
		
		async Task<bool> SaveSettings()
		{
			try {
			
				Settings.Default.sql_server = comboBoxDbSrv.Text?.Trim();
				Settings.Default.sql_username = textBoxDbUsr.Text?.Trim();
				Settings.Default.sql_password = textBoxDbPass.Text?.Trim()?.EncryptString();
				Settings.Default.sql_database = comboBoxDb.Text?.Trim();
				Settings.Default.setAsSent = checkBoxSetAsSent.Checked;
                Settings.Default.enadawca_user1 = textBoxENadawcaEmail1.Text?.Trim();
                Settings.Default.enadawca_password1 = textBoxENadawcaPass1.Text?.Trim()?.EncryptString();
                Settings.Default.enadawca_user2 = textBoxENadawcaEmail2?.Text?.Trim();
                Settings.Default.enadawca_password2 = textBoxENadawcaPass2.Text?.Trim()?.EncryptString();
                Settings.Default.dhl_login = textBoxDHLLogin.Text?.Trim();
                Settings.Default.dhl_password = textBoxDHLPassword.Text?.Trim()?.EncryptString();

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

            if (!RequiredDataProvided()) { 
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

        async Task LoginToDatabase(bool output = false)
        {
            try
            {
                DataTable data = await SubiektRequest("SELECT name FROM master.sys.databases", true, !output);
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
                comboBoxDb.Text = "";
                comboBoxDb.Items.Clear();
                if (output) MessageBox.Show("Wystąpił błąd:\n" + e.Message);
            }
        }

        async Task<DataTable> SubiektRequest(string command, bool noDatabase = false, bool quiet = false)
        {
            String[] requiredData = (noDatabase) ?
                new String[] { comboBoxDbSrv.Text, textBoxDbUsr.Text }
                : new String[] { comboBoxDbSrv.Text, textBoxDbUsr.Text, comboBoxDb.Text };

            if (Program.dataProvided(requiredData))
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
                            if (!quiet) MessageBox.Show("Wystąpił błąd:\n" + sqle.Message);
                            return null;
                        }
                    }
                }
            }
            return null;
        }
		
		async void ValidateSQL()
		{
			if ((textBoxDbUsr.Text != "") && (comboBoxDbSrv.Text != Program.INFO_LOADING) && (comboBoxDbSrv.Text != Program.INFO_BRAK_SERWEROW)) {
                await LoginToDatabase();
            }
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
            {
                MessageBox.Show("W podanej bazie nie znaleziono odpowiednich danych.\nUpewnij się, że wybrano prawidłową bazę danych (Sello).");
                comboBoxDb.Text = "";
            }
		}

        async Task<bool> DatabaseCorrect()
        {
            if (Program.dataProvided(new String[] { comboBoxDbSrv.Text, textBoxDbUsr.Text, comboBoxDb.Text }))
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
            if (((ComboBox)sender).Text != "") ValidateSQL();
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            overrideServer = LoadSettings();
        }

        private void textBoxDbUsr_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "") ValidateSQL();
        }

        private void textBoxDbPass_Leave(object sender, EventArgs e)
        {
            ValidateSQL();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!RequiredDataProvided())
                Application.Exit();
        }

        private async void comboBoxDb_Leave(object sender, EventArgs e)
        {
            if ((comboBoxDb.Text != "") && (!await DatabaseCorrect()))
            {
                MessageBox.Show("W podanej bazie nie znaleziono odpowiednich danych.\nUpewnij się, że wybrano prawidłową bazę danych (Sello).");
                comboBoxDb.Text = "";
            }
        }

        private void textBoxDbPass_TextChanged(object sender, EventArgs e)
        {
            ValidateSQL();
        }

        private void textBoxDbUsr_TextChanged(object sender, EventArgs e)
        {
            ValidateSQL();
        }
    }
	
	
}
