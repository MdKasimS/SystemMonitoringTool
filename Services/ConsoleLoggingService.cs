using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Interfaces;
using SystemMonitoringTool.Models;

namespace SystemMonitoringTool.Services
{
    public class ConsoleLoggingService : IService
    {
        public void Process(ResourceStatus status)
        {
            Console.WriteLine($"[{status.Timestamp}] {status.ResourceType} Usage: {status.Usage:F2}%");
        }
    }

}

