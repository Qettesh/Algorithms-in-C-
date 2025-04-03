using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class QuickSort : Sort
    {
        public static void Quick_Sort(int[] array)
        {
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;
                int j = Partition(low, high);
                Sort(low, j - 1);
                Sort(j + 1, high);
            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                int pivot = array[low];
                while (true)
                {
                    while (array[++i] < pivot)
                    {
                        if (i == high) break;
                    }

                    while (pivot < array[--j])
                    {
                        if (j == low) break;
                    }

                    if (i >= j)
                        break;

                    Swap(array, i , j);
                }

                Swap(array, low, j);
                return j;
            }
        }
    }
}
