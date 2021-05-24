using System;
using AsyncFunctionCodeSample.Sample;
namespace AsyncFunctionCodeSample
{
    class Program
    {
        static void Main(string[] args)
        {


            //等待异步事件
            //IRun asyncVoidExample = new AsyncVoidExample();

            //asyncVoidExample.Run();

            //IRun IRun2 = new TaskCompletionSourceSample();

            //IRun2.Run();

            IRun IRun3 = new GloabalRandomWithNoLock();

            IRun3.Run();

            Console.ReadLine();
        }
    }
}
