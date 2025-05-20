using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class BinarySearch <T> : IEnumerable<T>
    {
        public static int RecBinSearch(int[] array, int value) //Recursive binary search
        {
            int IntRecBinSearch(int low, int high)
            {
                if (low >= high) return -1;
                int mid = (low + high) / 2;
                if (array[mid] == value) return mid;
                if (array[mid] < value) return IntRecBinSearch(mid + 1, high);
                return IntRecBinSearch(low, mid);

            }
            return IntRecBinSearch(0, array.Length);
        }
        public static int BinSearch(int[] array, int value)   //Linear binary search
        {
            int low = 0;
            int high = array.Length;
            while (low < high)
            {
                int mid = (low + high) / 2;

                if (array[mid] == value)
                    return mid;
                if (array[mid] < value) low = mid + 1;
                else high = mid;
            }
            return -1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
