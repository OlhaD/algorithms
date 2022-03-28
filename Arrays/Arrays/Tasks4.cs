using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays
{
    public class Tasks4
    {
        // https://www.interviewbit.com/problems/inversion-count-in-an-array/?ref=random-problem
        public int GetNumberOfInversions(List<int> numbers)
        {
            long result = 0;

            result = GetNumberOfInversions(numbers, 0, result);

            return (int)(result % (System.Math.Pow(10, 9) + 7));
        }

        private long GetNumberOfInversions(List<int> numbers, int leftIndex, long result)
        {
            for(int i = leftIndex; i < numbers.Count - 1; i++)
            {
                if(numbers[i] > numbers[i + 1])
                {
                    Swap(numbers, i, i + 1);
                    //result = GetNumberOfInversions(numbers, leftIndex - 1 >= 0 ? leftIndex - 1 : 0, result + 1);
                    result = GetNumberOfInversions(numbers, leftIndex, result + 1);
                }
                else
                {
                    //leftIndex++;
                }
            }

            return result;
        }

        private void Swap(List<int> numbers, int firstIndex, int secondIndex)
        {
            var temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }

        public List<int> GetSubstringsOfWords(string str, List<string> words)
        {
            var dict = FillDictionary(words);
            var result = new List<int>();

            var index = 0;
            var wordLen = words[0].Length;

            var word = "";
            for (int i = index; i < str.Length;)
            {
                word += str[i];

                if (word.Length == wordLen)
                {
                    if (dict.ContainsKey(word))
                    {
                        if (dict[word] != 1)
                        {
                            dict[word]--;
                        }
                        else
                        {
                            dict.Remove(word);
                        }
                        i++;
                    }
                    else
                    {
                        dict = FillDictionary(words);
                        index++;
                        i = index;
                    }
                    word = "";

                    if (dict.Count == 0)
                    {
                        result.Add(index);
                        dict = FillDictionary(words);
                        index++;
                        i = index;
                    }
                }
                else {
                    i++;
                }
            }

            return result;
        }

        private Dictionary<string, int> FillDictionary(List<string> words)
        {
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 1);
                }
                else
                {
                    dict[word]++;
                }
            }

            return dict;
        }

        public int FindMaximumGap(List<int> list)
        {
            var max = FindMaximumGap(list, 0, list.Count - 1);

            return max;
        }

        private int FindMaximumGap(List<int> list, int left, int right)
        {
            if(left > right)
            {
                return -1;
            }

            if(list[right] >= list[left])
            {
                return right - left;
            }

            FindMaximumGap(list, left + 1, right);
            FindMaximumGap(list, left, right - 1);

            return -1;
        }

        public int FindMaximumGapV2(List<int> list)
        {
            var max = 0;
            for(int i = 0; i < list.Count; i++)
            {
                for (int j = list.Count - 1; j > i; j--)
                {
                    if(list[j] >= list[i] && (j - i) > max)
                    {
                        max = j - i;
                        break;
                    }
                }
            }

            return max;
        }

        public int FindMaximumGapV3(List<int> list)
        {
            if(list.Count == 0)
            {
                return -1;
            }
            if(list.Count == 1)
            {
                return 0;
            }

            var minArr = new int[list.Count];
            minArr[0] = list[0];
            var maxArr = new int[list.Count];
            maxArr[list.Count - 1] = list[list.Count - 1];

            for(int i = 1; i < list.Count; i++)
            {
                minArr[i] = list[i] < minArr[i - 1] ? list[i] : minArr[i - 1];
            }

            for (int i = list.Count - 2; i >= 0; i--)
            {
                maxArr[i] = list[i] > maxArr[i + 1] ? list[i] : maxArr[i + 1];
            }


            var minIndex = 0;
            var maxIndex = 0;
            var max = 0;

            while(minIndex < list.Count && maxIndex < list.Count)
            {
                if(minArr[minIndex] <= maxArr[maxIndex])
                {
                    max = System.Math.Max(max, maxIndex - minIndex);
                    maxIndex++;
                }
                else
                {
                    minIndex++;
                }
            }

            return max == 0 ? -1 : max;
        }

        public int LongestSubstring(string s, int k)
        {
            var set = FillSet(s, k);

            int max = 0;
            int currMax = 0;
            foreach (var c in s)
            {
                if (set.Contains(c))
                {
                    currMax++;
                    if (currMax > max)
                    {
                        max = currMax;
                    }
                }
                else
                {
                    currMax = 0;
                }
            }

            return max;
        }

        private HashSet<char> FillSet(string s, int k)
        {
            var characters = s.ToArray();
            Array.Sort(characters);

            var result = new HashSet<char>();
            if(s.Length == 1 && k == 1)
            {
                result.Add(s[0]);
                return result;
            }

            int count = 0;
            for (int i = 1; i < characters.Length; i++)
            {
                if (characters[i] == characters[i - 1])
                {
                    count++;
                }
                                
                if (count + 1 >= k)
                {
                    result.Add(characters[i - 1]);
                }

                if (characters[i] != characters[i - 1])
                {
                    count = 0;
                }
            }

            return result;
        }
    }
}
