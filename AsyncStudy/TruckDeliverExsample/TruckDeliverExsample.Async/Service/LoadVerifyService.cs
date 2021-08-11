using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TruckDeliverExsample.Async.IService;

namespace TruckDeliverExsample.Async.Service
{
    class LoadVerifyService : ILoadVerifyService
    {
        public async Task< bool> VerifyAsync(string token)
        {
            Console.WriteLine($"Verify start");
            await Task.Delay(10000);
            Console.WriteLine($"Verify end");
            return true;
        }
    }
}
