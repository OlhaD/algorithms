using System;
using System.Collections.Generic;

namespace Arrays
{
    public class BinarySearch
    {
        public int Search(int[] arr, int num)
        {
            return Search(arr, 0, arr.Length - 1, num);
        }

        private int Search(int[] arr, int left, int right, int num)
        {
            if(left >= right)
            {
                return -1;
            }

            var middle = (right + left)/2;
            if(arr[middle] == num)
            {
                return middle;
            }

            if (arr[middle] > num)
            {
                return Search(arr, left, middle, num);
            }
            else
            {
                return Search(arr, middle + 1, right, num);
            }
        }

        //public int Solve(List<int> A, int B)
        //{
        //    if (A == null || A.Count == 0)
        //    {
        //        return 0;
        //    }

        //    A.Sort();
        //    var last = A[A.Count - 1];
        //    var first = A[0];

        //    var result = Solve(A, B - 2, 0, A.Count - 1, 0, last - first);

        //    return result;
        //}

        //public int Solve(List<int> A, int rest, int left, int right, int prev, int min)
        //{
        //    if (rest == 0 || right <= 1 || left >= A.Count - 2 || left > right)
        //    {
        //        return min;
        //    }

        //    var middleIndex = (right - left) / 2;
        //    var current = A[middleIndex];

        //    var distToLeft = current - A[middleIndex - 1];
        //    var distToRight = A[middleIndex + 1] - current;

        //    //if(distToLeft == 0 || distToRight == 0)
        //    //{
        //    //    return min;
        //    //}

        //    if (distToLeft > distToRight)
        //    {
        //        return Solve(A, rest - 1, left, middleIndex - 1, current, System.Math.Abs(current - prev));
        //    }
        //    else
        //    {
        //        return Solve(A, rest - 1, middleIndex + 1, right, current, System.Math.Abs(prev - current));
        //    }

        //    return min;
        //}

        public int IfExistsInMatrix(List<List<int>> list, int num)
        {
            int arrIndex = GetListIndex(list, 0, list.Count - 1, num);
            if(arrIndex == -1)
            {
                return 0;
            }

            int result = FindInList(list[arrIndex], 0, list[arrIndex].Count - 1, num);

            return result;
        }

        private int GetListIndex(List<List<int>> list, int left, int right, int num)
        {
            if(left > right)
            {
                return -1;
            }

            var middle = (left + right) / 2;
            if(list[middle][0] == num || middle == right || middle < right && list[middle][0] <= num && list[middle + 1][0] > num)
            {
                return middle;
            }
            if (middle > left && list[middle][0] > num && list[middle - 1][0] <= num)
            {
                return middle - 1;
            }

            if (list[middle][0] > num)
            {
                return GetListIndex(list, left, middle - 1, num);
            }
            else
            {
                return GetListIndex(list, middle + 1, right, num);
            }
        }

        private int FindInList(List<int> list, int left, int right, int num)
        {
            if(left > right)
            {
                return 0;
            }

            var middle = (left + right) / 2;
            if(list[middle] == num)
            {
                return 1;
            }

            if (list[middle] > num)
            {
                return FindInList(list, left, middle - 1, num);
            }
            else
            {
                return FindInList(list, middle + 1, right, num);
            }
        }

        #region GetRange - https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/

        // V1 - O(nLogN) to O(N)
        public int[] SearchRangeV1(int[] nums, int target)
        {
            var foundIndex = FindElementIndex(nums, target, 0, nums.Length - 1);

            if (foundIndex == -1)
            {
                return new int[] { -1, -1 };
            }

            int index = foundIndex;

            // check to the left
            int leftIndex = -1;
            while (foundIndex >= 0 && nums[foundIndex] == target)
            {
                leftIndex = foundIndex;
                foundIndex--;
            }

            // check to the right
            int rightIndex = -1;
            while (index < nums.Length && nums[index] == target)
            {
                rightIndex = index;
                index++;
            }

            return new int[] { leftIndex, rightIndex };
        }

        public int FindElementIndex(int[] nums, int target, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

            var current = (right + left) / 2;
            if (nums[current] == target)
            {
                return current;
            }

            if (nums[current] > target)
            {
                return FindElementIndex(nums, target, left, current - 1);
            }
            else
            {
                return FindElementIndex(nums, target, current + 1, right);
            }
        }

        // V2 - O(nLogN)
        public int[] SearchRangeV2(int[] nums, int target)
        {
            var leftIndex = FindIndex(nums, target, 0, true);
            if (leftIndex == nums.Length || nums[leftIndex] != target)
            {
                return new int[] { -1, -1 };
            }

            var rightIndex = FindIndex(nums, target, leftIndex, false) - 1;

            return new int[] { leftIndex, rightIndex };
        }

        public int FindIndex(int[] nums, int target, int left, bool isLeft)
        {
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = (right + left) / 2;

                if (nums[mid] > target || (isLeft && target == nums[mid]))
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        #endregion
    }
}
