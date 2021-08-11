using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TruckDeliverExsample.Sync.IService;

namespace TruckDeliverExsample.Sync.Service
{
    class LoadVerifyService : ILoadVerifyService
    {
        public bool Verify(string token)
        {
            Console.WriteLine($"Verify start");
            Thread.Sleep(10000);
            Console.WriteLine($"Verify end");
            return true;
        }
    }
}
