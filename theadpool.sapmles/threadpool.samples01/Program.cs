using System;
using System.Threading;

namespace threadpool.samples01
{
    class Program
    {
        static void Main(string[] args)
        {
            // SampleTimerCall01.Run();
            SampleTimerCall02.Run();
            Console.ReadKey();

        }

         static void ExcuteCommand(object state, bool timedOut)
        {

            Console.WriteLine($"excuteCommand: time:{DateTime.Now.ToLongTimeString()}");
            Console.WriteLine("running********");
        }

        /// <summary>
        /// 实现定时执行功能
        /// </summary>
        class SampleTimerCall01
        {
            public static void Run()
            {
                object state = new object();
                //定义信号量
                AutoResetEvent wait = new AutoResetEvent(true);
                Console.WriteLine($"Main start time:{DateTime.Now.ToLongTimeString()}");
                //定时器执行方法，每5秒执行一次excuteCommand
                ThreadPool.RegisterWaitForSingleObject(wait, new WaitOrTimerCallback(ExcuteCommand), state, 5000, false);
                Console.WriteLine($"Main end time:{DateTime.Now.ToLongTimeString()}");

            }

           
        }
        class SampleTimerCall02
        {
            public static void Run()
            {
                object state = new object();
                //定义信号量 为fasle,收到型号量之后立即执行
                AutoResetEvent wait = new AutoResetEvent(false);
                Console.WriteLine($"Main start time:{DateTime.Now.ToLongTimeString()}");
                //定时器执行方法，每5秒执行一次excuteCommand
                ThreadPool.RegisterWaitForSingleObject(wait, new WaitOrTimerCallback(ExcuteCommand), state, 5000, false);
                Console.WriteLine($"Main RegisterWaitForSingleObject time:{DateTime.Now.ToLongTimeString()}");
                //设置信号量
                wait.Set();
                Console.WriteLine($"Main  wait.Set() time:{DateTime.Now.ToLongTimeString()}");
                Console.WriteLine($"Main end time:{DateTime.Now.ToLongTimeString()}");

            }

        }
    }
}
