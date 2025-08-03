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

        public AppConfiguration Settings { get; }

        private Configuration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // Ensure Microsoft.Extensions.FileProviders is referenced  
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Settings = config.Get<AppConfiguration>();
            Settings.OS = OSHelper.GetOSName();
            
            //Settings.LoggingServer = Environment.GetEnvironmentVariable("LOGGING_SERVER") ?? "localhost";
            //Settings.LogFile = Environment.GetEnvironmentVariable("LOG_FILE") ?? "logs/system.log";
            //Settings.DBType = (DBTypeConfig)Enum.Parse(typeof(DBTypeConfig), Environment.GetEnvironmentVariable("DB_TYPE") ?? "SQLite", true);

        }

        //public override string? ToString()
        //{
        //    return $"{Settings.OS}\t{Settings.LoggingServer}\t{Settings.LogFile}\t{Settings.DBType.SQLite}";
        //}
    }
}
