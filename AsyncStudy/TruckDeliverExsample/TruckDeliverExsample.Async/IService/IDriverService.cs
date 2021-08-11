using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDeliverExsample.Async.IService
{
    interface IDriverService
    {
        /// <summary>
        /// ReportToBackOfffice
        /// </summary>
        /// <returns></returns>
        Task<string> ReportToBackOffficeAsync(string userID);
    }
}
