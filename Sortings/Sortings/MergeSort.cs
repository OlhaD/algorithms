using System;

namespace Sortings
{
    public class MergeSort : BaseSort
    {
        public override int[] Sort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int[] left = InitLeft(array);
            int[] right = InitRight(array);

            left = Sort(left);
            right = Sort(right);

            var result = Merge(left, right);

            return result;
        }

        private static int[] InitLeft(int[] array)
        {
            var middle = array.Length / 2;
            var left = new int[middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = array[i];
            }

            return left;
        }

        private static int[] InitRight(int[] array)
        {
            var middle = array.Length / 2;
            var right = array.Length % 2 == 0 ? new int[middle] : new int[middle + 1];
            for (int i = middle, j = 0; i < array.Length; i++, j++)
            {
                right[j] = array[i];
            }

            return right;
        }

        private int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Length + right.Length];
            var leftIndex = 0;
            var rightIndex = 0;
            var resultIndex = 0;

            while(leftIndex < left.Length || rightIndex < right.Length)
            {
                if(leftIndex < left.Length && rightIndex < right.Length)
                {
                    if(left[leftIndex] < right[rightIndex])
                    {
                        result[resultIndex] = left[leftIndex];
                        leftIndex++;
                        resultIndex++;
                    }
                    else
                    {
                        result[resultIndex] = right[rightIndex];
                        rightIndex++;
                        resultIndex++;
                    }
                }
                else if(leftIndex < left.Length)
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                    resultIndex++;
                }
                else if(rightIndex < right.Length)
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                    resultIndex++;
                }
            }

            return result;
        }
    }
}
