using System;
using System.Collections.Generic;
using System.Text;

namespace Math
{
    public class Tasks
    {
        public int isPower(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            for (int i = 2; i <= number; i++)
            {
                var n = number;
                while (n > 1)
                {
                    if (n % i == 0 && number != i)
                    {
                        n /= i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (n == 1)
                {
                    return 1;
                }

            }

            return 0;
        }

        public int GetNumberByTitle(string str)
        {
            var result = 0;
            for (int i = str.Length - 1, j = 0; i >= 0; i--, j++)
            {
                var num = char.ToUpper(str[i]) - 64;

                result += (int)System.Math.Pow(26, j) * num;
            }

            return result;
        }

        public int GetSquareRoot(int num)
        {
            var arr = new int[num];
            for (int i = 0; i < num; i++)
            {
                arr[i] = i + 1;
            }

            return (int)GetSquareRoot(arr, num, 0, num - 1);
        }

        private int GetSquareRoot(int[] arr, int num, int left, int right)
        {
            if (left >= right)
            {
                return -1;
            }

            int middle = (left + right) / 2;
            int power = arr[middle] * arr[middle];
            if (power == num || power + arr[middle] - num < num)
            {
                return arr[middle];
            }
            if (power < num)
            {
                return GetSquareRoot(arr, num, middle + 1, right);
            }

            return GetSquareRoot(arr, num, left, middle);
        }

        public int Reverse(int num)
        {
            var isNegative = num < 0;
            if (isNegative) num = -1 * num;
            long result = 0;

            long temp = num;
            var power = 0;
            while (temp > 0)
            {
                temp /= 10;
                power++;
            }

            var i = 0;
            temp = num;
            while (temp > 0 && i < power)
            {
                var newValue = temp % 10;
                result *= 10;
                result += newValue;
                temp /= 10;
                i++;
            }

            if(result >= int.MaxValue)
            {
                return 0;
            }

            return isNegative ? -1 * (int)result : (int)result;
        }

        public int GetSumOfHammingDistances(List<int> numbers)
        {
            long result = 0;
            for(int i = 0; i < numbers.Count; i++)
            {
                var current = numbers[i];
                for(int j = i + 1; j < numbers.Count; j++)
                {
                    var hammingDistance = GetHummingDistance(current, numbers[j]);
                    result += hammingDistance;
                }
            }

            return (int)(result * 2 % 1000000007);
        }

        private int GetHummingDistance(int first, int second)
        {
            //var firstBinary = Convert.ToString(Convert.ToInt32(first.ToString(), 10), 2);// ToBinary(first);
            //var secondBinary = Convert.ToString(Convert.ToInt32(second.ToString(), 10), 2);//ToBinary(second);

            var firstBinary = ToBinary(first);
            var secondBinary = ToBinary(second);

            var result = 0;
            
            var shotestLength = firstBinary.Length > secondBinary.Length ? secondBinary.Length : firstBinary.Length;
            for (int i = shotestLength - 1; i >= 0; i--)
            {
                if(firstBinary[i] != secondBinary[i])
                {
                    result++;
                }
            }
            result += System.Math.Abs(firstBinary.Length - secondBinary.Length);

            return result;
        }

        private int[] ToBinary(int first)
        {
            var result = new int[16];
            var rest = first;
            int i = result.Length - 1;
            while(rest != 0 && i >= 0)
            {
                if(rest % 2 == 0)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = 1;
                }
                rest /= 2;
                i--;
            }

            return result;
        }
    }
}
