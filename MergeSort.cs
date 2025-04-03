using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class MergeSort : Sort
    {
        public static void Merge_Sort(int[] array)
        {
            int[] aux = new int[array.Length];
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;

                int mid = (high + low) / 2;
                Sort(low, mid);
                Sort(mid + 1, high);

                Merge(low, mid, high);
            }

            void Merge(int low, int mid, int high)
            {
                int i = low;
                int j = mid + 1;

                Array.Copy(array, low, aux, low, high - low + 1);

                for(int k = low; k <= high; k++)
                {
                    if (i > mid) array[k] = aux[j++];
                    else if (j > high) array[k] = aux[i++];
                    else if (aux[j] < aux[i])
                        array[k] = aux[i];
                    else
                        array[k] = aux[i++];
                }

            }

        }
        
    }
}
