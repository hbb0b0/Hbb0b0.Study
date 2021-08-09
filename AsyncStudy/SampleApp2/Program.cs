using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"主线程测试开始.. threadID:{Thread.CurrentThread.ManagedThreadId}");
            AsyncMethod();
            Thread.Sleep(1000);
            Console.WriteLine($"主线程测试结束..threadID:{Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();
        }

        static async void AsyncMethod()
        {
            Console.WriteLine($"开始异步代码  threadID:{Thread.CurrentThread.ManagedThreadId}");
            var result = await MyMethod();
            Console.WriteLine($"异步代码执行完毕:{result}   threadID:{Thread.CurrentThread.ManagedThreadId}");
        }

        static async Task<int> MyMethod()
        {
            /* 1 await Task.Delay(5000) 在Console.WriteLine 之后,
             * 为什么第一条输出 threadID是主线程id，之后的输出都在子线程id？？？
               2 当把 await Task.Delay(5000) 在Console.WriteLine 之前，所有的
               异步执行 threadID 都是子线程的id
              
              原因:async 异步方法中，await之后，以后的语句都在子线程运行；await之前，
              所有的代码都运行主线程中 
             */
            for (int i = 0; i < 5; i++)
            {
             
                Console.WriteLine($"异步执行 { i.ToString()} ..threadID:{ Thread.CurrentThread.ManagedThreadId} at:{DateTime.Now.ToLongTimeString()}");

                await Task.Delay(5000); //模拟耗时操作
            }
            return 100;
        }
    }
}
