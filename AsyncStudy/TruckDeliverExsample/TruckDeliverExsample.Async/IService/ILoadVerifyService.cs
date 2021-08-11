using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDeliverExsample.Async.IService
{
    interface ILoadVerifyService
    {
        Task<bool> VerifyAsync(string token);

    }
}
