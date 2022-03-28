using System;
using System.Collections.Generic;

namespace Arrays
{
    public class Tasks : BaseArray
    {
        #region Merge 2 sorted arrays - https://www.interviewbit.com/problems/merge-two-sorted-lists-ii/

        // "listToMerge" should be merged into "list"
        public void MergeTwoSortedArrays(List<int> list, List<int> listToMerge)
        {
            int listIndex = 0, listToMergeIndex = 0;

            while (listToMergeIndex < listToMerge.Count)
            {
                if (listIndex == list.Count)
                {
                    list.Add(listToMerge[listToMergeIndex]);
                    listToMergeIndex++;
                    continue;
                }

                if (listToMerge[listToMergeIndex] < list[listIndex])
                {
                    list.Insert(listIndex, listToMerge[listToMergeIndex]);
                    listToMergeIndex++;
                }
                else
                {
                    listIndex++;
                }
            }
        }

        #endregion
        
        public int GetMaxAbsoluteDifference(int[] arr)
        {
            var max = 0;

            for(int i = 1; i <= arr.Length; i++)
            {
                for(int j = i; j <= arr.Length; j++)
                {
                    var currMax = GetMax(arr, i, j);

                    if(currMax > max)
                    {
                        max = currMax;
                    }
                }
            }

            return max;
        }

        private int GetMax(int[] arr, int i, int j)
        {
            var a = arr[i - 1];
            var b = arr[j - 1];
            var c = GetModule(a - b);
            var d = GetModule(i - j);

            return c + d;
        }

        private int GetModule(int i)
        {
            return i < 0 ? -1 * i : i;
        }

        public List<int[]> MergeIntervals(List<int[]> intervals)
        {
            var result = new List<int[]>();
            var startQueue = FillQueue(intervals, 0);
            var endQueue = FillQueue(intervals, 1);

            var start = 0;
            var end = 0;
            
            while(startQueue.Count > 0 )
            {
                start = startQueue.Dequeue();
                var potentialEnd = endQueue.Dequeue();

                if(potentialEnd < startQueue.Peek())
                {
                    result.Add(new int[] { start, potentialEnd });
                }
                else
                {
                    startQueue.Dequeue();
                    while(endQueue.Count > 0)
                    {
                        potentialEnd = endQueue.Dequeue();
                    }

                    end = endQueue.Dequeue();
                    result.Add(new int[] { start, end });
                }
            }

            return null;
        }

        private Queue<int> FillQueue(List<int[]> intervals, int index)
        {
            var result = new Queue<int>();

            foreach(var i in intervals)
            {
                result.Enqueue(i[index]);
            }

            return result;
        }

        public int GetDuplicate(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            foreach(var a in arr)
            {
                if (!dict.ContainsKey(a))
                {
                    dict.Add(a, 1);
                }
                else
                {                    
                    return a;
                }
            }

            return -1;
        }

        public int GetFirstMissingPositive(int[] arr)
        {
            if (arr.Length == 0)
            {
                return -1;
            }

            int min = GetMin(arr);

            var dict = new Dictionary<int, int>();
            foreach (var a in arr)
            {
                if (a < min && a > 0)
                {
                    min = a;
                }

                if (!dict.ContainsKey(a))
                {
                    dict.Add(a, 1);
                }              
            }

            while (true)
            {
                if (dict.ContainsKey(min))
                {
                    min++;
                }
                else
                {
                    return min;
                }
            }
        }

        private static int GetMin(int[] arr)
        {
            var min = arr[0];
            foreach (var a in arr)
            {
                if (a < min)
                {
                    min = a;
                }
            }
            if (min < 0 || min > 1)
            {
                min = 1;
            }

            return min;
        }

        public List<int> GetInterval(List<int> sortedArr, int num)
        {
            if (sortedArr.Count == 1 && sortedArr[0] == num)
            {
                return new List<int> { 0, 0 };
            }

            var index = FindDigit(sortedArr, 0, sortedArr.Count - 1, num);
            if(index == -1)
            {
                return new List<int> { -1, -1 };
            }

            var leftIndex = FindLeftIndex(sortedArr, num, index);
            var rightIndex = FindRightIndex(sortedArr, num, index);

            return new List<int> { leftIndex, rightIndex };
        }

        private int FindDigit(List<int> sortedArr, int leftIndex, int rightIndex, int num)
        {
            if(leftIndex >= rightIndex)
            {
                return -1;
            }

            var middleIndex = (leftIndex + rightIndex) / 2;

            if(sortedArr[middleIndex] == num)
            {
                return middleIndex;
            }
            if (sortedArr[middleIndex] > num)
            {
                return FindDigit(sortedArr, leftIndex, middleIndex, num);
            }
            else
            {
                return FindDigit(sortedArr, middleIndex + 1, rightIndex, num);
            }
        }

        private int FindLeftIndex(List<int> sortedArr, int num, int index)
        {
            var result = index;
            var i = index - 1;
            while(i >= 0 && sortedArr[i] == num)
            {
                result = i;
                i--;
            }

            return result;
        }

        private int FindRightIndex(List<int> sortedArr, int num, int index)
        {
            var result = index;
            var i = index + 1;
            while (i < sortedArr.Count && sortedArr[i] == num)
            {
                result = i;
                i++;
            }

            return result;
        }        

    }
}
