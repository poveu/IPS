using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace IPS
{
	internal sealed class Program
	{
		public static SettingsForm settingsForm;
		public static MainForm mainForm;

        public static string INFO_LOADING = "Wczytywanie listy serwerów...";
        public static string INFO_DATABASE_LIST = "Wybierz bazę danych";

		public static string INFO_NIE_ZNALEZIONO_BAZ = "Nie znaleziono żadnych baz";
		public static string INFO_BRAK_SERWEROW = "Brak lokalnych serwerów";

		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            if (Settings.Default.upgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.upgradeRequired = false;
                Settings.Default.Save();
            }

            mainForm = new MainForm();

            if (!dataProvided(
                new string[] {
                    Settings.Default.sql_server,
                    Settings.Default.sql_username,
                    Settings.Default.sql_password,
                    Settings.Default.sql_database
                },
                new List<string[]> {
                    new string[] {
                        Settings.Default.enadawca_user1,
                        Settings.Default.enadawca_password1
                    },
                    new string[] {
                        Settings.Default.dhl_login,
                        Settings.Default.dhl_password
                    }
                }
            ))
            {
                settingsForm = new SettingsForm();
                Application.Run(settingsForm);
            }
            else
            {
                Application.Run(mainForm);
            }
        }

        public static bool dataProvided(string[] requiredFields, List<string[]> optionalFields = null)
        {
            List<string> requiredList = new List<string>(requiredFields);
            bool requiredProvided = (requiredList.Count(x => string.IsNullOrEmpty(x)) == 0 && !requiredList.Contains(Program.INFO_LOADING) && !requiredList.Contains(Program.INFO_DATABASE_LIST));
            bool allDataProvided = requiredProvided;
            if (optionalFields != null)
            {
                List<string> optionalList1 = new List<string>(optionalFields[0]);
                List<string> optionalList2 = new List<string>(optionalFields[1]);
                bool optionalProvided = ((optionalList1.Count(x => string.IsNullOrEmpty(x)) == 0)
                    | (optionalList2.Count(x => string.IsNullOrEmpty(x)) == 0));
                allDataProvided = optionalProvided && requiredProvided;
            }
            return allDataProvided;
        }

		
	}
	
}
