using System;
using System.Collections.Generic;
using System.Linq;

namespace Hashing
{
    public class Tasks
    {
        public List<List<int>> GetAnagrams(List<string> arr)
        {
            var result = new List<List<int>>();
            var dict = new Dictionary<string, List<int>>();
            for(int i = 0; i < arr.Count; i++)
            {
                var word = arr[i].ToArray();
                Array.Sort(word);
                if (!dict.ContainsKey(new string(word)))
                {
                    dict.Add(new string(word), new List<int> { i + 1 });
                }
                else
                {
                    dict[new string(word)].Add(i + 1);
                }
            }

            foreach(var pair in dict)
            {
                result.Add(pair.Value);
            }

            return result;
        }

        public List<int> twoSum(List<int> arr, int sum)
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Count; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], new List<int> { i + 1 });
                }
                else
                {
                    dict[arr[i]].Add(i + 1);
                }
            }

            var left = int.MaxValue;
            var right = int.MaxValue;
            foreach (var pair in dict)
            {
                var neededValue = sum - pair.Key;

                if (dict.ContainsKey(neededValue))
                {
                    int b = dict[neededValue][0];
                    int a = pair.Value[0];

                    if (a > b)
                    {
                        var temp = a;
                        a = b;
                        b = temp;
                    }

                                                           
                    int i = 0;
                    while (a == b && i < dict[neededValue].Count)
                    {
                        b = dict[neededValue][i];
                        i++;
                    }
                    i = 0;
                    while (a == b && i < pair.Value.Count)
                    {
                        b = pair.Value[i];
                        i++;
                    }

                    if (a < b && (b < right || (b == right && a < left)))
                    {
                        right = b;
                        left = a;
                        continue;
                    }

                }
            }

            if (left == int.MaxValue && right == int.MaxValue)
            {
                return new List<int>();
            }

            return new List<int> { left, right };
        }

        public int GetLengthOfLongestSubstring(string str)
        {
            int maxLength = 0;

            for(int i = 0; i < str.Length; i++)
            {
                var dict = new Dictionary<char, int>();
                var length = 0;
                for(int j = i; j < str.Length; j++)
                {
                    if (!dict.ContainsKey(str[j]))
                    {
                        length++;
                        dict.Add(str[j], 1);
                    }
                    else
                    {                        
                        break;
                    }
                }
                if (length > maxLength)
                {
                    maxLength = length;
                }
            }

            return maxLength;
        }

        public List<int> FindSubstring(string str, List<string> words)
        {
            if(words.Count == 0)
            {
                return new List<int>();
            }
            var result = new List<int>();
            var dict = new Dictionary<string, int>();
            foreach(var w in words)
            {
                if(dict.ContainsKey(w))
                {
                    dict[w]++;
                }
                else
                {
                    dict.Add(w, 1);
                }
            }
            var wordLength = words[0].Length;

            for(int i = 0; i < str.Length; i++)
            {
                var localDict = new Dictionary<string, int>(dict);
                int startIndex = i;
                int endIndex = i + wordLength;
                while (localDict.Count > 0 && startIndex < endIndex && endIndex <= str.Length)
                {                    
                    var word = TakeWord(str, startIndex, endIndex);
                    if (!localDict.ContainsKey(word))
                    {
                        break;
                    }
                    else
                    {
                        if(localDict[word] > 1)
                        {
                            localDict[word]--;
                        }
                        else
                        {
                            localDict.Remove(word);
                        }
                    }

                    startIndex += wordLength;
                    endIndex += wordLength;
                }
                if(localDict.Count == 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private string TakeWord(string str, int start, int end)
        {
            string result = "";
            while(start < end)
            {
                result += str[start];
                start++;
            }

            return result;
        }

        public int GetLongestConsecutive(List<int> arr)
        {
            var set = new Dictionary<int, int>();
            for(int i = 0; i < arr.Count; i++)
            {
                if (!set.ContainsKey(arr[i]))
                {
                    set.Add(arr[i], 1);
                }
            }

            var visitedKeys = new HashSet<int>();
            var max = 0;
            foreach(var el in set)
            {
                var length = 0;
                var i = el.Key;
                while (!visitedKeys.Contains(i) && set.ContainsKey(i))
                {
                    visitedKeys.Add(i);
                    i++;
                    length++;
                }
                i = el.Key - 1;
                while (!visitedKeys.Contains(i) && set.ContainsKey(i))
                {
                    visitedKeys.Add(i);
                    i--;
                    length++;
                }

                if(length > max)
                {
                    max = length;
                }
            }

            return max;
        }
    }
}
