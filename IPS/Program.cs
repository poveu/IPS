using System;
using System.ComponentModel;
using System.Configuration;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Linq;

namespace IPS
{
	internal sealed class Program
	{
		public static Ustawienia ustawieniaForm;
		public static MainForm mainForm;
		
		public static string INFO_WCZYTYWANIE = "Wczytywanie listy serwerów...";
		public static string INFO_WCZYTYWANIE_BAZ = "Wczytywanie dostępnych baz danych...";
		public static string INFO_NIE_ZNALEZIONO_BAZ = "Nie znaleziono żadnych baz";
		public static string INFO_LISTA_BAZ = "Wskaż bazę danych";
		public static string INFO_BRAK_SERWEROW = "Brak lokalnych serwerów";


		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			if (czyUstawieniaPuste()) {
				ustawieniaForm = new Ustawienia();
				Application.Run(ustawieniaForm);
			} else {
				mainForm = new MainForm();
				Application.Run(mainForm);
			}
		}
		
		public static bool czyUstawieniaPuste()
		{
			bool result = false;
			foreach (SettingsProperty currentProperty in Settings.Default.Properties) {
				
				string[] notRequired = { "enadawca_password", "enadawca_user", "sql_password" };
				
				if (!notRequired.Contains(currentProperty.Name)) {

					result |= (
					    (currentProperty.Name.Trim() == "") ||
					    (Settings.Default[currentProperty.Name].ToString().Trim() == "") ||
					    (Settings.Default[currentProperty.Name].ToString().Trim().Contains(INFO_LISTA_BAZ)) ||
					    (Settings.Default[currentProperty.Name].ToString().Trim().Contains(INFO_WCZYTYWANIE))
					   );
				}
				
			}
			return result;
		}
		
		
	}
	
}
