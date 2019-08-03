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
            Console.WriteLine($"主线程测试开始..{Thread.CurrentThread.ManagedThreadId}");
            AsyncMethod();
            Thread.Sleep(1000);
            Console.WriteLine("主线程测试结束..");
            Console.ReadLine();
        }

        static async void AsyncMethod()
        {
            Console.WriteLine("开始异步代码");
            var result = await MyMethod();
            Console.WriteLine($"异步代码执行完毕:{result}");
        }

        static async Task<int> MyMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("异步执行" + i.ToString() + ".."+Thread.CurrentThread.ManagedThreadId);
                await Task.Delay(5000); //模拟耗时操作
            }
            return 100;
        }
    }
}
