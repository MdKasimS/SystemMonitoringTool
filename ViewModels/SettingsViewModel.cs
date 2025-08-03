using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes.Base;
using SystemMonitoringTool.Classes.Config;

namespace SystemMonitoringTool.ViewModels
{
    public class SettingsViewModel: AViewModelBase<SettingsViewModel>
    {
        public async void UpdateLoggingServerUrl()
        {
            string newUrl = Console.ReadLine();

            Configuration.Instance.Settings.LoggingServer = newUrl;
            Configuration.Instance.UpdateConfigJson(Configuration.Instance.Settings);

            string configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

            var json = File.ReadAllText(configPath);
            var jObject = JObject.Parse(json);

            jObject["Logging Server"] = newUrl;

            File.WriteAllText(configPath, jObject.ToString(Formatting.Indented));


        }
    }
}
