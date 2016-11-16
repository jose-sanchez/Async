using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderConsumerTasks.Consumers
{
    public class RequestConsumer : IConsumer
    {
        ConcurrentQueue<BaseRequest> requestQueue;
        String consumerName= String.Empty;
        public RequestConsumer(ConcurrentQueue<BaseRequest> requestQueue, String consumerName)
        {
            this.requestQueue = requestQueue;
            this.consumerName = consumerName;
        }
        public void ConsumeRequest()
        {
            ProccessOrReenqueue();
        }

        private void ProccessOrReenqueue()
        {
            ProviderRequest providerRequest;
            BaseRequest request;
            if (requestQueue.TryDequeue(out request))
            {
                providerRequest = request as ProviderRequest;
                if (providerRequest != null)
                {
                    ConsoleShowProccessedRequestMessage(providerRequest);
                }
                else
                {
                    requestQueue.Enqueue(request);
                }
            }
            
        }

        private void ConsoleShowProccessedRequestMessage(ProviderRequest providerRequest)
        {
            Console.WriteLine(String.Format("{0}:{1}",consumerName,providerRequest.ConsoleProcessedMessage));
        }
    }
}
