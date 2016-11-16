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
            // use an Action delegate and named method
            Task task1 = new Task(new Action(CreateRequest));
            // use an anonymous delegate
            Task task2 = new Task(delegate { CreateRequest(); });
            // use a lambda expression and a named method
            Task task3 = new Task(() => CreateRequest());
            // use a lambda expression and an anonymous method
            Task task4 = new Task(() => { CreateRequest(); });
     
        }

        private void CreateRequest()
        {
            requestQueue.Enqueue(new ProviderRequest());
        }
    }
}
