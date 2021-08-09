using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApp3
{
    internal class Test1
    {

        internal static void Run()
        {
            Console.WriteLine($" Run   threadid:{GetThreadId()}");
            callMethod();
            Console.ReadKey();
        }
        public static async void callMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($" Method 1  threadid:{GetThreadId()}");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($" Method 2  threadid:{GetThreadId()}");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine($"Method3 Total count is :{count} threadid:{GetThreadId()}" );
        }

        static int GetThreadId()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }
}
