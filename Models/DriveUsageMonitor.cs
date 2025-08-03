using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Interfaces;

namespace SystemMonitoringTool.Models
{
    public class DriveUsageMonitor : IMonitorPlugin
    {
        public string Name => "Drive";
        public string GetStatus()
        {
            string driveData = string.Empty;

            long totalSize = 0;
            long freeSpace = 0;
            long usedSpace = 0;

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var d in drives)
            {
                //Console.WriteLine($" - {d.Name}");
                var drive = new DriveInfo($"{d.Name}\\"); // Change to the desired drive letter
                
                totalSize += drive.TotalSize;
                freeSpace += drive.AvailableFreeSpace;

                var tempUsedSpace = (drive.TotalSize - drive.AvailableFreeSpace);
                usedSpace += tempUsedSpace;

            }

            driveData = $"\tTotal size = {totalSize/(1024*1024*1024)}GB \n\tFree Space = {freeSpace / (1024 * 1024 * 1024)}GB \n\tUsed Space = {usedSpace / (1024 * 1024 * 1024)}GB";

            return driveData;
        }
    }
}
