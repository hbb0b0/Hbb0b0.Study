using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckDeliverExsample.Sync.IService
{
    interface ILoadVerifyService
    {
        bool Verify(string token);

    }
}
