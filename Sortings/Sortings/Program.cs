using System;
using System.Collections.Generic;

namespace Sortings
{
    class Program
    {
        public static int maxSubArray(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            var maxGlobal = arr[0];
            var maxCurrent = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                maxCurrent = Math.Max(maxCurrent + arr[i], arr[i]);
                maxGlobal = Math.Max(maxCurrent, maxGlobal);
            }

            return maxGlobal;
        }

        static void Main(string[] args)
        {
            var array = new[] { 1, 2, 3, 4, -10, 100 };
            Console.WriteLine(maxSubArray(array));
            //var array = new[] { 1, 5, 4, 3, 1, 1, 7 };
            //Print(array);

            //var sorter = new QuickSort();
            //var sortedArray = sorter.Sort(array);
            //Print(sortedArray);
        }

        static void Print(int[] array)
        {
            foreach(var element in array)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }
    }
}
