using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TruckDeliverExsample.Sync.IService;

namespace TruckDeliverExsample.Sync.Service
{
    class NewLoadAssingnerService : INewLoadAssignerService
    {
        public void Assigner(string token)
        {
            Console.WriteLine($"Assigner start");
            Thread.Sleep(10000);
            Console.WriteLine($"Assigner end");
        }
    }
}
