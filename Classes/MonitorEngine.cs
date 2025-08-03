using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitoringTool.Interfaces;

namespace SystemMonitoringTool.Classes
{
    public class MonitorEngine
    {
        private readonly List<IMonitorPlugin> _plugins = new();
        private readonly List<IService> _services = new();
        private readonly ResourceStatusPackage _package = new();

        public void RegisterPlugin(IMonitorPlugin plugin) => _plugins.Add(plugin);
        public void RegisterService(IService service) => _services.Add(service);

        public void Start()
        {
            foreach (var plugin in _plugins)
                plugin.Execute(_package);

            while (_package.TryConsume(out var status))
            {
                foreach (var service in _services)
                    service.Process(status);
            }
        }
    }

}
