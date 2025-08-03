using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes.Base;
using SystemMonitoringTool.Interfaces;
using SystemMonitoringTool.Services;

namespace SystemMonitoringTool.Views
{
    public class MainView : AViewBase<MainView>, IView
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
            MainView.Instance.MenuList = new List<string>() {
                "1. Start Application ",
                "2. Settings ",
                "3. Exit",
            };
        }

        public async Task View()
        {

            MainView.Instance.LoadMenuList();

            do//main loop
            {
                Console.Clear();
                Console.WriteLine("\t----- !!! System Monitoring - By MdKasimS !!! -----");
                Console.WriteLine("================================================");

                Console.WriteLine("\nMain : ");
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
                        new ResourceMonitorService().StartMonitoringAsync(CancellationToken.None).GetAwaiter().GetResult();
                        break;

                    case 2:
                        SettingsView.Instance.View();
                        break;

                    case 3:

                        break;

                    default:
                        Console.WriteLine("Please enter the valid Choice 2 .....");
                        break;
                }
            } while (Choice != Instance.MenuList.Count);

        }

    }
}
