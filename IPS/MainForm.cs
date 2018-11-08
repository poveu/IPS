using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using IPS.en;

namespace IPS
{
	public partial class MainForm : Form
	{
		const string NODE_PATH = "/Nadawca/Zbior/Przesylka";
		const string NODE_NAME = "Atrybut";
		const string NODE_SELECTOR = "Nazwa";
		const string NAZWA_NODE = "Nazwa";
		const string ULICA_NODE = "Ulica";
		const string DOM_NODE = "Dom";
		const string LOKAL_NODE = "Lokal";
		const string MIASTO_NODE = "Miejscowosc";
		const string NR_PRZESYLKI_NODE = "NrNadania";
		const string GUID_NODE = "MSIDPrzesylka";
		const string NICK1_NODE = "Uwagi";
		const string NICK2_NODE = "Tytulem1";
		
		const int PACKAGE_SELECTOR_COL = 1;
		const int PACKAGE_NUMBER_COL = 4;
		
		SqlConnection connection;

		string server;
		string database;
		string uid;
		string upwd;

		bool setAsSent;

        string en_user1;
        string en_password1;
        string en_user2;
        string en_password2;
        int en_mode;
		
		public MainForm()
		{
			InitializeComponent();
            LoadSettings();
			
			dateTimePicker.MaxDate = DateTime.Today;
		}

		void ButtonOpenFile_Click(object sender, EventArgs e)
		{ 
			openFileDialog.Filter = "Plik XML|*.xml";  
			openFileDialog.Title = "Wskaż plik z danymi przesyłek";
   
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				ImportData(openFileDialog.FileName);
		}
		
		void LoadXml(XmlDocument XmlDoc)
		{
			
			XmlNodeList xnList = XmlDoc.SelectNodes(NODE_PATH);

			Invoke(new Action(() => {
				progressBar.Value = 0;
				progressBar.Maximum = xnList.Count;
			}));
	                
			foreach (XmlNode node in xnList) {
				String[] arr = new String[6];
				ListViewItem itm;

				arr[0] = GetParsedNodeData(node, NAZWA_NODE);

				switch (en_mode) {
					case 1:
						arr[1] = (GetParsedNodeData(node, NICK2_NODE) == "" ?
						          GetParsedNodeData(node, NICK1_NODE, nickFormat: true) : GetParsedNodeData(node, NICK2_NODE, nickFormat: true));
						break;
					case 2:
						arr[1] = XmlDoc.SelectSingleNode(NODE_PATH).Attributes["Guid"].Value;
						break;
				}
				
				arr[2] = GetParsedNodeData(node, ULICA_NODE);
				arr[2] += GetParsedNodeData(node, DOM_NODE, " ");
				arr[2] += GetParsedNodeData(node, LOKAL_NODE, "/");
				arr[3] = GetParsedNodeData(node, MIASTO_NODE);
				arr[4] = GetParsedNodeData(node, NR_PRZESYLKI_NODE);
				arr[5] = "Przekonwertowano";
						
				if (arr[1] != "" && arr[4] != "") {
					itm = new ListViewItem(arr);
					Invoke(new Action(() => {
						listView.Items.Add(itm);
					}));
				}
				
				Invoke(new Action(() => {				
					progressBar.PerformStep();
				}));
			}
			
			Invoke(new Action(() => {
				listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			}));
		}
		
		void ImportData(string fileName)
		{
			var ext = System.IO.Path.GetExtension(fileName);
			if (ext.Equals(".xml", StringComparison.CurrentCultureIgnoreCase) ||
			    ext.Equals(".ips", StringComparison.CurrentCultureIgnoreCase)) {
			
				try {
					XmlDocument XmlDoc = new XmlDocument();
					
					string tresc = File.ReadAllText(fileName);
					tresc.Replace("UTF-16","UTF-8");

					XmlDocument xmlDoc = new XmlDocument();
					
					XmlDoc.LoadXml(tresc);
					listView.Items.Clear();

					LoadXml(XmlDoc);

				} catch (XmlException error) {
					MessageBox.Show("Nie udało się załadować pliku. Być może jest on uszkodzony." + "\n" + "Błąd: " + error.Message + "\n" + error.StackTrace);
					progressBar.Value = 0;
				}
                
			} else {
				MessageBox.Show("Aplikacja obsługuje tylko pliki .xml");
			}
		}
		
		string GetParsedNodeData(XmlNode node, string selectedNode, string limiter = "", bool nickFormat = false)
		{
			string value = node.SelectSingleNode(NODE_NAME + "[@" + NODE_SELECTOR + "='" + selectedNode + "']") == null ?
				"" : limiter + node.SelectSingleNode(NODE_NAME + "[@" + NODE_SELECTOR + "='" + selectedNode + "']").InnerText.TrimEnd(',', '.', '?', ' ');
			
			return (nickFormat) ? ConvertLogin(value) : value;

		}
		
		string ConvertLogin(string login)
		{
			
			if ((login != null) & (login != "")) {
			
				Regex regexNoReg = new Regex(@"NoReg:(\d+) \d+", RegexOptions.IgnoreCase);
				Match matchNoReg = regexNoReg.Match(login);
				if (matchNoReg.Success) {
					return matchNoReg.Groups[1].Value.TrimEnd(',', '.', '?', ' ') + "_niezarejestrowany";
				} else {
					Regex regexReg = new Regex(@"(Client:\d+|[a-zA-Z0-9_\-\.]+) \d+", RegexOptions.IgnoreCase);
					Match matchReg = regexReg.Match(login);
					if (matchReg.Success) {
						return matchReg.Groups[1].Value.TrimEnd(',', '.', '?', ' ');
					}
				}
			
			}
			
			return login;
		}
		
		void MainForm_ResizeEnd(object sender, EventArgs e)
		{
			listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		
		private void ListView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}
		
		private void ListView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (s.Length > 1)
				MessageBox.Show("Przekazano więcej niż jeden plik. Aplikacja wczyta tylko pierwszy z nich.");
			ImportData(s[0]);
		}
		
		void ButtonSendData_Click(object sender, EventArgs e)
		{
			try {
				
				connection = new SqlConnection(@"Data source=" + server + ";database=" + database + ";User id=" + uid + ";Password=" + upwd + ";");
				SqlCommand sqlComand = connection.CreateCommand();
				
				ListView list = listView;
				
				new Thread(() => {
					Invoke(new Action(() => {
						progressBar.Value = 0;
						progressBar.Maximum = list.Items.Count;
					}));
				           	
					for (int i = 0; i < list.Items.Count; i++) {
				        
           				string packageSelector;
						string packageSelectorValue = "";
						string packageNumber = "";
						
						switch (en_mode) {
							case 1:
								packageSelector = "cs_Nick";
								break;
							case 2:
								packageSelector = "pc_GUID";
								break;
							default:
								packageSelector = "cs_Nick";
								break;
						}
		
						Invoke(new Action(() => {
							progressBar.PerformStep();              	
							packageSelectorValue = list.Items[i].SubItems[PACKAGE_SELECTOR_COL].Text;
							packageNumber = list.Items[i].SubItems[PACKAGE_NUMBER_COL].Text;
						}
								                  
						));
				           		
						if ((packageSelectorValue != "") && (packageNumber != "")) {

							connection.Open();

							Invoke(new Action(() => {
							
								ListViewItem item = list.Items[i];
	
								list.Items[i].SubItems[5].Text = "Przesyłanie do Sello...";

								sqlComand.CommandText = @"
									UPDATE pc__Package
									SET
										pc_Document = '" + packageNumber + @"',
										" + ((setAsSent) ? @"pc_SendingDate = GETDATE()," : @"") + @"
										pc_StatusLink = pc_StatusLink + '" + packageNumber + @"'
									WHERE
										pc_Id = (
											SELECT TOP 1 pc_Id
											FROM pc__Package
											JOIN cs__Customer
												ON pc_CustomerId = cs_Id
											JOIN adr__Address
												ON pc_Id = adr_PackageId
											WHERE
												pc_SentStatus = 0
												AND
												" + packageSelector + " = '" + packageSelectorValue + @"'
										)
									";

								int res = sqlComand.ExecuteNonQuery();
									
								if (res > 0) {
									item.ForeColor = Color.DarkGreen;
	
									list.Items[i].SubItems[5].Text = "Przesłano do Sello";
									item.SubItems[5].Font = new Font(item.Font,
										item.Font.Style | FontStyle.Bold);
								} else {
									item.ForeColor = Color.DarkRed;
	
									list.Items[i].SubItems[5].Text = "Brak w Sello lub już wysłana";
									item.SubItems[5].Font = new Font(item.Font,
										item.Font.Style | FontStyle.Bold);
								}
							
							}));
							
							connection.Close();
							
						}				           		
				           		
					}
				}).Start();
				
				
			} catch (SqlException ex) {
				MessageBox.Show("Wystąpił błąd: " + ex.Message);
				progressBar.Value = 0;
			}
		}
		void MainForm_Form_Closed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
		
		public void LoadSettings()
		{
			server = Settings.Default.sql_server;
			database = Settings.Default.sql_database;
			uid = Settings.Default.sql_username;
			upwd = (Settings.Default.sql_password == "") ? Settings.Default.sql_password : Settings.Default.sql_password.DecryptString();
			setAsSent = Settings.Default.setAsSent;

            en_user1 = Settings.Default.enadawca_user1;
            en_password1 = Settings.Default.enadawca_password1?.DecryptString();
            en_user2 = Settings.Default.enadawca_user2;
            en_password2 = Settings.Default.enadawca_password2?.DecryptString();
            en_mode = Settings.Default.enadawca_mode;

            comboBoxAccounts.Items.Clear();
            if (en_user1 != "" && en_password1 != "")
            {
                comboBoxAccounts.Items.Add("Pierwsze konto");
                comboBoxAccounts.SelectedIndex = 0;
            }
            if (en_user2 != "" && en_password2 != "")
                comboBoxAccounts.Items.Add("Drugie konto");
			
			switch (en_mode) {
				case 1:
					listView.Columns[1].Text = "Nick klienta";
					break;
				case 2:
					listView.Columns[1].Text = "GUID przesyłki";
					break;
			}
		}
		
		void MainForm_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible) {
                LoadSettings();
			}
		}
		void ButtonSettings_Click(object sender, EventArgs e)
		{
            if (Program.settingsForm == null)
                Program.settingsForm = new SettingsForm();
            Program.settingsForm.ShowDialog(this);
            LoadSettings();
        }
		
		public void EnGetPackages(string user, string password)
		{
			if (user != "" & password != "") {
				progressBar.Maximum = 5;
				progressBar.Value = 1;
				
				new Thread(() => {
				           	
					try {
						ElektronicznyNadawca tEN = new en.ElektronicznyNadawca();
						System.Net.NetworkCredential c = new System.Net.NetworkCredential();
						c.UserName = user;
						c.Password = password;
						System.Net.CredentialCache cc = new System.Net.CredentialCache();
						cc.Add(new Uri("https://e-nadawca.poczta-polska.pl/websrv/en.wsdl"), "Basic", c);
						tEN.Credentials = cc;
						
						envelopeInfoType[] envInfo = tEN.getEnvelopeList(dateTimePicker.Value, DateTime.Today);
		
						if (envInfo != null) {
							
							Invoke(new Action(() => {
								listView.Items.Clear();
							}));
						
							foreach (envelopeInfoType singleEnv in envInfo) {
								int envId = singleEnv.idEnvelope;
								
								errorType[] error;
								Encoding iso = Encoding.GetEncoding("ISO-8859-2");
								String Xml = iso.GetString(tEN.downloadIWDContent(envId, out  error));
								XmlDocument XmlDoc = new XmlDocument();
								XmlDoc.LoadXml(Xml);
	
								LoadXml(XmlDoc);
							}
								
						}
                        Invoke(new Action(() => {
                            progressBar.Value = progressBar.Maximum;
                        }));
                    } catch (Exception e) {
						MessageBox.Show("Wystąpił błąd podczas łączenia się z API E-Nadawcy:\n" + e.Message);
						Invoke(new Action(() => {
							progressBar.Value = 0;
						}));
					}
				}).Start();
					
				
			} else {
				MessageBox.Show("Nie podano danych dostępowych do E-Nadawcy. Podaj je w ustawieniach aplikacji.");
                if (Program.settingsForm == null)
                    Program.settingsForm = new SettingsForm();
                Program.settingsForm.ShowDialog(this);
                LoadSettings();
			}
		}

		void ButtonGetData_Click(object sender, EventArgs e)
		{
            switch (comboBoxAccounts.SelectedIndex)
            {
                case 0:
                default:
                    EnGetPackages(en_user1, en_password1);
                    break;
                case 1:
                    EnGetPackages(en_user2, en_password2);
                    break;
            }
		}
		
	}
	
}
