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
        /// <summary>
        /// 调用方法
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Start.... ThreadId:{GetThreadId()}");
            CallAsync(); 
            Console.WriteLine("Main end....");
            Console.ReadLine();
        }

        /// <summary>
        /// 异步方法
        /// </summary>
        static async void CallAsync()
        {
            Console.WriteLine($"AsyncCall start  ThreadId:{GetThreadId()}");
            int result = await GetNumber1();
            Console.WriteLine($"AsyncCall:result:{result}  ThreadId:{GetThreadId()}");
            Console.WriteLine($"AsyncCall end ThreadId:{GetThreadId()}");
        }

        /// <summary>
        /// 异步操作
        /// </summary>
        /// <returns></returns>
        static async Task<int> GetNumber1()
        {
            //这一与运行在主线程中
            Console.WriteLine($"...async .GetNumber1.....ThreadId:{GetThreadId()}");

            var t = Task.Run(() =>
            {
                //此时才开始在子线程中运行
                Console.WriteLine($"....GetNumber1.....ThreadId:{GetThreadId()}");
                Task.Delay(5000).Wait();
                return 100;
            });

            return await t;
        }
        static int GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
