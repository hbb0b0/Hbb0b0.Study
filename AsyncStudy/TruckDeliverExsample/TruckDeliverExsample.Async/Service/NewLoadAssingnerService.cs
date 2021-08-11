using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TruckDeliverExsample.Async.IService;

namespace TruckDeliverExsample.Async.Service
{
    class NewLoadAssingnerService : INewLoadAssignerService
    {
  
        public async Task AssignerAsync(string token)
        {
            Console.WriteLine($"Assigner start");
           await   Task.Delay(10000);
            Console.WriteLine($"Assigner end");
        }
    }
}
