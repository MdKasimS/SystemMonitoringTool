using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SystemMonitoringTool.Classes.Config
{

    public sealed class Configuration
    {
        private static readonly Lazy<Configuration> _instance = new(() => new Configuration());
        public static Configuration Instance => _instance.Value;

        public string ConfigJson;

        public AppConfiguration Settings { get; }

        private Configuration()
        {
            //ConfigJson = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "appsettings.json"));

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


            Settings = config.Get<AppConfiguration>();

            if (String.IsNullOrEmpty(Settings.OS))
            {
                Settings.OS = OSHelper.GetOSName();
            }

            ConfigJson = UpdateConfigJson(Settings);

            //Settings.LoggingServer = Environment.GetEnvironmentVariable("LOGGING_SERVER") ?? "localhost";
            //Settings.LogFile = Environment.GetEnvironmentVariable("LOG_FILE") ?? "logs/system.log";
            //Settings.DBType = Environment.GetEnvironmentVariable("DB_TYPE") ?? "SQLite";

        }

        public override string? ToString()
        {
            //return $"{Settings.OS}\t{Settings.LoggingServer}\t{Settings.LogFile}\t{Settings.DBType.SQLite}";
            return ConfigJson;
        }
        
        public string UpdateConfigJson(AppConfiguration setting)
        {
            ConfigJson = "{\n" +
                         $"  \"OS\": \"{setting.OS}\",\n" +
                         $"  \"Logging Server\": \"{setting.LoggingServer}\",\n" +
                         $"  \"Log File\": \"{setting.LogFile}\",\n" +
                         $"  \"Time Interval\": \"{setting.TimeInterval}\",\n" +
                         "  \"DB Type\": {\n" +
                         $"    \"SQLite\": {setting.DBType.SQLite},\n" +
                         $"    \"User_Name\": \"{setting.DBType.User_Name}\",\n" +
                         $"    \"Password\": \"{setting.DBType.Password}\",\n" +
                         $"    \"DB_URL\": \"{setting.DBType.DB_URL}\"\n" +
                         "  }\n" +
                        "}";
            return ConfigJson;

        }
    }
}
