using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFunctionCodeSample.Sample
{
    public class TaskExceptionSample : IRun
    {
        public void Run()
        {
            /*
            //throw new NotImplementedException();
            try
            {
                var t = Task.Factory.StartNew(() =>
                {
                    Task.Delay(5000).Wait();
                    throw new Exception("test");

                    return 1;
                });

     
                if(t.IsFaulted)
                {
                    throw t.Exception;
                }


            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
            WaitException();


        }

        #region 通过Wait捕获异常
        /// <summary>
        /// 通过wait可以捕获Task内部的异常
        /// </summary>
        public static void WaitException()
        {
            try
            {
                //和线程不同，Task中抛出的异常可以捕获，但是也不是直接捕获，而是由调用Wait()方法或者访问Result属性的时候，
                //由他们获得异常，将这个异常包装成AggregateException类型,或者直接以Exception，抛出捕获。

                //默认情况下，Task任务是由线程池线程异步执行。要知道Task任务的是否完成，
                //可以通过task.IsCompleted属性获得，也可以使用task.Wait来等待Task完成。
                Task t = Task.Run(() => TestException());
                
                t.Wait();
            }
            catch (Exception ex)
            {
                var a = ex.Message; //a的值为：发生一个或多个错误。
                var b = ex.GetBaseException(); //b的值为：Task异常测试
                Console.WriteLine(a + "|*|" + b);
            }
        }
        static void TestException()
        {
            throw new Exception("Task异常测试");
        }
        #endregion
    }
}
