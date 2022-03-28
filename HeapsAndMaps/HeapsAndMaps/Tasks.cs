using System;
using System.Collections.Generic;
using System.Linq;

namespace HeapsAndMaps
{
    public class Tasks
    {
        public int GetEatenChocolatesCount(int attempts, List<int> bags)
        {
            var dict = new SortedDictionary<int, int>();
            foreach (var bag in bags)
            {
                if (dict.ContainsKey(bag))
                {
                    dict[bag]++;
                }
                else
                {
                    dict.Add(bag, 1);
                }
            }

            long result = 0;
            var i = 0;
            while (i < attempts)
            {
                var last = dict.Last();
                var max = last.Key;
                result += max;

                if (last.Value == 1)
                {
                    dict.Remove(max);

                    var next = max / 2;
                    if (dict.ContainsKey(next))
                    {
                        dict[next]++;
                    }
                    else
                    {
                        dict.Add(next, 1);
                    }
                }
                else
                {
                    dict[max]--;
                }
                i++;
            }

            return (int)(result % (int)(Math.Pow(10, 9) + 7));
        }

        public ListNode MergeKLists(List<ListNode> lists)
        {
            var dict = new SortedDictionary<int, int>();
            foreach(var list in lists)
            {
                var curr = list;
                while(curr != null)
                {
                    if (dict.ContainsKey(curr.val))
                    {
                        dict[curr.val]++;
                    }
                    else
                    {
                        dict.Add(curr.val, 1);
                    }
                    curr = curr.next;
                }
            }

            ListNode result = null;
            var current = result;
            foreach(var pair in dict)
            {
                if(result == null)
                {
                    result = new ListNode(pair.Key);
                    current = result;

                    int value = pair.Value;
                    while(value != 1)
                    {
                        current.next = new ListNode(pair.Key);
                        current = current.next;
                        value--;
                    }
                }
                else
                {
                    current.next = new ListNode(pair.Key);
                    current = current.next;

                    var value = pair.Value;
                    while (value != 1)
                    {
                        current.next = new ListNode(pair.Key);
                        current = current.next;
                        value--;
                    }
                }
            }

            return result;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; next = null; }
        }

        public List<int> GetDistinctNumbersInWindow(List<int> arr, int window)
        {
            var dict = new Dictionary<int, int>();
            var result = new List<int>();

            var uniqueCount = 0;
            // dict should contains 'window' elements
            for(int i = 0; i < window && i < arr.Count; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]]++;
                }
                else
                {
                    uniqueCount++;
                    dict.Add(arr[i], 1);
                }
            }
            result.Add(uniqueCount);

            for(int i = 1; i + window <= arr.Count; i++)
            {
                var lastInWindow = arr[i + window - 1];

                // remove first from dict
                if(dict[arr[i - 1]] == 1)
                {
                    uniqueCount--;
                    dict.Remove(arr[i - 1]);
                }
                else
                {
                    dict[arr[i - 1]]--;
                }

                // add last to dict
                if (!dict.ContainsKey(lastInWindow))
                {
                    uniqueCount++;
                    dict.Add(lastInWindow, 1);
                }
                else
                {
                    dict[lastInWindow]++;
                }

                result.Add(uniqueCount);
            }

            return result;
        }
    }
}
