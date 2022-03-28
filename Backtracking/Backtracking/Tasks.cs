using System;
using System.Collections.Generic;

namespace Backtracking
{
    public class Tasks
    {
        public List<List<int>> combine(int n, int k)
        {
            var result = new List<List<int>>();
            var subset = new List<int>();
            GetCombination(result, subset, n, k, 1);

            return result;
        }

        private void GetCombination(List<List<int>> result, List<int> subset, 
            int n, int k, int index)
        {
            if(subset.Count == k)
            {
                result.Add(new List<int>(subset));
            }

            for(int i = index; i <= n; i++)
            {
                subset.Add(i);

                GetCombination(result, subset, n, k, i + 1);

                subset.RemoveAt(subset.Count - 1);
            }
        }

        public List<List<int>> GetPermutations(List<int> arr)
        {
            var result = new List<List<int>>();

            MakePermutations(result, arr, 0);

            return result;
        }

        private void MakePermutations(List<List<int>> result, List<int> arr, int index)
        {
            if(index == arr.Count - 1)
            {
                result.Add(new List<int>(arr));
            }

            for(int i = index; i < arr.Count; i++)
            {
                Swap(arr, i, index);
                MakePermutations(result, arr, index + 1);
                Swap(arr, i, index);
            }
        }

        private static void Swap(List<int> arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // Phone
        public List<string> GetLetterCombinations(string numbers)
        {
            var dict = new Dictionary<int, char[]>();
            dict.Add(0, new char[] { '0' });
            dict.Add(1, new char[] { '1' });
            dict.Add(2, new char[] { 'a', 'b', 'c' });
            dict.Add(3, new char[] { 'd', 'e', 'f' });
            dict.Add(4, new char[] { 'g', 'h', 'i' });
            dict.Add(5, new char[] { 'j', 'k', 'l' });
            dict.Add(6, new char[] { 'm', 'n', 'o' });
            dict.Add(7, new char[] { 'p', 'q', 'r', 's' });
            dict.Add(8, new char[] { 't', 'u', 'v' });
            dict.Add(9, new char[] { 'w', 'x', 'y', 'z' });

            var result = new List<string>();
            GetLetterCombinations(numbers, dict, 0, "", result);

            return result;
        }

        private void GetLetterCombinations(string numbers, Dictionary<int, char[]> dict, int start, string str, List<string> result)
        {
            if(start == numbers.Length)
            {
                result.Add(str);
                return;
            }

            var number = (int)char.GetNumericValue(numbers[start]);
            var chars = dict[number];

            for (int i = 0; i < chars.Length; i++)
            {
                str += chars[i];
                GetLetterCombinations(numbers, dict, start + 1, str, result);
                str = str.Remove(start);
            }
        }

        public List<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            GenerateParenthesis(n, "", 0, 0, result);

            return result;
        }

        private void GenerateParenthesis(int n, string current, int openCount, int closeCount, List<string> result)
        {
            if(current.Length == n * 2 && openCount == n && closeCount == n)
            {
                result.Add(current);
                return;
            }

            if(openCount > closeCount)
            {
                current += ")";
                GenerateParenthesis(n, current, openCount, closeCount + 1, result);
                current = current.Remove(current.Length - 1);
            }

            if(openCount < n)
            {
                current += "(";
                GenerateParenthesis(n, current, openCount + 1, closeCount, result);
                current = current.Remove(current.Length - 1);
            }
        }
    }
}
