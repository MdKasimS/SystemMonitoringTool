using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoringTool.Classes
{

    public class ResourceStatus
    {
        public string ResourceType { get; set; }
        public double Usage { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
