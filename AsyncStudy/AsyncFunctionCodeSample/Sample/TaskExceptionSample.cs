using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFunctionCodeSample.Sample
{
    public class TaskExceptionSample : IRun
    {
        public void Run()
        {
            //throw new NotImplementedException();
            try
            {
                var t = Task.Factory.StartNew(() =>
                {
                    Task.Delay(5000).Wait();
                    throw new Exception("test");

                    return 1;
                });

     
                if(t.IsFaulted)
                {
                    throw t.Exception;
                }


            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
