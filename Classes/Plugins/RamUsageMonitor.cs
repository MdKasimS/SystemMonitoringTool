using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes.Resource;
using SystemMonitoringTool.Interfaces;

namespace SystemMonitoringTool.Classes.Plugins
{
    public class RamUsageMonitor:IMonitorPlugin
    {
        public string Name => "RAM";

        public void Execute(ResourceStatusPackage package)
        {
            throw new NotImplementedException();
        }

        public string GetStatus()
        {
            using (var ramCounter = new PerformanceCounter("Memory", "Available MBytes"))
            {
                float availableRam = ramCounter.NextValue();
                Thread.Sleep(1000); // Wait a second to get accurate reading
                return $"RAM Usage: {availableRam:F2}";
            }
        }

    }
}
