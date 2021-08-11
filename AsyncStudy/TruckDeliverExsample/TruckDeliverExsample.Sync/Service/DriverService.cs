using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TruckDeliverExsample.Sync.IService;

namespace TruckDeliverExsample.Sync.Service
{
    class DriverService : IDriverService
    {
        public string ReportToBackOfffice(string userID)
        {
            Console.WriteLine($"ReportToBackOfffice start");
            Thread.Sleep(3000);
            Console.WriteLine($"ReportToBackOfffice end");
            return $"{userID}_{Guid.NewGuid().ToString()}";
        }
    }
}
