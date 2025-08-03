using System.Diagnostics;
using SystemMonitoringTool.Classes;
using SystemMonitoringTool.Classes.Resource;
using SystemMonitoringTool.Interfaces;
using SystemMonitoringTool.Models;

namespace SystemMonitoringTool.Classes.Plugins
{
    public class CpuUsageMonitor : IMonitorPlugin
    {
        public string Name => "CPU";

        public string GetStatus()
        {
            using (var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
            {
                cpuCounter.NextValue(); // First call returns 0
                Thread.Sleep(1000); // Wait a second to get accurate reading
                float value = cpuCounter.NextValue();
                return $"{value:F2}";

            }
        }

        public void Execute(ResourceStatusPackage package)
        {
            var status = new ResourceStatus
            {
                ResourceType = "CPU",
                Usage = GetStatus(),
                Timestamp = DateTime.UtcNow
            };

            package.Publish(status);
        }

    }
}
