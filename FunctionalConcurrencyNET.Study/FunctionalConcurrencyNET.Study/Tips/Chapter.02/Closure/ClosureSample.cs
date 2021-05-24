using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

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
                Task.Factory.StartNew(() =>
                    Console.WriteLine("{0} - {1}", Thread.CurrentThread.ManagedThreadId, i));
                Task.Factory.StartNew(() =>
                    Console.WriteLine("{0} - {1}", Thread.CurrentThread.ManagedThreadId, i));
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

        // Listing 2.5 Closure defined in C# using an anonymous method
       
    }
}
