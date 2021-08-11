using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TruckDeliverExsample.Async.IService;

namespace TruckDeliverExsample.Async.Service
{
    class DriverService : IDriverService
    {
        public async Task<string> ReportToBackOffficeAsync(string userID)
        {
            Console.WriteLine($"ReportToBackOfffice start");
            //Thread.Sleep(3000);
            await Task.Delay(3000);
            Console.WriteLine($"ReportToBackOfffice end");
            return $"{userID}_{Guid.NewGuid().ToString()}";
        }

       
    }
}
