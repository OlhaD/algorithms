using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class Tasks3
    {
        public List<int> wave(List<int> arr)
        {
            if(arr.Count <= 1)
            {
                return arr;
            }

            arr.Sort();

            for(int i = 1; i < arr.Count;)
            {
                var temp = arr[i];
                arr[i] = arr[i - 1];
                arr[i - 1] = temp;

                i += 2;
            }

            return arr;
        }

        public List<List<int>> GetPascalTriangel(int num)
        {
            var result = new List<List<int>>();

            var c = 1;
            var prev = new int[num];
            while (c <= num)
            {
                var current = new int[c];
                current[0] = 1;
                current[current.Length - 1] = 1;

                if (c <= 2)
                {
                    c++;
                    result.Add(new List<int>(current));
                    prev = current;
                    continue;
                }

                for (int i = 1, j = current.Length - 2; i <= j; i++, j--)
                {
                    current[i] = prev[i] + prev[i - 1];
                    current[current.Length - i - 1] = current[i];
                }

                result.Add(new List<int>(current));
                prev = current;
                c++;
            }

            return result;
        }

        public int GetMinimumPath(List<List<int>> arr)
        {
            if(arr == null && arr.Count == 0)
            {
                return 0;
            }

            int result = arr[0][0];
            var prevIndex = 0;

            for (int i = 1; i < arr.Count; i++)
            {
                var list = arr[i];

                var potentialMinIndex = GetIndexOfMinChild(prevIndex, list);

                int j = prevIndex + 1;
                while (j < list.Count && list[j] == list[prevIndex])
                {
                    int min = GetIndexOfMinChild(j, list);
                    if (list[min] < list[potentialMinIndex])
                    {
                        potentialMinIndex = min;
                    }

                    j++;
                }

                prevIndex = potentialMinIndex;
                result += list[prevIndex];

            }

            return result;
        }

        private static int GetIndexOfMinChild(int prevIndex, List<int> list)
        {
            //var left = int.MaxValue;
            var bottom = int.MaxValue;
            var right = int.MaxValue;

            //if (prevIndex - 1 >= 0)
            //{
            //    left = list[prevIndex - 1];
            //}
            bottom = list[prevIndex];
            if (prevIndex + 1 < list.Count)
            {
                right = list[prevIndex + 1];
            }

            //if (left <= bottom && left <= right)
            //{
            //    prevIndex--;
            //}
            //else 
            if (right <= bottom)
            {
                prevIndex++;
            }

            return prevIndex;
        }

        public List<string> GetPrettyJSON(string str)
        {
            var result = new List<string>();

            result.Add(str[0].ToString());
            var shift = 1;

            var startIndex = 1;
            while(startIndex < str.Length)
            {
                var isClosingTag = IsClosingTag(str[startIndex]);
                if (isClosingTag)
                {
                    shift--;
                }

                // process a row
                var rowStb = new StringBuilder();
                int i = 1;
                while(i <= shift)
                {
                    rowStb.Append("\t");
                    i++;
                }

                if (isClosingTag)
                {
                    if(startIndex + 1 < str.Length && str[startIndex + 1] == ',')
                    {
                        result.Add(rowStb.Append(str[startIndex]).Append(str[startIndex + 1]).ToString());
                        startIndex += 2;
                        continue;
                    }

                    result.Add(rowStb.Append(str[startIndex]).ToString());
                    startIndex++;
                    continue;
                }

                var isOpeningTag = IsOpeningTag(str[startIndex]);
                if (isOpeningTag)
                {
                    shift++;
                    result.Add(rowStb.Append(str[startIndex]).ToString());
                    startIndex++;
                    continue;
                }

                for (; startIndex < str.Length; startIndex++)
                {
                    rowStb.Append(str[startIndex]);
                    if (str[startIndex] == ',' || (startIndex + 1 < str.Length && (IsClosingTag(str[startIndex + 1]) || IsOpeningTag(str[startIndex + 1] ))))
                    {
                        startIndex++;
                        break;
                    }
                }

                result.Add(rowStb.ToString());
            }

            return result;
        }

        private bool IsClosingTag(char tag)
        {
            return tag == '}' || tag == ']';
        }

        private bool IsOpeningTag(char tag)
        {
            return tag == '{' || tag == '[';
        }

        public int IsValidSudoku(List<string> list)
        {
            if (list.Count == 0)
            {
                return 0;
            }

            // validate rows
            var set = new HashSet<char>();
            foreach (var row in list)
            {
                foreach (var symbol in row)
                {
                    if (symbol != '.')
                    {
                        if (set.Contains(symbol))
                        {
                            return 0;
                        }
                        set.Add(symbol);
                    }
                }
                set.Clear();
            }

            // validate columns
            var length = list[0].Length;
            var i = 0;
            set.Clear();
            while (i < length)
            {
                foreach (var row in list)
                {
                    var symbol = row[i];
                    if (symbol != '.')
                    {
                        if (set.Contains(symbol))
                        {
                            return 0;
                        }
                        set.Add(symbol);
                    }
                }
                set.Clear();

                i++;
            }

            // validate cells
            var left = 0;
            var right = 2;
            var top = 0;
            var bottom = 2;
            set.Clear();

            while (right < length && bottom < length)
            {
                // go throught one cell
                i = top;
                while (i <= bottom)
                {
                    var j = left;
                    while (j <= right)
                    {
                        var symbol = list[i][j];
                        if (symbol != '.')
                        {
                            if (set.Contains(symbol))
                            {
                                return 0;
                            }
                            set.Add(symbol);
                        }

                        j++;
                    }
                    i++;
                }

                if (right + 3 < length)
                {
                    left += 3;
                    right += 3;
                }
                else
                {
                    top += 3;
                    bottom += 3;
                }
                set.Clear();
            }

            return 1;
        }
    }
}
