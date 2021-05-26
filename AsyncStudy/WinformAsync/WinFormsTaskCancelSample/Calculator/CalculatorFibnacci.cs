using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTaskCancelSample
{
    /// <summary>
    /// 递归方式计算
    /// </summary>
    public class CalculatorFibnacci
    {
        static int s_RecurseCounter = 0;
         public static long Fib(int number)
        {
            
            if(number>1)
            {
                Debug.WriteLine($"s_RecurseCounter:{s_RecurseCounter++} Calc:Fib({number - 2})+Fib({number-1})");
                return Fib(number - 2)+Fib(number-1);
            }
            else
            {
                return 1;
            }
        }

        public static async Task<long> FibAsync(int number)
        {
            s_RecurseCounter = 0;
            Task<long> t = Task.Factory.StartNew<long>(() =>
            {
                return Fib(number);
            });

            return await t;
        }
    }
}
