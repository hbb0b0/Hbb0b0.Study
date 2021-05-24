using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFunctionCodeSample.Sample
{
    class GloabalRandomWithNoLock : IRun
    {
        public  void Run()
        {
            //throw new NotImplementedException();

            Random rnd = new Random();

            List<Task<int>> taskList = new List<Task<int>>();
            for (int i = 10 - 1; i >= 0; i--)
            {
                Task<int> t = Task.Factory.StartNew(() =>
                {

                    int value = rnd.Next(0, 101);

                    return value;
                });

                taskList.Add(t);
            }


            Task.WaitAll(taskList.ToArray());

            foreach (var item in taskList)
            {
                Console.WriteLine(item.Result);
            }

            Console.ReadKey();

        }
    }
}
