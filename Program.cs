using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using SystemMonitoringTool.Classes;
using SystemMonitoringTool.Classes.Plugins;
using SystemMonitoringTool.Interfaces;
using SystemMonitoringTool.Services;
using SystemMonitoringTool.Views;

public class Program
{
    private static void Main(string[] args)
    {
        //basic test to see if the program is running
        //new ResourceMonitorService().StartMonitoringAsync(CancellationToken.None).GetAwaiter().GetResult();

        var services = new ServiceCollection();

        services.AddSingleton<IMonitorPlugin, CpuUsageMonitor>();
        services.AddSingleton<IMonitorPlugin, RamUsageMonitor>();
        services.AddSingleton<IMonitorPlugin, DriveUsageMonitor>();
        services.AddSingleton<IService, ConsoleLoggingService>();
        services.AddSingleton<MonitorEngine>();

        var provider = services.BuildServiceProvider();

        var app = MainView.Instance;

        app.View();
    }
}




