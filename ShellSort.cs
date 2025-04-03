using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Suite_Lib
{
    public class ShellSort : Sort
    {
        public static void Shell_Sort(int[] array)
        {
            int gap = 1;
            while (gap < array.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                    {
                        Swap(array, j, j - gap);
                    }
                }
                gap /= 3;
            }
        }

    }
}
