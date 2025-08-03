using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes.Config;

namespace SystemMonitoringTool.Models
{
    public class Settings
    {
        public static void UpdateLoggingServerUrl(string newUrl)
        {
            Configuration.Instance.Settings.LoggingServer = newUrl;

            UpdateSettings("Logging Server", newUrl);
        }

        public static void UpdateLogFile(string newLogFileWithPath)
        {
            Configuration.Instance.Settings.LogFile = newLogFileWithPath;

            UpdateSettings("Log File", newLogFileWithPath);
        }

        public static void UpdateTimeInterval(string newTimeInetrval)
        {
            Configuration.Instance.Settings.TimeInterval = newTimeInetrval;

            UpdateSettings("Time Interval", newTimeInetrval);
        }

        public static void UpdateUserName(string userName)
        {
            Configuration.Instance.Settings.DBType.User_Name = userName;

            UpdateSettings("User_Name", userName);
        }

        public static void UpdateDbPasword(string password)
        {
            Configuration.Instance.Settings.DBType.Password = password;

            UpdateSettings("Password", password);
        }

        public static void UpdateDbUrl(string dbUrl)
        {
            Configuration.Instance.Settings.DBType.DB_URL = dbUrl;

            UpdateSettings("DB_URL", dbUrl);
        }

        private static void UpdateSettings(string key, string value)
        {
            Configuration.Instance.UpdateConfigJson(Configuration.Instance.Settings);

            string configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

            var json = File.ReadAllText(configPath);
            var jObject = JObject.Parse(json);

            jObject[key] = value;

            File.WriteAllText(configPath, jObject.ToString(Formatting.Indented));
        }
    }
}
