using System;

namespace AsyncFunctionCodeSample
{
    class Program
    {
        static void Main(string[] args)
        {
          

            //等待异步事件
            //IRun asyncVoidExample = new AsyncVoidExample();

            //asyncVoidExample.Run();

            IRun IRun2 = new TaskCompletionSourceSample();

            IRun2.Run();

            Console.ReadLine();
        }
    }
}
