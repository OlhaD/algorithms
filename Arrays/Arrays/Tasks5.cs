using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class Tasks5
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            // add to dictionary
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            var min = int.MaxValue;
            var values = new List<int>();
            foreach (var pair in dict)
            {
                if (values.Count < k)
                {
                    if (pair.Value < min)
                    {
                        min = pair.Value;
                    }
                    values.Add(pair.Value);
                }
                else
                {
                    if (pair.Value <= min)
                    {
                        continue;
                    }

                    // reset min element
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (values[i] == min)
                        {
                            values[i] = pair.Value;

                            // set old min value in result to pair.Key;
                            var keys = dict.Where(x => x.Value == min);

                            min = values[i];
                            break;
                        }
                    }
                    // find new min
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (values[i] < min)
                        {
                            min = values[i];
                        }
                    }
                }
            }

            // get keys by values
            var result = new List<int>();
            values = values.Distinct().ToList();
            for (int i = 0; i < values.Count; i++)
            {
                var value = values[i];
                var keys = dict.Where(x => x.Value == value).Select(x => x.Key).ToList();
                foreach (var key in keys)
                {
                    if (result.Count == k)
                    {
                        return result;
                    }

                    result.Add(key);
                }
            }

            return result;
        }

        public int KthSmallest(int[,] matrix, int k)
        {
            var length = matrix.GetLength(0);

            var dict = new SortedDictionary<int, int>();
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    if (dict.ContainsKey(matrix[x, y]))
                    {
                        dict[matrix[x, y]]++;
                    }
                    else
                    {
                        dict.Add(matrix[x, y], 1);
                    }
                }
            }

            int count = 0;
            foreach (var pair in dict)
            {
                if (count + pair.Value >= k || pair.Value >= k)
                {
                    return pair.Key;
                }
                count += pair.Value;
            }

            return -1;
        }
    }
}
