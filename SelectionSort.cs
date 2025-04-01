using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class SelectionSort : Sort
    {
        public static void Selection_Sort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0;  partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }

                Swap(array, largestAt, partIndex);
            }
        }
    }
}
