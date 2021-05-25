using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTaskCancelSample
{
    public class CalculatorFibnacciWithMem
    {
        static List<Tuple<int, long>> s_List = new List<Tuple<int, long>>();
        static int s_RecurseCounter = 0;
         public static long Fib(int number)
        {
            
            if(number>1)
            {
                Debug.WriteLine($"s_RecurseCounter:{s_RecurseCounter++} Calc:Fib({number - 2})+Fib({number-1})");
                long result1 = 0,result2=0;
                if(s_List.Any(p=>p.Item1==(number-2)))
                {
                    result1 = s_List.First(p => p.Item1 == (number - 2)).Item2;
                }
                else
                {
                    result1 = Fib(number - 2);
                }

                if (s_List.Any(p => p.Item1 == (number - 1)))
                {
                    result2 = s_List.First(p => p.Item1 == (number - 1)).Item2;
                }
                else
                {
                    result2 = Fib(number - 1);
                }
                Record(number, result1 + result2);
                return result1 + result2;
            }
            else
            {
                Record(number, 1);
                return 1;
            }
        }

        private  static void Record(int number,long result)
        {
            if (!s_List.Any(p => p.Item1 == number))
            {
                s_List.Add(new Tuple<int, long>(number, result));
            }
        }

        public static async Task<long> FibAsync(int number)
        {
            s_RecurseCounter = 0;
            Task<long> t = Task.Factory.StartNew<long>(() =>
            {
                long result= Fib(number);
                return result;
            });

            return await t;
        }

        public  static void Dump()
        {
            Debug.WriteLine($"{String.Join(",", s_List)}");
        }
    }
}
