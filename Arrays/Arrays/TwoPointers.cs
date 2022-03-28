using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class TwoPointers : BaseArray
    {
        #region Remove duplicates from sorted array - https://leetcode.com/problems/remove-duplicates-from-sorted-array/solution/
        
        // Time - O(n), Memory - O(1)
        public int RemoveDuplicatesFromSortedArray(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }

        public int RemoveDuplicatesFromSortedArrayV2(List<int> sortedArr)
        {
            if (sortedArr.Count <= 1)
            {
                return sortedArr.Count;
            }

            int newLength = sortedArr.Count;
            for (int i = 0; i < sortedArr.Count - 1; i++)
            {
                if (sortedArr[i] == sortedArr[i + 1])
                {
                    sortedArr.RemoveAt(i);
                    newLength--;
                    i--;
                }
            }

            return newLength;
        }

        public int RemoveDuplicatesFromSortedArrayV3(List<int> sortedArr)
        {
            if (sortedArr.Count == 0 || sortedArr.Count == 1)
            {
                return sortedArr.Count;
            }

            var result = sortedArr.Count;
            for (int i = 0; i < sortedArr.Count; i++)
            {
                for (int j = i + 1; j < sortedArr.Count; j++)
                {
                    if (sortedArr[i] == sortedArr[j])
                    {
                        sortedArr.RemoveAt(i);
                        result--;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return sortedArr.Count;
        }

        #endregion

        #region 3 Sum to zero - https://leetcode.com/problems/3sum/

        // Time - O(n^2), Memory - O(1)
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
            {
                return new List<IList<int>>();
            }

            Array.Sort(nums);

            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                int l = i + 1;
                int r = nums.Length - 1;

                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum > 0)
                    {
                        r--;
                    }
                    else if (sum < 0)
                    {
                        l++;
                    }
                    else if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[l], nums[r] });
                        l++;
                        r--;

                        // To awoid duplicates
                        while (l < r && nums[l] == nums[l - 1])
                        {
                            l++;
                        }
                        while (l < r && nums[r] == nums[r + 1])
                        {
                            r--;
                        }
                    }
                }

                // To awoid duplicates
                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    i++;
                }
            }

            return result.ToList();
        }

        #endregion

        #region 3 Sum to nearest value - https://www.interviewbit.com/problems/3-sum/

        // Time - O(n^2), Memory - O(1)
        public int GetNearestThreeSum(List<int> arr, int num)
        {
            arr.Sort();

            if (arr.Count < 3)
            {
                return -1;
            }

            var closestSum = int.MaxValue;
            var result = 0;

            for (int i = 0; i < arr.Count - 1; i++)
            {
                int l = i + 1;
                int r = arr.Count - 1;

                while (l < r)
                {
                    int sum = arr[i] + arr[l] + arr[r];

                    if (sum == num)
                    {
                        return sum;
                    }

                    if (System.Math.Abs(sum - num) < closestSum)
                    {
                        closestSum = System.Math.Abs(sum - num);
                        result = sum;
                    }
                    if (sum < num)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Sort by color - https://leetcode.com/problems/sort-colors/

        // Time - O(n), Space - O(1)
        public void SortColors(int[] arr)
        {
            int i = 0;
            int start = 0;
            int end = arr.Length - 1;

            while (i <= end)
            {
                if (arr[i] == 0)
                {
                    Swap(arr, i, start);
                    start++;
                    i++;
                }
                else if (arr[i] == 2)
                {
                    Swap(arr, i, end);
                    end--;
                }
                else
                {
                    i++;
                }
            }
        }

        // V2 - count all 0s, 1s and 2s in the array and then rewrite it with it. (example - five 0s, than three 1s, than one 2)
        public void SortColorsV2(int[] arr)
        {
            var colorsCount = new int[3];
            foreach (var color in arr)
            {
                colorsCount[color]++;
            }

            int index = 0;
            for (int i = 0; i <= 2; i++)
            {
                while (colorsCount[i] > 0)
                {
                    arr[index] = i;
                    index++;
                    colorsCount[i]--;
                }
            }
        }

        #endregion
    }
}
