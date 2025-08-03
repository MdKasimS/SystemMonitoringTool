using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SystemMonitoringTool.Classes.Config
{
    public class AppConfiguration
    {
        public string OS { get; set; }

        [ConfigurationKeyName("Logging Server")]
        public string LoggingServer { get; set; }

        [ConfigurationKeyName("Log File")]
        public string LogFile { get; set; }

        [ConfigurationKeyName("Time Interval")]
        public string TimeInterval { get; set; }

        [ConfigurationKeyName("DB Type")]
        public DBTypeConfig DBType { get; set; }

    }

}
