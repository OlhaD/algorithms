using System.Collections.Generic;

namespace Arrays
{
    public class Tasks2
    {
        public void MergeSortedArrays(List<List<int>> lists)
        {
            var result = lists[0];

            for(int i = 1; i < lists.Count; i++)
            {
                var list = result;
                var nextList = lists[i];

                int listIndex = 0, nextListIndex = 0;

                while (nextListIndex < nextList.Count)
                {
                    if (listIndex == list.Count)
                    {
                        list.Add(nextList[nextListIndex]);
                        nextListIndex++;
                        continue;
                    }
                    
                    if (nextList[nextListIndex] < list[listIndex])
                    {
                        list.Insert(listIndex, nextList[nextListIndex]);
                        nextListIndex++;
                    }
                    else
                    {
                        listIndex++;
                    }
                }
            }

            var b = result;
        }

        public int RemoveDuplicates(List<int> list)
        {
            if(list.Count < 2)
            {
                return list.Count;
            }

            int size = 0;
            for(int i = 1; i < list.Count; i++)
            {
                if(list[i] != list[size])
                {
                    list[++size] = list[i];
                }
            }

            while(list.Count != size + 1)
            {
                list.RemoveAt(list.Count - 1);
            }

            return list.Count;
        }

        public int RemoveDuplicatesMax2(List<int> sortedList)
        {
            if (sortedList.Count < 2)
            {
                return sortedList.Count;
            }

            int size = 0;
            var isFirst = true;
            for (int i = 1; i < sortedList.Count; i++)
            {
                if (sortedList[i] != sortedList[size])
                {
                    var a = size + 2;
                    sortedList[a] = sortedList[i];                    
                }
            }

            while (sortedList.Count != size + 1)
            {
                sortedList.RemoveAt(sortedList.Count - 1);
            }

            return sortedList.Count;
        }

        public int GetMaxArea(List<int> list)
        {
            int i = 0;
            int j = list.Count - 1;
            int maxArea = 0;

            while(i <= j)
            {
                var square = (j - i) * System.Math.Min(list[i], list[j]);
                if(square > maxArea)
                {
                    maxArea = square;
                }
                if(list[i] >= list[j])
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return maxArea;
        }

        public int GetKthsmallest(List<int> arr, int k)
        {
            if(k > arr.Count)
            {
                return -1;
            }

            var dict = new Dictionary<int, int>();

            int min = int.MaxValue;
            int max = int.MinValue;
            for(int i = 0; i < arr.Count; i++)
            {
                if(arr[i] < min)
                {
                    min = arr[i];
                }
                if(arr[i] > max)
                {
                    max = arr[i];
                }
                if (dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]]++;
                }
                else
                {
                    dict.Add(arr[i], 1);
                }
            }

            for(int i = min, j = 0; i <= max && j <= k; i++)
            {
                if (dict.ContainsKey(i))
                {
                    j += dict[i];
                }

                if (j >= k)
                {
                    return i;
                }
            }

            return min;
        }

        public int GetKthsmallestV2(List<int> arr, int k)
        {
            if (k > arr.Count)
            {
                return -1;
            }

            var arrCopy = new List<int>();
            arrCopy = arr;

            arrCopy.Sort();
            for(int i = 0, j = 1; i < arr.Count && j <= k; i++, j++)
            {
                if(j == k)
                {
                    return arr[i];
                }
            }

            return -1;
        }

        public int GetCountOfRanges(List<int> arr, int left, int right)
        {
            if(arr.Count == 0)
            {
                return 0;
            }
            if (arr.Count == 1)
            {
                return arr[0] > left && arr[0] < right ? 1 : 0;
            }

            int result = 0;

            int i = 0;
            while (i < arr.Count)
            {
                if(arr[i] > right)
                {
                    i++;
                    continue;
                }

                int tempSum = arr[i];
                if (tempSum >= left && tempSum <= right)
                {
                    result++;
                }
                for (int j = i + 1; j < arr.Count; j++)
                {
                    tempSum += arr[j];
                    if(tempSum >= left && tempSum <= right)
                    {
                        result++;
                    }
                    if(tempSum > right)
                    {
                        break;
                    }
                }
                i++;
            }

            return result;
        }

        // memory limit
        public List<int> nextGreater(List<int> arr)
        {
            var dict = new Dictionary<int, int>();
            int i = 0;
            foreach (var el in arr)
            {
                dict.Add(i, el);
                i++;
            }

            var result = new List<int>();
            int j = 0;
            for (i = 0, j = i + 1; i < arr.Count && j < arr.Count;)
            {
                while (j < arr.Count)
                {
                    if (arr[i] < dict[j])
                    {
                        result.Add(dict[j]);
                        break;
                    }
                }
                if (result.Count <= i)
                {
                    result.Add(-1);
                }
            }

            return result;
        }
    }
}