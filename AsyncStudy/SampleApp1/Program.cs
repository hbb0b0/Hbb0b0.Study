using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Start....");
            AsyncCall();
            SyncCall();

            Console.WriteLine("Main end....");
            Console.ReadLine();
        }

        static async void AsyncCall()
        {
            Console.WriteLine("AsyncCall start");
            int result = await GetNumber1();
<<<<<<< HEAD
            Console.WriteLine($"AsyncCall:result:{result}");
            Console.WriteLine("AsyncCall end");
=======
            Console.WriteLine($"AsyncCall GetNumber1 return:{result} end");
>>>>>>> 8af9b1201c7160e3b2374fb3b7b67cc3c1d813dd
        }

       
        static  void SyncCall()
        {
            Console.WriteLine("SyncCall start ");
          
            Console.WriteLine($"SyncCall end");
        }


        static async Task<int> GetNumber1()
        {
            //var result = Task.Run<int>(() => {

            //    Task.Delay(5000);
            //     return 1;
            // });
            Console.WriteLine($"GetNumber1 start");
            await Task.Delay(5000);
            Console.WriteLine($"GetNumber1 end");

            return 100;

        }
    }
}
