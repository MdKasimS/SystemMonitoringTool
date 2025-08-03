using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes.Base;
using SystemMonitoringTool.Classes.Config;
using SystemMonitoringTool.Interfaces;
using SystemMonitoringTool.ViewModels;

namespace SystemMonitoringTool.Views
{
    public class SettingsView : AViewBase<SettingsView>, IView
    {
        private int _choice = 0;
        public int Choice { get => _choice; set => _choice = value; }
        public List<string> MenuList
        {
            get;
            set;
        }
        public void LoadMenuList()
        {
            SettingsView.Instance.MenuList = new List<string>() {
                "1. Show OS Platform ",
                "2. Update Logging Server URl ",
                "3. Update Log File Path",
                "4. Update Time Interval",
                "5. Update Database URL",
                "6. Update Database User Name",
                "7. Update Database User Name",
                "8. Save New Settings",
                "9. Exit",
            };
        }

        public async Task View()
        {

            SettingsView.Instance.LoadMenuList();


            do//main loop
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! System Monitoring - By MdKasimS !!! -----");
                Console.WriteLine("================================================");

                ShowSettings();

                Console.WriteLine("\nSettings : ");
                Console.WriteLine("---------------");

                foreach (string instr in Instance.MenuList)
                {
                    Console.WriteLine(instr);
                }

                Console.Write("Enter Your Choice : ");

                int.TryParse(Console.ReadLine(), out _choice);
                switch (Choice)
                {
                    case 1:
                        Instance.ShowOSPlatform();
                        break;

                    case 2:
                        Console.Write("Please Enter New Logging Server URL: ");
                        SettingsViewModel.Instance.UpdateLoggingServerUrlCommand();
                        break;

                    case 3:
                        Console.Write("Please Enter New Log File Path(along with file name): ");
                        SettingsViewModel.Instance.UpdateLogFileCommand();
                        break;

                    case 4:
                        Console.Write("Please Enter New Time Interval: ");
                        SettingsViewModel.Instance.UpdateTimeIntervalCommand();
                        break;

                    case 5:
                        Console.Write("Continue SQLite (0-> false |1-> true) : ");
                        SettingsViewModel.Instance.UpdateSqliteCommand();
                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice 2 .....");
                        break;
                }
            } while (Choice != Instance.MenuList.Count);

        }

        public async void ShowSettings()
        {
            Console.WriteLine(Configuration.Instance.ToString());
        }

        public async void ShowOSPlatform()
        {
            Console.WriteLine(Configuration.Instance.Settings.OS);
        }

    }

}
