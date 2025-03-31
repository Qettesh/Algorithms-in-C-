using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class Sort
    {
        public static void BubbleSort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                    }
                }

            }
        }
        private static void Swap(int[] array, int i, int j)
        {
            if(i == j)
                return;
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;

        }
    }
}
