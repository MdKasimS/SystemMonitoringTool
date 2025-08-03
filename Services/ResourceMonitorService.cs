using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes.Config;
using SystemMonitoringTool.Classes.Plugins;
using SystemMonitoringTool.Models;

namespace SystemMonitoringTool.Services
{
    public class ResourceMonitorService
    {
        public async Task StartMonitoringAsync(CancellationToken cancellationToken)
        {
            var cpuCounter = new CpuUsageMonitor();
            var ramCounter = new RamUsageMonitor();
            var driveCounter = new DriveUsageMonitor();

            while (!cancellationToken.IsCancellationRequested)
            {
                string cpuUsage = cpuCounter.GetStatus();
                string availableRam = ramCounter.GetStatus();
                string driveUsage = driveCounter.GetStatus();

                Console.Clear();
                Console.WriteLine($" Operating System: {Environment.OSVersion}");

                Console.WriteLine($" CPU Usage: {cpuUsage:F2}");

                Console.WriteLine($" Available RAM: {availableRam:F2} MB");

                Console.WriteLine($" Drive Usage:\n {driveUsage:F2}");

                await Task.Delay(1000); // Refresh every second
            }
        }
    }
}
