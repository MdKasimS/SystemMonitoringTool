using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoringTool.Classes
{
    public class AppConfiguration
    {
        public string OS { get; set; }
        public string LoggingServer { get; set; }
        public string LogFile { get; set; }
        public DBTypeConfig DBType { get; set; }
    }

}
