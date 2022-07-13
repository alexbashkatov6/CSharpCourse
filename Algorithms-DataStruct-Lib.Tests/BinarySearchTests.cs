using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void BinarySearch_SortedInput_ReturnsCorrectIndex()
        {
            int[] input = { 0, 3, 4, 7, 8, 12, 15, 22 };
            Assert.AreEqual(0, F_Algorithms.SearchAlgorithms.BinarySearch(input, 0));
            Assert.AreEqual(1, F_Algorithms.SearchAlgorithms.BinarySearch(input, 3));
            Assert.AreEqual(2, F_Algorithms.SearchAlgorithms.BinarySearch(input, 4));
            Assert.AreEqual(3, F_Algorithms.SearchAlgorithms.BinarySearch(input, 7));
            Assert.AreEqual(-1, F_Algorithms.SearchAlgorithms.BinarySearch(input, 2));

            Assert.AreEqual(4, F_Algorithms.SearchAlgorithms.RecursiveBinarySearch(input, 8));
            Assert.AreEqual(5, F_Algorithms.SearchAlgorithms.RecursiveBinarySearch(input, 12));
            Assert.AreEqual(6, F_Algorithms.SearchAlgorithms.RecursiveBinarySearch(input, 15));
            Assert.AreEqual(7, F_Algorithms.SearchAlgorithms.RecursiveBinarySearch(input, 22));
            Assert.AreEqual(-1, F_Algorithms.SearchAlgorithms.RecursiveBinarySearch(input, 23));
        }
    }
}
