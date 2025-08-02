using System.Diagnostics;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        new ResourceMonitorService().StartMonitoringAsync(CancellationToken.None).GetAwaiter().GetResult();
    }
}

public class ResourceMonitorService
{
    private readonly string driveLetter = "C:\\"; // Use "/" for Linux/macOS, "C:\\" for Windows

    public async Task StartMonitoringAsync(CancellationToken cancellationToken)
    {
        var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        var ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        while (!cancellationToken.IsCancellationRequested)
        {
            float cpuUsage = cpuCounter.NextValue();
            float availableRam = ramCounter.NextValue();

            DriveInfo drive = new DriveInfo(driveLetter);
            long totalDisk = drive.TotalSize;
            long freeDisk = drive.AvailableFreeSpace;

            Console.Clear();
            Console.WriteLine($" CPU Usage: {cpuUsage:F2}%");
            Console.WriteLine($" Available RAM: {availableRam:F2} MB");
            Console.WriteLine($" Disk Usage on {driveLetter}:");
            Console.WriteLine($"   Total: {totalDisk / 1024 / 1024} MB");
            Console.WriteLine($"   Free:  {freeDisk / 1024 / 1024} MB");

            await Task.Delay(1000); // Refresh every second
        }
    }
}
