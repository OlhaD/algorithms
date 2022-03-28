using System;
using System.Collections.Generic;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Tasks();
            var result = tasks.SortColors(new int[] { 1, 2, 0});

            Console.WriteLine(result);
            foreach(var a in result)
            {
                Console.Write(a + " ");
            }
        }

        public int solve(List<int> numbers)
        {
            long result = 0;

            GetNumberOfInversions(numbers, 0, ref result);

            return (int)(result % (System.Math.Pow(10, 9) + 7));
        }

        private void GetNumberOfInversions(List<int> numbers, int leftIndex, ref long result)
        {
            for (int i = leftIndex; i < numbers.Count - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    Swap(numbers, i, i + 1);
                    result++;
                    GetNumberOfInversions(numbers, leftIndex - 1 >= 0 ? leftIndex - 1 : 0, ref result);
                    //result = GetNumberOfInversions(numbers, leftIndex, result + 1);
                }
                else
                {
                    leftIndex++;
                }
            }
        }

        private void Swap(List<int> numbers, int firstIndex, int secondIndex)
        {
            var temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }

        public static string largestNumber(List<int> arr1)
        {
            var a = new List<string>();
            for (int i = 0; i < arr1.Count; i++)
            {
                a.Add(arr1[i].ToString());
            }

            a.Sort(new DigitComparer());

            var result = string.Join("", a);
            result = result.TrimStart('0');

            return result.Length > 0 ? result : "0";
        }
    }

    public class DigitComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return (y + x).CompareTo(x + y);

            string firstStr = x.ToString() + y.ToString();
            string secondStr = y.ToString() + x.ToString();


            
            for (int i = 0; i < firstStr.Length; i++)
            {
                if (firstStr[i] == secondStr[i])
                {
                    continue;
                }

                if (firstStr[i] > secondStr[i])
                {
                    return -1;
                }

                return 1;
            }

            return 0;
        }

        private static int GetDigitOfStringByIndex(string @string, int index)
        {
            return int.Parse(@string[index].ToString());
        }
    }
}
