using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoringTool.Classes.Config
{
    public class AppConfiguration
    {
        public string OS { get; set; }
        public string LoggingServer { get; set; }
        public string LogFile { get; set; }
        public DBTypeConfig DBType { get; set; }
        public long TimeInterval { get; set; } = 1000; // Default to 1 second
    }

}
