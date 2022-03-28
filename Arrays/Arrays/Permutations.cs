using System;
using System.Collections.Generic;

namespace Arrays
{
    public class Permutations
    {
        private int[] _origin;
        private Dictionary<int, int[]> _permutationsDict;
        private int _dictCount = 1;

        public Permutations(int[] nums)
        {
            _origin = nums;
            _permutationsDict = new Dictionary<int, int[]>();

            var permutations = new List<int[]>();
            GetAllPermutations(_origin, 0, _origin.Length - 1, _permutationsDict);
            /*int count = 1;
            foreach(var perm in permutations){
                _permutationsDict.Add(count, perm);
                count++;
            }*/
            var a = 56;
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return _origin;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            if (_permutationsDict.Count == 0)
            {
                return _origin;
            }

            var random = new Random();
            var id = random.Next(1, _permutationsDict.Count);
            return _permutationsDict[3];
        }

        private void GetAllPermutations(int[] arr, int left, int right, Dictionary<int, int[]> result)
        {
            if (left == right)
            {
                //result.Add(arr);
                if (!result.ContainsKey(_dictCount))
                {
                    var newArr = new int[arr.Length];
                    Array.Copy(arr, newArr, arr.Length);
                    result.Add(_dictCount, newArr);
                    _dictCount++;
                }
            }
            else
            {
                for (int i = left; i <= right; i++)
                {
                    arr = Swap(arr, left, i);
                    GetAllPermutations(arr, left + 1, right, result);
                    arr = Swap(arr, left, i);
                }
            }
        }

        private int[] Swap(int[] arr, int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;

            return arr;
        }
    }
}
