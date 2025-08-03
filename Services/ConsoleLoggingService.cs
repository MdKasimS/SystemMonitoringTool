using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes;
using SystemMonitoringTool.Interfaces;

namespace SystemMonitoringTool.Services
{
    public class ConsoleLoggingService : IService
    {
        public void ReceiveStatus(ResourceStatusPackage package)
        {
            foreach (var status in package.Statuses)
            {
                Console.WriteLine($"{status.Timestamp}: {status.ResourceName} usage is {status.UsagePercentage:F2}%");
            }
        }
    }
}

