using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using SystemMonitoringTool.Classes;
using SystemMonitoringTool.Interfaces;
using SystemMonitoringTool.Models;
using SystemMonitoringTool.Services;

public class Program
{
    private static void Main(string[] args)
    {
        new ResourceMonitorService().StartMonitoringAsync(CancellationToken.None).GetAwaiter().GetResult();

        var services = new ServiceCollection();

        services.AddSingleton<IMonitorPlugin, CpuUsageMonitor>();
        services.AddSingleton<IMonitorPlugin, RamUsageMonitor>();
        services.AddSingleton<IMonitorPlugin, DriveUsageMonitor>();
        services.AddSingleton<IService, ConsoleLoggingService>();
        services.AddSingleton<MonitorEngine>();

        var provider = services.BuildServiceProvider();

    }
}




