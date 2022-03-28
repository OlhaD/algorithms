using System;
using System.Collections.Generic;

namespace BitManipulations
{
    public class Tasks
    {
        public string ConvertToBinary(int number)
        {
            var arr = new int[16];
            var rest = number;
            var i = arr.Length - 1;
            while (rest != 0 && i >= 0)
            {
                if (rest % 2 == 0)
                {
                    arr[i] = 0;
                }
                else
                {
                    arr[i] = 1;
                }
                rest /= 2;
                i--;
            }

            if(number < 0)
            {
                arr = HandleNegative(arr);
            }

            string result = "";
            for (i = 0; i < arr.Length; i++)
            {
                result += arr[i];
            }

            return result;
        }

        private int[] HandleNegative(int[] arr)
        {
            arr = InvertNumber(arr);
            arr = AddOne(arr);

            return arr;
        }

        private int[] InvertNumber(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] == 0 ? 1 : 0;
            }

            return arr;
        }

        private char[] InvertDecimal(char[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i] == '0' ? '1' : '0';
            }

            return str;
        }

        private int[] AddOne(int[] arr)
        {
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                if(arr[i] == 1)
                {
                    arr[i] = 0;
                }
                else
                {
                    arr[i] = 1;

                    return arr;
                }
            }

            return arr;
        }

        private char[] AddOne(char[] arr)
        {
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == '1')
                {
                    arr[i] = '0';
                }
                else
                {
                    arr[i] = '1';

                    return arr;
                }
            }

            return arr;
        }

        public int ConvertToDecimal(string binary)
        {
            var isNegative = false;
            if(binary[0] == '1')
            {
                isNegative = true;
                binary = ExtendNegativeString(binary);
                binary = ConvertNegativeToDecimal(binary);
            }

            var result = 0;
            for(int i = binary.Length - 1, j = 0; i >= 0; i--, j++)
            {
                result += (int) (char.GetNumericValue(binary[i]) * Math.Pow(2, j));
            }

            return isNegative ? -result : result;
        }

        private string ExtendNegativeString(string binary)
        {
            var lengthDiff = 16 - binary.Length;
            for(int i = 0; i < lengthDiff; i++)
            {
                binary = '1' + binary;
            }

            return binary;
        }

        private string ConvertNegativeToDecimal(string binary)
        {
            var inverted = InvertDecimal(binary.ToCharArray());
            var plusOne = AddOne(inverted);

            return new string(plusOne);
        }

        public int GetNumSetBits(uint num)
        {
            string binary = "";
            var rest = num;
            while(rest != 0)
            {
                if(rest % 2 == 0)
                {
                    binary = "0" + binary;
                }
                else
                {
                    binary = "1" + binary;
                }

                rest /= 2;
            }

            int result = 0;
            foreach(var c in binary)
            {
                if(c == '1')
                {
                    result++;
                }
            }

            return result;
        }

        public long reverse(long dec)
        {
            // get binary
            var bin = "";
            var rest = dec;
            while(rest != 0)
            {
                if(rest % 2 == 0)
                {
                    bin = "0" + bin;
                }
                else
                {
                    bin = "1" + bin;
                }

                rest /= 2;
            }

            // Reverse string
            var s = bin;
            if(s.Length < 32)
            {
                // extend string
                var diff = 32 - s.Length;
                for(int i = 0; i < diff; i++)
                {
                    s = '0' + s;
                }
            }

            var rotatedStr = new char[32];
            for (int i = 0, j = s.Length - 1; i < rotatedStr.Length && j >= 0; i++, j--)
            {
                rotatedStr[i] = s[j];
                rotatedStr[j] = s[i];
            }

            // Convert to decimal
            long result = 0;
            for(int i = rotatedStr.Length - 1, j = 0; i >=0; i--, j++)
            {
                result += (long)(char.GetNumericValue(rotatedStr[i]) * Math.Pow(2, j));
            }

            return result;
        }

        public int GetSingleNumber(int[] arr)
        {
            var proxy = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                proxy ^= arr[i];
            }

            return proxy;
        }

        public int FindMinXor(List<int> arr)
        {
            if(arr.Count < 2)
            {
                return 0;
            }

            arr.Sort();
            var min = int.MaxValue;

            for (int i = 0; i < arr.Count - 1; i++)
            {
                var temp = arr[i] ^ arr[i + 1];
                if (temp < min)
                {
                    min = temp;
                }
            }
                       
            return min;
        }

        public int SingleOfTrippleNumbers(List<int> arr)
        {
            var num = 0;
            for(int i = 1; i < arr.Count; i++)
            {
                num += arr[i - 1] & arr[i];
            }

            return num;
        }
    }
}

