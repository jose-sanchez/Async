using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderConsumerTasks.Consumers
{
    interface IConsumer
    {
        void ConsumeRequest();
    }
}
