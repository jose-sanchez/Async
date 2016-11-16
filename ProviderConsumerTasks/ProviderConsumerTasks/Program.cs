using ProviderConsumerTasks.Consumers;
using ProviderConsumerTasks.Providers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderConsumerTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<BaseRequest> requestQueue = new ConcurrentQueue<BaseRequest>();

            Task task1 = Task.Factory.StartNew(() => 
            { RequestProvider provider = new RequestProvider(requestQueue, "provider1");
                while (true)
                {
                    provider.SendRequest();
                }

            });

            Task task2 = Task.Factory.StartNew(() =>
            {
                RequestConsumer provider = new RequestConsumer(requestQueue, "consumer1");
                while (true)
                {
                    provider.ConsumeRequest();
                }

            });


            Task task3 = Task.Factory.StartNew(() =>
            {
                RequestProvider provider = new RequestProvider(requestQueue, "provider2");
                while (true)
                {
                    provider.SendRequest();
                }

            });

            Task task4 = Task.Factory.StartNew(() =>
            {
                RequestConsumer provider = new RequestConsumer(requestQueue, "consumer2");
                while (true)
                {
                    provider.ConsumeRequest();
                }

            });

            task4.Wait();
        }
    }
}
