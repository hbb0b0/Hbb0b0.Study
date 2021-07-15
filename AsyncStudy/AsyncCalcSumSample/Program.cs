using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace AsyncCalcSumSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main start");
            RunSyncReadFiles();
            RunAsyncReadFiles();
            Console.WriteLine($"Main end");
            Console.Read();
        }

        async static void RunSyncReadFiles()
        {
            /**
             * data{n}.txt的读取是顺序的， 执行的总时间是单个读取文件的和
             */
            Stopwatch sw = Stopwatch.StartNew();
            List<int> taskList =new List<int>();
            
            taskList.AddRange(await CalcHelper.ProcessReadAsyncList("data/data1.txt"));
            taskList.AddRange(await CalcHelper.ProcessReadAsyncList("data/data2.txt"));
            taskList.AddRange(await CalcHelper.ProcessReadAsyncList("data/data3.txt"));
            taskList.AddRange(await CalcHelper.ProcessReadAsyncList("data/data4.txt"));
            sw.Stop();
            Console.WriteLine($"RunSyncReadFiles min:{taskList.Min()}  max:{taskList.Max()}  ElapsedMilliseconds: {sw.ElapsedMilliseconds}");
        }
         static void RunAsyncReadFiles()
        {
            /**
             * data{n}.txt 同时读取 执行的总时间是单个文件中最长的那个
             */

            Stopwatch sw = Stopwatch.StartNew();

            Task<List<int>>[] taskArray = new Task<List<int>>[4];

            taskArray[0] = CalcHelper.ProcessReadAsyncList("data/data1.txt");
            taskArray[1] = CalcHelper.ProcessReadAsyncList("data/data2.txt");
            taskArray[2] = CalcHelper.ProcessReadAsyncList("data/data3.txt");
            taskArray[3] = CalcHelper.ProcessReadAsyncList("data/data4.txt");

            Task.WaitAll(taskArray);
            List<int> resultList = new List<int>();
            resultList.AddRange(taskArray[0].Result);
            resultList.AddRange(taskArray[1].Result);
            resultList.AddRange(taskArray[2].Result);
            resultList.AddRange(taskArray[3].Result);
            sw.Stop();
            Console.WriteLine($"RunAsyncReadFiles min:{resultList.Min()}  max:{resultList.Max()}  ElapsedMilliseconds: {sw.ElapsedMilliseconds}");
        }

       
    }
}
