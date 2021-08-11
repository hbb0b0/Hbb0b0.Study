using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDeliverExsample.Sync.IService
{
    interface IDriverService
    {
        /// <summary>
        /// ReportToBackOfffice
        /// </summary>
        /// <returns></returns>
        string ReportToBackOfffice(string userID);
    }
}
