using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoringTool.Interfaces
{
    public interface IMonitorPlugin
    {
        string Name { get; }
        //Task ExecuteAsync(ResourceUtilization data);
    }

}
