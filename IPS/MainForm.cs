using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Http;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using IPS.en;

namespace IPS
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
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
		const string NICK1_NODE = "Uwagi";
		const string NICK2_NODE = "Tytulem1";
		
		const int PACKAGE_NICK_COL = 1;
		const int PACKAGE_NUMBER_COL = 4;
		
		SqlConnection polaczenie;
		string serwer;
		string baza;
		string uid;
		string upwd;
		bool setAsSent;
		
		string en_user;
		string en_password;
		
		public MainForm()
		{
			InitializeComponent();
			wczytajUstawienia();
			
			dateTimePicker1.MaxDate = DateTime.Today;
		}
		void Button2Click(object sender, EventArgs e)
		{ 
			openFileDialog1.Filter = "Plik XML|*.xml";  
			openFileDialog1.Title = "Wskaż plik z danymi przesyłek";
   
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
		    	 
				importData(openFileDialog1.FileName);
    
			}
		}
		
		void loadXml(XmlDocument XmlDoc)
		{
			
			XmlNodeList xnList = XmlDoc.SelectNodes(NODE_PATH);
			
			Invoke(new Action(() => {
				progressBar1.Value = 0;
				progressBar1.Maximum = xnList.Count;
			}));
	                
			foreach (XmlNode node in xnList) {
				String[] arr = new String[6];
				ListViewItem itm;

				arr[0] = getParsedNodeData(node, NAZWA_NODE);		
				arr[1] = (getParsedNodeData(node, NICK2_NODE) == "" ?
						          getParsedNodeData(node, NICK1_NODE, nickFormat: true) : getParsedNodeData(node, NICK2_NODE, nickFormat: true));
				arr[2] = getParsedNodeData(node, ULICA_NODE);
				arr[2] += getParsedNodeData(node, DOM_NODE, " ");
				arr[2] += getParsedNodeData(node, LOKAL_NODE, "/");
				arr[3] = getParsedNodeData(node, MIASTO_NODE);
				arr[4] = getParsedNodeData(node, NR_PRZESYLKI_NODE);
				arr[5] = "Przekonwertowano";
						
				if (arr[1] != "" && arr[4] != "") {
					itm = new ListViewItem(arr);
					Invoke(new Action(() => {
						listView1.Items.Add(itm);
					}));
				}
				
				Invoke(new Action(() => {				
					progressBar1.PerformStep();
				}));
			}
			
			Invoke(new Action(() => {
				listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
				listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			}));
		}
		
		void importData(string fileName)
		{
			var ext = System.IO.Path.GetExtension(fileName);
			if (ext.Equals(".xml", StringComparison.CurrentCultureIgnoreCase) ||
			    ext.Equals(".ips", StringComparison.CurrentCultureIgnoreCase)) {
			
				try {
					XmlDocument XmlDoc = new XmlDocument();
					XmlDoc.Load(fileName);
					listView1.Items.Clear();

					loadXml(XmlDoc);
					
					
                
				} catch (XmlException error) {
					MessageBox.Show("Nie udało się załadować pliku. Być może jest on uszkodzony." + "\n" + "Błąd: " + error.Message);
					progressBar1.Value = 0;
				}
                
			} else {
				MessageBox.Show("Aplikacja obsługuje tylko pliki .xml");
			}
		}
		
		string getParsedNodeData(XmlNode node, string selectedNode, string limiter = "", bool nickFormat = false)
		{
			string value = node.SelectSingleNode(NODE_NAME + "[@" + NODE_SELECTOR + "='" + selectedNode + "']") == null ?
				"" : limiter + node.SelectSingleNode(NODE_NAME + "[@" + NODE_SELECTOR + "='" + selectedNode + "']").InnerText.TrimEnd(',', '.', '?', ' ');
			
			return (nickFormat) ? convertLogin(value) : value;

		}
		
		string convertLogin(string login)
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
		
		void MainFormResizeEnd(object sender, EventArgs e)
		{
			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		
		private void listView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;
		}
		
		private void listView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (s.Length > 1)
				MessageBox.Show("Przekazano więcej niż jeden plik. Aplikacja wczyta tylko pierwszy z nich.");
			importData(s[0]);
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			try {
				
				polaczenie = new SqlConnection(@"Data source=" + serwer + ";database=" + baza + ";User id=" + uid + ";Password=" + upwd + ";");
				SqlCommand sqlComand = polaczenie.CreateCommand();
				
				ListView lista = listView1;

// Kod na przyszłość, jeśli dodani zostaną inni przewoźnicy:
//
//				string currentTab = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
//				switch (currentTab) {
//					case Program.INPOST_NAME:
//						lista = listView1;
//						break;
//					case Program.POCZTA_POLSKA_NAME:
//						lista = listView2;
//						break;
//					case Program.DHL_NAME:
//						lista = listView3;
//						break;
//					default:
//						lista = listView1;
//						break;
//				}
				
				new Thread(() => {
					Invoke(new Action(() => {
						progressBar1.Value = 0;
						progressBar1.Maximum = lista.Items.Count;
					}));
				           	
					for (int i = 0; i < lista.Items.Count; i++) {
				           		
						string packageNick = "";
						string packageNumber = "";
		
						Invoke(new Action(() => {
							progressBar1.PerformStep();              	
							packageNick = lista.Items[i].SubItems[PACKAGE_NICK_COL].Text;
							packageNumber = lista.Items[i].SubItems[PACKAGE_NUMBER_COL].Text;
						}
								                  
						));
				           		
						if ((packageNick != "") && (packageNumber != "")) {

							polaczenie.Open();

							Invoke(new Action(() => {
							
								ListViewItem item = lista.Items[i];
	
								lista.Items[i].SubItems[5].Text = "Przesyłanie do Sello...";

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
												cs_Nick = '" + packageNick + @"'
										)
									";

								int res = sqlComand.ExecuteNonQuery();
									
								if (res > 0) {
									item.ForeColor = Color.DarkGreen;
	
									lista.Items[i].SubItems[5].Text = "Przesłano do Sello";
									item.SubItems[5].Font = new Font(item.Font,
										item.Font.Style | FontStyle.Bold);
								} else {
									item.ForeColor = Color.DarkRed;
	
									lista.Items[i].SubItems[5].Text = "Brak w Sello lub już wysłana";
									item.SubItems[5].Font = new Font(item.Font,
										item.Font.Style | FontStyle.Bold);
								}
							
							}));
							
							polaczenie.Close();
							
						}				           		
				           		
					}
				}).Start();
				
				
			} catch (SqlException ex) {
				MessageBox.Show("Wystąpił błąd: " + ex.Message);
				progressBar1.Value = 0;
			}
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
		
		public void wczytajUstawienia()
		{
			serwer = Settings.Default.sql_server;
			baza = Settings.Default.sql_database;
			uid = Settings.Default.sql_username;
			upwd = (Settings.Default.sql_password == "") ? Settings.Default.sql_password : Settings.Default.sql_password.DecryptString();
			setAsSent = Settings.Default.setAsSent;
			
			en_user = Settings.Default.enadawca_user;
			en_password = Settings.Default.enadawca_password.DecryptString();
		}
		void MainFormVisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible) {
				wczytajUstawienia();
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			if (Program.ustawieniaForm == null)
				Program.ustawieniaForm = new Ustawienia();
			Program.ustawieniaForm.Show();
			Hide();
		}
		
		public void enGetPackages()
		{
			if (en_user != "" & en_password != "") {
				progressBar1.Maximum = 5;
				progressBar1.Value = 1;
				
				new Thread(() => {
				           	
					try {
						ElektronicznyNadawca tEN = new en.ElektronicznyNadawca();
						System.Net.NetworkCredential c = new System.Net.NetworkCredential();
						c.UserName = en_user;
						c.Password = en_password;
						System.Net.CredentialCache cc = new System.Net.CredentialCache();
						cc.Add(new Uri("https://e-nadawca.poczta-polska.pl/websrv/en.wsdl"), "Basic", c);
						tEN.Credentials = cc;
						
						envelopeInfoType[] envInfo = tEN.getEnvelopeList(dateTimePicker1.Value, DateTime.Today);
		
						if (envInfo != null) {
							
							Invoke(new Action(() => {
								listView1.Items.Clear();
							}));
						
							foreach (envelopeInfoType singleEnv in envInfo) {
								int envId = singleEnv.idEnvelope;
								
								errorType[] error;
								Encoding iso = Encoding.GetEncoding("ISO-8859-2");
								String Xml = iso.GetString(tEN.downloadIWDContent(envId, out  error));
								XmlDocument XmlDoc = new XmlDocument();
								XmlDoc.LoadXml(Xml);
	
								loadXml(XmlDoc);
							}
								
						}
					} catch (Exception e) {
						MessageBox.Show("Wystąpił błąd podczas łączenia się z API E-Nadawcy:\n" + e.Message);
						Invoke(new Action(() => {
							progressBar1.Value = 0;
						}));
					}
				}).Start();
					
				
			} else {
				MessageBox.Show("Nie podano danych dostępowych do E-Nadawcy. Podaj je w ustawieniach aplikacji.");
				if (Program.ustawieniaForm == null)
					Program.ustawieniaForm = new Ustawienia();
				Program.ustawieniaForm.Show();
				Hide();
			}
		}
		void Button4Click(object sender, EventArgs e)
		{
			enGetPackages();
		}
		
	}
	
}
