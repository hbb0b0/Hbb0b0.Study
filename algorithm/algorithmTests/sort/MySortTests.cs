using Microsoft.VisualStudio.TestTools.UnitTesting;
using algorithm.sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace algorithm.sort.Tests
{
    [TestClass()]
    public class MySortTests
    {
        [TestMethod()]
        public void QuickSortTest()
        {
            int[] myArray = new[] { 0, 7,1, 6, 3, 9, 5 };
            algorithm.sort.MySort.QuickSort<int>(myArray);
            //Assert.Fail();
        }
    }
}