using Algorithm_Suite_Lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Suite_Lib.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void BinarySearch_SortedInput_ReturnsCorrectIndex()
        {
            int[] input = { 0, 3, 4, 7, 8, 12, 15, 22 };
            Assert.That(2, Is.EqualTo(BinarySearch<int>.BinSearch(input, 4)));
            Assert.That(4, Is.EqualTo(BinarySearch<int>.BinSearch(input, 8)));
            Assert.That(6, Is.EqualTo(BinarySearch<int>.BinSearch(input, 15)));
            Assert.That(7, Is.EqualTo(BinarySearch<int>.BinSearch(input, 22)));

            Assert.That(2, Is.EqualTo(BinarySearch<int>.RecBinSearch(input, 4)));
            Assert.That(4, Is.EqualTo(BinarySearch<int>.RecBinSearch(input, 8)));
            Assert.That(6, Is.EqualTo(BinarySearch<int>.RecBinSearch(input, 15)));
            Assert.That(7, Is.EqualTo(BinarySearch<int>.RecBinSearch(input, 22)));
        }
    }
}
