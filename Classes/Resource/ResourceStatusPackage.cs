using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoringTool.Classes.Resource
{
    public class ResourceStatusPackage
    {
        private readonly ConcurrentQueue<ResourceStatus> _queue = new();

        public void Publish(ResourceStatus status) => _queue.Enqueue(status);

        public bool TryConsume(out ResourceStatus status) => _queue.TryDequeue(out status);
    }


}
