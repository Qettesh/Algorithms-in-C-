using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class InsertionSort
    {
        public static void Insertion_Sort(int[] array)
        {
            for(int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int curUnsorted = array[partIndex];
                int i = 0;
                for(i = partIndex; i > 0 && array[i-1] > curUnsorted; i--)
                {
                    array[i] = array[i-1];
                }
                array[i] = curUnsorted;
            }
        }
        private static void Swap(int[] array, int i, int j)
        {
            if (i == j)
                return;
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
