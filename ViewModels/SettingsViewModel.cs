using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes.Base;
using SystemMonitoringTool.Classes.Config;
using SystemMonitoringTool.Models;

namespace SystemMonitoringTool.ViewModels
{
    public class SettingsViewModel: AViewModelBase<SettingsViewModel>
    {
        public async void UpdateLoggingServerUrlCommand()
        {
            string newUrl = Console.ReadLine();

            Settings.UpdateLoggingServerUrl(newUrl);
        }

        public async void UpdateLogFileCommand()
        {
            string newLogFileWithFullPath = Console.ReadLine();

            Settings.UpdateLogFile(newLogFileWithFullPath);
        }

        public async void UpdateTimeIntervalCommand()
        {
            string newTimeInterval = Console.ReadLine();

            Settings.UpdateTimeInterval(newTimeInterval);
        }

        public async void UpdateUserNameCommand()
        {
            string userName = Console.ReadLine();

            Settings.UpdateUserName(userName);
        }

        public async void UpdateDbUrlCommand()
        {
            string dbUrl = Console.ReadLine();

            Settings.UpdateDbUrl(dbUrl);
        }

        public async void UpdateDbPasswordCommand()
        {
            string dbUrl = Console.ReadLine();

            Settings.UpdateDbPassword(dbUrl);
        }
    }
}
