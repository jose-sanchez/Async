using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProviderConsumerTasks.Providers
{
    public class RequestProvider : IProvider
    {
        int requestID = 0;
        ConcurrentQueue<BaseRequest> requestQueue;
        String providerName = String.Empty;
        private static readonly Object obj = new Object();
        public RequestProvider(ConcurrentQueue<BaseRequest> requestQueue, String providerName)
        {
            this.requestQueue = requestQueue;
            this.providerName = providerName;
        }
        
        public void SendRequest()
        {
            // use an Action delegate and named method
            Task task1 = new Task(new Action(CreateRequest));
            // use an anonymous delegate
            Task task2 = new Task(delegate { CreateRequest(); });
            // use a lambda expression and a named method
            Task task3 = new Task(() => CreateRequest());
            // use a lambda expression and an anonymous method
            Task task4 = new Task(() => { CreateRequest(); });

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

        }

        private void CreateRequest()
        {
            Thread.Sleep(5000);
            
            ProviderRequest request;
            lock (obj)
            {
                Interlocked.Add(ref requestID, 1);
                request = new ProviderRequest() { ConsoleProcessedMessage = String.Format("Request Number {0}", requestID) };
            }
            ConsoleShowCreatedRequestMessage(request);
            requestQueue.Enqueue(request);
            
        }

        private void ConsoleShowCreatedRequestMessage(ProviderRequest request)
        {
            Console.WriteLine(String.Format("{0}:{1}", providerName, request.ConsoleProcessedMessage));
        }
    }
}
