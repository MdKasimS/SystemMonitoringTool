using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoringTool.Models
{

    public class ResourceStatus
    {
        public string ResourceType { get; set; }
        public string Usage { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
