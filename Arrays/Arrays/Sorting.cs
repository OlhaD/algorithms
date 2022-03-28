using System;
using System.Collections.Generic;

namespace Arrays
{
    public class Sorting
    {
        public string GetLargestNumber(int[] arr)
        {
            string[] stringArr = new string[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                stringArr[i] = arr[i].ToString();
            }
            string[] sortedArr = Sort(stringArr);

            string result = string.Join(string.Empty, sortedArr);

            return result.TrimStart('0').Length > 0 ? result.TrimStart('0') : "0";
        }

        public string[] Sort(string[] arr)
        {
            for(int i = 0; i< arr.Length; i++)
            {
                for(int j = 0; j < arr.Length - 1; j++)
                {
                    if(CompareTo(arr[j], arr[j + 1]) > 0)
                    {
                        Swap(ref arr[j], ref arr[j+1]);
                    }
                }
            }

            return arr;
        }

        private int CompareTo(string first, string second)
        {
            string a = first + second;
            string b = second + first;
            
            return Convert.ToInt64(a) < Convert.ToInt64(b) ? 1 : 0;
        }

        private static void Swap(ref string left, ref string right)
        {
            var temp = left;
            left = right;
            right = temp;
        }
    }
}
