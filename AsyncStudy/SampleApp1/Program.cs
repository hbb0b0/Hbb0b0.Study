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
        static  void Main(string[] args)
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
            Console.WriteLine($"AsyncCall GetNumber1 return:{result} end");
        }

       
        static  void SyncCall()
        {
            Console.WriteLine("SyncCall start ");
          
            Console.WriteLine($"SyncCall end");
        }

        /// <summary>
        /// 如果一个async修饰的方法没有Task.run则会保下面警告
        /// 警告CS1998  此异步方法缺少 "await" 运算符，将以同步方式运行。请考虑使用"await"运算符等待非阻止的API 调用，或者使用"await Task.Run(...)" 在后台线程上执行占用大量CPU 的工作
        /// </summary>
        /// <returns></returns>
        static async Task<int> GetNumber1()
        {
        
                Console.WriteLine($"GetNumber1 start at:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                //Task.Delay(5000).Wait();
                Console.WriteLine($"GetNumber1 end at:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
               // return 100;

              return   await Task.Run(()=> {
                Console.WriteLine($"GetNumber1 start at:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                //Task.Delay(5000).Wait();
                Console.WriteLine($"GetNumber1 end at:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                return 100;
            });

        }
    }
}
