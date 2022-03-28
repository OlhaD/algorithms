using System;

namespace Arrays
{
    public class Math
    {
        public int isPower(int number)
        {
            if(number == 1)
            {
                return 1;
            }

            for(int i = 2; i<= number; i++)
            {
                var n = number;
                while(n > 1) {
                    if (n % i == 0 && number != i)
                    {
                        n /= i;
                    }
                    else
                    {
                        break;
                    }
                }

                if(n == 1)
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
            for(int i = 0; i < num; i++)
            {
                arr[i] = i + 1;
            }

            return (int) GetSquareRoot(arr, num, 0, num - 1);
        }

        private int GetSquareRoot(int[] arr, int num, int left, int right)
        {
            if(left >= right)
            {
                return -1;
            }

            int middle = (left + right) / 2;
            int power = arr[middle] * arr[middle];
            if(power == num || power + arr[middle] - num < num)
            {
                return arr[middle];
            }
            if(power < num)
            {
                return GetSquareRoot(arr, num, middle + 1, right);
            }

            return GetSquareRoot(arr, num, left, middle);
        }
    }
}
