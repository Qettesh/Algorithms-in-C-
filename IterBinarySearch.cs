using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsExercises
{
    public class IterBinarySearch
    {
        public static int BinarySearch(int[] array, int value)
        {
            //define boundaries before running loop
            int low = 0;
            int high = array.Length;

            //low is less than high the loop executes.
            while (low < high)
            {
                //calculate the middle element
                int mid = (low + high) / 2;

                //if the middle element is equal to the search value the loop returns mid then continues.
                if (array[mid] == value)
                    return mid;

                //if the middle value is less than the search value, take the right health
                if (array[mid] < value)
                    low = mid + 1;

                //otherwise middle element is greater than the search value
                //set the high index equal to mid
                else
                    high = mid;
            }
            return -1;
        }
    }
}
