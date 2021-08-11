using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TruckDeliverExsample.Sync.IService;
using TruckDeliverExsample.Sync.Service;

namespace TruckDeliverExsample.Sync
{
    class Program
    {
        static async Task Main(string[] args)
        {
           // RunSync();
          await   RunAsync();

            //Console.Read();
        }

        /// <summary>
        /// 同步执行
        /// </summary>
        static void RunSync()
        {
            
            Console.WriteLine("RunSync");
            IDriverService driver = new DriverService();
            ILoadVerifyService loadVerify = new LoadVerifyService();
            INewLoadAssignerService newLoadAssigner = new NewLoadAssingnerService();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string userId = "lhb";
            string myToken = driver.ReportToBackOfffice(userId);
            loadVerify.Verify(myToken);
            newLoadAssigner.Assigner(myToken);

            stopwatch.Stop();

            Console.WriteLine($"Sync cost time ElapsedMilliseconds:{stopwatch.ElapsedMilliseconds}");
        }

        /// <summary>
        /// 在Task中异步执行任务 
        /// </summary>
        static async Task RunAsync()
        {
            Console.WriteLine("RunAsync");
            IDriverService driver = new DriverService();
            ILoadVerifyService loadVerify = new LoadVerifyService();
            INewLoadAssignerService newLoadAssigner = new NewLoadAssingnerService();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string userId = "lhb";

            /*
             * 同步执行获取 ReportToBackOfffice生成的token,
             * 异步执行Verify，Assigner,并且等待全部任务执行完毕
             * 
             */
            string token = await Task.Run(() =>
            {
                Console.WriteLine("async ReportToBackOfffice");
                return driver.ReportToBackOfffice(userId);
            });
            var t1 = Task.Run(() =>
            {
                Console.WriteLine("async Verify");
                return loadVerify.Verify(token);
            });

            var t2 = Task.Run(() =>
              {
                  Console.WriteLine("async Assigner");
                  newLoadAssigner.Assigner(token);
              });
         

            Task.WaitAll(t1, t2);

            stopwatch.Stop();

            Console.WriteLine($"Async cost time ElapsedMilliseconds:{stopwatch.ElapsedMilliseconds}");
        }
    }
}
