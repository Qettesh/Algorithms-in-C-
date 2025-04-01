using Algorithm_Suite_Lib;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Legacy;

namespace Algorithms_Suite_Lib.Tests
{
    [TestFixture]
    public class SortingTests
    {
        public int[][] Samples()
        {
            int[][] samples = new int[9][];
            samples[0] = new[] { 1 };
            samples[1] = new[] { 2, 1 };
            samples[2] = new[] { 2, 1, 3 };
            samples[3] = new[] { 1, 1, 1 };
            samples[4] = new[] { 2, -1, 3, 3 };
            samples[5] = new[] { 4, -5, 3, 3 };
            samples[6] = new[] { 0, -5, 3, 2 };
            samples[7] = new[] { 0, -5, 3, 1 };
            samples[8] = new[] { 3, 2, 5, 5, 1, -1, 4, 6 };

            return samples;
        }

        private void RunTestsSortAlgorithm(Action<int[]> sort)
        {
            foreach (var sample in Samples())
            {
                sort(sample);
                CollectionAssert.IsOrdered(sample);
                PrintOut(sample);
            }
        }

        private void PrintOut(int[] array)
        {
            TestContext.WriteLine("-------Trace-------\n");
            foreach (var el in array)
            {
                TestContext.WriteLine(el + " ");

            }
            TestContext.WriteLine("\n---------------------------------------------\n");
        }

        [Test]
        public void BubbleSort_ValidInput_SortedInput()
        {
            RunTestsSortAlgorithm(Sort.BubbleSort);
        }

        [Test]
        public void SelectionSort_ValidInput_SortedOutput()
        {
            RunTestsSortAlgorithm(SelectionSort.Selection_Sort);
        }

        [Test]
        public void InsertionSort_ValidInput_SortedOutput()
        {
            RunTestsSortAlgorithm(InsertionSort.Insertion_Sort);
        }
    }
}
