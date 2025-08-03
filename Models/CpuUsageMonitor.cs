using System.Diagnostics;
using SystemMonitoringTool.Classes;
using SystemMonitoringTool.Interfaces;

namespace SystemMonitoringTool.Models
{
    public class CpuUsageMonitor : IMonitorPlugin
    {
        public string Name => "CPU";

        public string GetStatus()
        {
            using (var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
            {
                cpuCounter.NextValue(); // First call returns 0
                System.Threading.Thread.Sleep(1000); // Wait a second to get accurate reading
                float value = cpuCounter.NextValue();
                return $"CPU Usage: {value:F2}%";

                //return new ResourceStatus
                //{
                //    ResourceName = Name,
                //    UsagePercentage = GetCpuUsage(),
                //    Timestamp = DateTime.UtcNow
                //};
            }
        }

        public void Execute(ResourceStatusPackage package)
        {
            var status = new ResourceStatus
            {
                ResourceType = "CPU",
                Usage = GetCpuUsage(),
                Timestamp = DateTime.UtcNow
            };

            package.Publish(status);
        }


        private double GetCpuUsage()
        {
            // Placeholder logic
            return new Random().NextDouble() * 100;
        }

    }
}
