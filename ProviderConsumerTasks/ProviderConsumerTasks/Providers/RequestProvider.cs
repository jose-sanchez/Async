using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderConsumerTasks.Providers
{
    public class RequestProvider : IProvider
    {
        ConcurrentQueue<BaseRequest> requestQueue;
        public RequestProvider(ConcurrentQueue<BaseRequest> requestQueue)
        {
            this.requestQueue = requestQueue;
        }
        public void SendRequest()
        {
            CreateRequest();
        }

        public void CreateRequest()
        {
            requestQueue.Enqueue(new ProviderRequest());
        }
    }
}
