using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Classes.Resource;

namespace SystemMonitoringTool.Interfaces
{
    public interface IMonitorPlugin
    {
        string Name { get; }
        string GetStatus()
        {
            return "";
        }

        void Execute(ResourceStatusPackage package);

    }

}
