using System;

namespace Sortings
{
    public class QuickSort1 : BaseSort
    {
        public override int[] Sort(int[] array)
        {
            var sortedArray = Sort(0, array.Length - 1, array);

            return sortedArray;
        }

        private int[] Sort(int left, int right, int[] array)
        {
            if(left >= right)
            {
                return array;
            }

            var pivot = array[right];

            // var left = Sort(left, right/2, array)

            return array;
        }
    }
}
