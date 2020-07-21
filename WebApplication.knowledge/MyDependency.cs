using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.knowledge
{
    public class MyDependency : IMyDependency
    {

        public MyDependency()
        {
        }

        public Task<string> WriteMessage(string message)
        {
            //_logger.LogInformation("MyDependency.WriteMessage called. Message:{MESSAGE}", message);

            //Console.WriteLine($"MyDependency.WriteMessage called. Message:{message}");
            return Task.FromResult($"MyDependency.WriteMessage called. Message:{message}"); ;
        }
    }
}
