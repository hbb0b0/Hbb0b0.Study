using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TruckDeliverExsample.Async.IService;
using TruckDeliverExsample.Async.Service;

namespace TruckDeliverExsample.Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await RunAsync();

            Console.WriteLine("go end");


        }

        static async Task RunAsync()
        {
            Console.WriteLine("RunAsync");
            IDriverService driver = new DriverService();
            ILoadVerifyService loadVerify = new LoadVerifyService();
            INewLoadAssignerService newLoadAssigner = new NewLoadAssingnerService();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            string userId = "lhb";

            string token=await  driver.ReportToBackOffficeAsync(userId);
            var verifyTask = loadVerify.VerifyAsync(token);
            var assignTask = newLoadAssigner.AssignerAsync(token);
            //等待VerifyAsync与AssignerAsync 执行完毕
            Task.WaitAll(verifyTask, assignTask);
            stopwatch.Stop();

            Console.WriteLine($"Async cost time ElapsedMilliseconds:{stopwatch.ElapsedMilliseconds}");
        }
    }
}
