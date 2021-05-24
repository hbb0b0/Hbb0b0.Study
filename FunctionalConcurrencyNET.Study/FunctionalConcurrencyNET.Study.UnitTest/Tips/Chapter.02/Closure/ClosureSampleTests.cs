using Xunit;
using FunctionalConcurrencyNET.Study.Tips.Chapter._02.Closure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using System.Threading;

namespace FunctionalConcurrencyNET.Study.Tips.Chapter._02.Closure.Tests
{
    public class ClosureSampleTests
    {
        private readonly ITestOutputHelper output;
        public ClosureSampleTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact()]
        public void Closure_Strange_BehaviorTest()
        {
           

            ClosureSample closureSample = new ClosureSample();
            IEnumerable<int> expectList = Enumerable.Range(0, 10);
            IEnumerable<int> factList = closureSample.Closure_Strange_Behavior();
            
            //Assert.NotNull(factList);
            //Assert.NotEmpty(factList);
            foreach (var item in factList)
            {
                output.WriteLine(item.ToString());
            }

        }

        /// <summary>
        /// 闭包中引用了i,i的输出全是10
        /// </summary>
        [Fact]
        public void Closure_InMutiTask()
        {
            int iterations = 10;

            for (int i = 1; i <= iterations; i++)
            {
                Task.Factory.StartNew(() =>
                    output.WriteLine("{0} - {1}", Thread.CurrentThread.ManagedThreadId, i));
            }

            Assert.True(true);
        }
        /// <summary>
        /// 闭包。最终的输出都是*******
        /// </summary>
        [Fact]
        public void Closure_Basic()
        {

            string freeVariable = "I am a free variable"; //#A
            
            Action<string> actionLamda = (input) => { output.WriteLine(input); };

            Task taskOne = Task.Factory.StartNew(() => actionLamda(freeVariable));

            freeVariable = "**********";
       
            Task taskTwo = Task.Factory.StartNew(()=> actionLamda(freeVariable));

            Task.WaitAll(taskOne, taskTwo);

            //output.WriteLine(lambda("11111"));
            Assert.True(true);
        }


    }
}