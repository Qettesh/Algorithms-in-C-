using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExercises
{
    public class RecursBinarySearch
    {
        public static int RecBinarySearch(int[] array, int value) 
        {
            return InterRecurseBinSearch(0, array.Length);
            //function which takes the boundaries which bound the health to run the search.
            int InterRecurseBinSearch(int low, int high)
            {
                if (low >= high)
                    return -1;

                int mid = (low + high) / 2;
                if (array[mid] == value)
                    return mid;

                if (array[mid] < value)
                    return InterRecurseBinSearch(mid + 1, high);

                return InterRecurseBinSearch(low, mid);

            }
        }
    }
}
