using System;
using System.Net;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using IPS.en;

namespace IPS
{
	
	public partial class Ustawienia : Form
	{
		
		
		byte[] aditionalEntropy = { 9, 8, 7, 6, 5 };
		byte[] secret = { 0, 1, 2, 3, 4, 1, 2, 3, 4 };

		public Ustawienia()
		{

			InitializeComponent();

			bool czyNadpisacSerwer = wczytajUstawienia();
			
			PobierzListeSerwerow(czyNadpisacSerwer);
			
			if (string.IsNullOrEmpty(comboBox1.Text)) {
				comboBox1.Select();
			}
			
			if ((string.IsNullOrEmpty(comboBox2.Text)) || (comboBox2.Text == Program.INFO_WCZYTYWANIE)) {
				comboBox2.Select();
			}
			
			if (string.IsNullOrEmpty(textBox5.Text)) {
				textBox5.Select();
			}
			
			if (string.IsNullOrEmpty(textBox1.Text)) {
				textBox1.Select();
			}
			
		}
		
		void PobierzListeSerwerow(bool czyNadpisacSerwer)
		{
			if (czyNadpisacSerwer)
				comboBox2.Text = Program.INFO_WCZYTYWANIE;
			new Thread(() => {
				try {
					Thread.CurrentThread.IsBackground = true; 
							
					DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();
					
					if (table.Rows.Count > 0) {
						foreach (DataRow row in table.Rows) {
							Invoke(new Action(() => {
								comboBox2.Items.Add(row[0] + "\\" + row[1]);
							}));
						}
						
						if (czyNadpisacSerwer) {
							Invoke(new Action(() => {
								comboBox2.SelectedIndex = 0;
								walidujDaneSerwera();
							}));
						}
						
					} else {
						Invoke(new Action(() => {
							if (comboBox2.Text == Program.INFO_WCZYTYWANIE)
								comboBox2.Text = Program.INFO_BRAK_SERWEROW;
							walidujDaneSerwera();
						}));
					}
					
				} catch (Exception e) {
					MessageBox.Show("Wystąpił błąd podczas wczytywania listy serwerów:\n" + e.Message);
				}
			}).Start();
		}
		
		void Button1Click(object sender, EventArgs e)
		{

			if (zapiszUstawienia()) {
				if (Program.mainForm == null)
					Program.mainForm = new MainForm();
				Program.mainForm.Show();
				Hide();
			}

		}
		
		bool wczytajUstawienia()
		{
			bool NadpisujSerwer = true;
			
			try {
			
				if (!string.IsNullOrEmpty(Settings.Default.sql_server.Trim())) {
					comboBox2.Text = Settings.Default.sql_server.Trim();
					NadpisujSerwer = false;
				}
				
				if (!string.IsNullOrEmpty(Settings.Default.sql_username.Trim())) {
					textBox1.Text = Settings.Default.sql_username.Trim();
				}
				
				if (!string.IsNullOrEmpty(Settings.Default.sql_password)) {
					textBox5.Text = Settings.Default.sql_password.DecryptString();
				}
				
				if (!string.IsNullOrEmpty(Settings.Default.sql_database.Trim())) {
					comboBox1.Text = Settings.Default.sql_database.Trim();
				}
				if (!string.IsNullOrEmpty(Settings.Default.setAsSent.ToString())) {
					checkBox1.Checked = Settings.Default.setAsSent;
				}
				
				if (!string.IsNullOrEmpty(Settings.Default.enadawca_user.Trim())) {
					textBox3.Text = Settings.Default.enadawca_user.Trim();
				}
				
				if (!string.IsNullOrEmpty(Settings.Default.enadawca_password)) {
					textBox2.Text = Settings.Default.enadawca_password.DecryptString();
				}

			} catch (Exception e) {
				MessageBox.Show("Wystąpił błąd podczas wczytywania ustawień:\n" + e.Message + e.StackTrace);
			}
			
			return NadpisujSerwer;
		}
		
		
		
		bool zapiszUstawienia()
		{
			try {
			
				Settings.Default.sql_server = (comboBox2.Text == "") ? "" : comboBox2.Text.Trim();
				Settings.Default.sql_username = (textBox1.Text == "") ? "" : textBox1.Text.Trim();
				Settings.Default.sql_password = (textBox5.Text == "") ? "" : textBox5.Text.Trim().EncryptString();
				Settings.Default.sql_database = (comboBox1.Text == "") ? "" : comboBox1.Text.Trim();
				Settings.Default.setAsSent = checkBox1.Checked;
				Settings.Default.enadawca_user = (textBox3.Text == "") ? "" : textBox3.Text.Trim();
				Settings.Default.enadawca_password = (textBox2.Text == "") ? "" : textBox2.Text.Trim().EncryptString();

				Settings.Default.Save();

			} catch (Exception e) {
				MessageBox.Show("Wystąpił błąd podczas zapisywania ustawień:\n" + e.Message);
			}
			
			
			if (Program.czyUstawieniaPuste()) {
				MessageBox.Show("Pomyślnie zapisano ustawienia.\nAby uruchomić aplikację uzupełnij pozostałe pola.");
				return false;
			}
				
			if (!databaseCorrect()) {
				MessageBox.Show("W podanej bazie nie znaleziono odpowiednich danych.\nUpewnij się, że wybrano prawidłową bazę danych (Sello).");
				return false;
			}
			
			return true;
						
		}
		
		bool databaseCorrect()
		{
			
			if ((dataProvided()) && (comboBox1.Text != "")) {
				try {
					SqlConnection polaczenie = new SqlConnection(@"Data source=" + comboBox2.Text + ";database=" + comboBox1.Text + ";User id=" + textBox1.Text + ";Password=" + textBox5.Text + ";");
					SqlCommand sqlComand = polaczenie.CreateCommand();
					polaczenie.Open();
					sqlComand.CommandText = "SELECT COUNT(*) FROM pc__Package";
					Int32 count = (Int32)sqlComand.ExecuteScalar();
					polaczenie.Close();
					return (count > 0); 
				} catch {
					return false;
				}
			} else
				return false;
		}
		
		void zalogujDoBazy(bool quiet)
		{
			
			if (dataProvided()) {
				
				comboBox1.Items.Clear();
				comboBox1.Items.Add(Program.INFO_WCZYTYWANIE_BAZ);
				
				new Thread(() => {
				           	
					Thread.CurrentThread.IsBackground = true; 
					
					SqlConnection polaczenie = new SqlConnection();
					
					Invoke(new Action(() => {
						polaczenie = new SqlConnection(@"Data source=" + comboBox2.Text + "; User id=" + textBox1.Text + "; Password=" + textBox5.Text + ";");
					}));
					
					try {
					   
						polaczenie.Open();
						SqlCommand sqlComand = polaczenie.CreateCommand();
						sqlComand.CommandText = "SELECT name FROM master.sys.databases";
					   
						var adapter = new SqlDataAdapter(sqlComand);
						var dataset = new DataSet();
						adapter.Fill(dataset);
						DataTable dtDatabases = dataset.Tables[0];
						
						Invoke(new Action(() => {
							comboBox1.Items.Clear();
						}));
		        		
						foreach (DataRow dataRow in dtDatabases.Rows) {
							foreach (var item in dataRow.ItemArray) {
								comboBox1.Items.Add(item);
							}
						}
		        		
						polaczenie.Close();
						
					                
					} catch {
						Invoke(new Action(() => {
							comboBox1.Items.Clear();
							comboBox1.Items.Add(Program.INFO_NIE_ZNALEZIONO_BAZ);
						}));
					}
				
				}).Start();
			
			}
		}
		
		void ComboBox1DropDown(object sender, EventArgs e)
		{
			zalogujDoBazy(true);
		}
		
		bool dataProvided()
		{
			return ((comboBox2.Text != "") && (comboBox2.Text != Program.INFO_WCZYTYWANIE) && (comboBox2.Text != Program.INFO_BRAK_SERWEROW) && (textBox1.Text != ""));
		}
		
		void walidujDaneSerwera()
		{
			if ((textBox1.Text != "") && (comboBox2.Text != Program.INFO_WCZYTYWANIE) && (comboBox2.Text != Program.INFO_BRAK_SERWEROW)) {
				comboBox1.Enabled = true;
				comboBox1.Text = Program.INFO_LISTA_BAZ;
			} else {
				comboBox1.Enabled = false;
				comboBox1.Text = "";
			}
		}
		
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			walidujDaneSerwera();
		}
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			walidujDaneSerwera();
		}
		void ComboBox1Click(object sender, EventArgs e)
		{
			if (comboBox1.Items.Count > 0)
				comboBox1.DroppedDown = true;
		}
		void ComboBox2Click(object sender, EventArgs e)
		{
			if (comboBox2.Items.Count > 0)
				comboBox2.DroppedDown = true;
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				MessageBox.Show("Uwaga, ta funkcja nie tworzy automatycznych wiadomości e-mail do klientów, informujących o wysłaniu przesyłki.\n" +
				"Jeśli chcesz, by Sello wysyłało wiadomości, odznacz tą opcję i oznaczaj przesyłki jako wysłane ręcznie w Sello (ta aplikacja po prostu zapisze numery przesyłek w Sello).");
		}
		
		
		void Button2Click(object sender, EventArgs e)
		{
			
		}
		void UstawieniaFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			walidujDaneSerwera();
		}
		void ComboBox2TextChanged(object sender, EventArgs e)
		{
			walidujDaneSerwera();
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			
			if ((comboBox1.SelectedItem.ToString() == Program.INFO_WCZYTYWANIE_BAZ) || (comboBox1.SelectedItem.ToString() == Program.INFO_NIE_ZNALEZIONO_BAZ)) {
				comboBox1.SelectedItem = 0;
				comboBox1.Text = Program.INFO_LISTA_BAZ;
			}
		}
		


	}
	
	
}
