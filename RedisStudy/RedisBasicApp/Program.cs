using System;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
//using System.Configuration.Assemblies
namespace RedisBasicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConfigManager
            BasicSample basicSample = new BasicSample();
            //basicSample.HashTest();
            //basicSample.HashIncrement();
            long result = 0;

            //AsyncHashIncrement();

            basicSample.Wath();


            Console.Read();
        }

        static void AsyncHashIncrement()
        {
            BasicSample basicSample = new BasicSample();
            /*
            long result = 0;
            int maxCount = 10;

            Task[] taskArray = new Task[maxCount];
            for (int j = 0; j < maxCount; j++)
            {
                Task t = Task.Factory.StartNew(() =>
                {
                    result = basicSample.HashIncrementScript("{UserScore}", "{name0}", 5);
                    Debug.WriteLine($"{j}:{result}");
                });
                taskArray[j] = t;
            }

            Task.WaitAll(taskArray);
            */

            basicSample.HashIncrementScript("{UserScore}", "{name0}", 5);


        }
    }
}
