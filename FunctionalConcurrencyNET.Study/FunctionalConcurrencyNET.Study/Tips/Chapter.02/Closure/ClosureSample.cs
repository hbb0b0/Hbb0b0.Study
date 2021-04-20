using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionalConcurrencyNET.Study.Tips.Chapter._02.Closure
{
    public class ClosureSample
    {
        public IEnumerable<int> Closure_Strange_Behavior()
        {
            int iterations = 10;
            string text = "";
            List<int> resultList = new List<int>();
            for (int i = 1; i <= iterations; i++)
            {
  
                resultList.Add(i);
                text = i.ToString();
                Task.Factory.StartNew(() =>
                    Console.WriteLine(text));
            }
            return resultList;
        }

        public void Closure_Correct_Behavior()
        {
            int iterations = 10;
            for (int i = 1; i <= iterations; i++)
            {
                var index = i;
                Task.Factory.StartNew(() =>
                    Console.WriteLine("{0} - {1}", Thread.CurrentThread.ManagedThreadId, index));
            }
        }
    }
}
