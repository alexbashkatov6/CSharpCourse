using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Algorithms
{
    public class SearchAlgorithms
    {
        public static int BinarySearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length;
            while (low < high)
            {
                int middleIndex = (low + high) / 2;
                if (array[middleIndex] == value)
                    return middleIndex;
                else if (array[middleIndex] > value)
                    high = middleIndex;
                else
                    low = middleIndex+1;
            }
            return -1;

        }

        public static int RecursiveBinarySearch(int[] array, int value)
        {
            return InternalRecursiveBinarySearch(0, array.Length);

            int InternalRecursiveBinarySearch(int low, int high)
            {
                if (low >= high)
                    return -1;

                int mid = (low + high)/2;
                if (array[mid] == value)
                    return mid;
                if (array[mid] < value)
                    return InternalRecursiveBinarySearch(mid+1, high);
                return InternalRecursiveBinarySearch(low, mid);
            }

        }
    }
}
