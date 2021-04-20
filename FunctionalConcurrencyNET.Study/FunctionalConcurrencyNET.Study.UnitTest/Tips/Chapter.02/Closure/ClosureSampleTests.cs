using Xunit;
using FunctionalConcurrencyNET.Study.Tips.Chapter._02.Closure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalConcurrencyNET.Study.Tips.Chapter._02.Closure.Tests
{
    public class ClosureSampleTests
    {
        [Fact()]
        public void Closure_Strange_BehaviorTest()
        {
            Assert.True(false, "This test needs an implementation");

            ClosureSample closureSample = new ClosureSample();
            IEnumerable<int> expectList = Enumerable.Range(0, 10);
            IEnumerable<int> factList = closureSample.Closure_Strange_Behavior();
            //factList.ForEach(p =>
            //{
            //    Console.WriteLine(p);

            //});

            
            
    }
}