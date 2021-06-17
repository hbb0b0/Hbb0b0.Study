using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace AsyncCalcSumSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main start");
            Run();
            Console.WriteLine($"Main end");
            Console.Read();
        }

        async static void Run()
        {
            /**
             * data{n}.txt的读取是顺序的
             */
            List<int> taskList =new List<int>();
            
            taskList.AddRange(await CalcHelper.ProcessReadAsyncList("data/data1.txt"));
            taskList.AddRange(await CalcHelper.ProcessReadAsyncList("data/data2.txt"));
            taskList.AddRange(await CalcHelper.ProcessReadAsyncList("data/data3.txt"));
            taskList.AddRange(await CalcHelper.ProcessReadAsyncList("data/data4.txt"));
            
            Console.WriteLine($"min:{taskList.Min()}  max:{taskList.Max()}");
        }
        async static void Run()
        {
            /**
             * data{n}.txt的读取是顺序的
             */
            List<Task<List<int>>> taskList = new List<Task<List<int>>>();
            taskList.Add(CalcHelper.ProcessReadAsyncList("data/data1.txt"));
            taskList.Add(CalcHelper.ProcessReadAsyncList("data/data2.txt"));
            taskList.Add(CalcHelper.ProcessReadAsyncList("data/data3.txt"));
            taskList.Add(CalcHelper.ProcessReadAsyncList("data/data4.txt"));

      

            Console.WriteLine($"min:{taskList.Min()}  max:{taskList.Max()}");
        }
    }
}
