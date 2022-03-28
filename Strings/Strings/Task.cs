using System;
using System.Collections.Generic;
using System.Text;

namespace Strings
{
    public class Task
    {
        public int GetDigit(string str)
        {
            str = str.Trim();

            long result = 0;
            var resultStr = string.Empty;
            var lastDigitStr = string.Empty;
            
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '-')
                {
                    return 0;
                }
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(str[i].ToString()) || str[i] == '+' || str[i] == '-')
                {
                    continue;
                }
                else if(long.TryParse(str[i].ToString(), out result))
                {
                    break;
                }
                else
                {
                    return 0;
                }
            }

            for (int i = str.Length - 1; i >= 0; i--)
            {
                var num = str[i];

                if (num == '-' || num == '+')
                {
                    resultStr = num + resultStr;
                    lastDigitStr = resultStr;
                }
                else if (string.IsNullOrWhiteSpace(num.ToString()) || !long.TryParse(num.ToString(), out result))
                {
                    resultStr = string.Empty;

                    continue;
                }
                else
                {
                    resultStr = num + resultStr;
                    lastDigitStr = resultStr;
                }
            }            

            if (resultStr.Length == 0)
            {
                result = long.TryParse(lastDigitStr, out result) ? result : 0;
                return (int)result;
            }
            else
            {
                result = long.TryParse(resultStr, out result) ? result : 0;
            }

            if (result > int.MaxValue || resultStr.Length > 10)
            {
                return int.MaxValue;
            }
            else if (result < int.MinValue || resultStr[0] == '-' && resultStr.Length > 11)
            {
                return int.MinValue;
            }
            else
            {
                return (int)result;
            }
        }

        public string GetLongestCommonPrefix(List<string> arr)
        {
            var longestPrefix = "";
            var tempLongestPrefix = "";
            char currentSymbol = arr[0][0];
            var wordsCount = arr.Count;

            var wordIndex = 0;
            var symbolIndex = 0;

            while(wordIndex < wordsCount)
            {
                var word = arr[wordIndex];
                if(word[symbolIndex] == tempLongestPrefix[symbolIndex])
                {

                }

                wordIndex++;
            }



            
            

            for (int i = 0; i < arr.Count; i++)
            {
                var str = arr[i];

                int prefixIndex = 0;
                for(int j = i+1; j < arr.Count; j++)
                {
                    var strToCompare = arr[j];

                    int lowerLength = str.Length < strToCompare.Length ? str.Length : strToCompare.Length;

                    for(int z = 0; z < lowerLength; z++)
                    {
                        if(str[z] == strToCompare[z])
                        {
                            tempLongestPrefix += str[z];
                        }
                        else
                        {
                            break;
                        }
                    }

                    if(tempLongestPrefix.Length > longestPrefix.Length)
                    {
                        longestPrefix = tempLongestPrefix;
                    }

                    tempLongestPrefix = "";
                }
            }

            return longestPrefix;
        }

        public string CountAndSay(int n)
        {
            if(n < 0)
            {
                return "1";
            }
            if (n == 0)
            {
                return "";
            }
            if (n == 1)
            {
                return "1";
            }

            string result = "";
            string current = "1";
            for (int i = 1; i < n; i++)
            {
                result = "";
                var count = 1;
                var digit = 0;
                for (int j = 0; j < current.Length - 1; j++)
                {
                    digit = (int)char.GetNumericValue(current[j]);
                    if (current[j] == current[j + 1])
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        
                        result += GetCountedString(count, digit);
                        count = 1;
                    }
                }

                result += GetCountedString(count, (int)char.GetNumericValue(current[current.Length - 1]));

                current = result;
            }

            return result;
        }

        private string GetCountedString(int count, int digit)
        {
            return count.ToString() + digit.ToString();
        }

        public int GetSubString(string str, string subString)
        {
            if(subString.Length == 0 || str.Length == 0 || subString.Length > str.Length)
            {
                return -1;
            }
            if(str == subString)
            {
                return 0;
            }

            var subStringIndex = 0;
            var isSubString = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (subString[subStringIndex] == str[i])
                {
                    isSubString = true;
                    subStringIndex++;

                    int j;
                    for (j = i + 1; j < str.Length && subStringIndex < subString.Length; j++)
                    {
                        if(subString[subStringIndex] != str[j])
                        {
                            subStringIndex = 0;
                            isSubString = false;
                            break;
                        }
                        else
                        {
                            subStringIndex++;
                        }
                    }

                    if(j == str.Length && isSubString)
                    {
                        return -1;
                    }
                }

                if (subStringIndex == subString.Length)
                {
                    return isSubString ? i : -1;
                }
            }

            return -1;
        }

        public int ConvertRomanToInt(string str)
        {
            if(str.Length == 1)
            {
                return GetNumericValue(str[0]);
            }

            int result = 0;
            for (var i = 0; i < str.Length - 1; i++)
            {
                var value = GetNumericValue(str[i]);
                var nextValue = GetNumericValue(str[i + 1]);
                if (nextValue > value)
                {
                    result -= value;
                }
                else
                {
                    result += value;
                }
                if(i == str.Length - 2)
                {
                    result += nextValue;
                }
            }

            return result;
        }

        private static int GetNumericValue(char value)
        {
            switch (value)
            {
                case 'M':
                    {
                        return 1000;
                    }
                case 'D':
                    {
                        return 500;
                    }
                case 'C':
                    {
                        return 100;
                    }
                case 'L':
                    {
                        return 50;
                    }
                case 'X':
                    {
                        return 10;
                    }
                case 'V':
                    {
                        return 5;
                    }
                case 'I':
                    {
                        return 1;
                    }
            }

            return 0;
        }

        public string Reverse(string str)
        {
            str = str.Trim();
            var builder = new StringBuilder();
            var wordBuilder = new StringBuilder();
            char lastChar = str[str.Length - 1];

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if(str[i] != ' ')
                {
                    wordBuilder.Insert(0, str[i]);
                    lastChar = str[i];
                }
                else
                {
                    if(lastChar != ' ')
                    {
                        builder.Append(wordBuilder.ToString() + " ");
                        wordBuilder = new StringBuilder();
                    }
                    lastChar = ' ';
                }
            }

            builder.Append(wordBuilder.ToString());

            return builder.ToString();
        }

        #region Reverse String - https://leetcode.com/problems/reverse-string/solution/
        
        // Two Pointers - O(N) - memory, O(1) - space
        public void ReverseString(char[] s)
        {
            for (int left = 0, right = s.Length - 1; left < s.Length && right >= 0; left++, right--)
            {
                if (left >= right)
                {
                    return;
                }

                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
            }
        }

        #endregion
    }
}
