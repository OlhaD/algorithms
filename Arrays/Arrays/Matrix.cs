using System;
using System.Collections.Generic;

namespace Arrays
{
    public class Matrix
    {
        public List<List<int>> GenerateMatrix(int number)
        {
            var step = 1;
            var round = 0;
            var x = 0;
            var y = 0;

            var result = new int[number, number];

            while (step <= number * number)
            {
                // fill top
                while (y < number - round && step <= number * number)
                {
                    result[x, y] = step++;
                    y++;
                }
                y--;
                x++;

                // fill right
                while (x < number - round && step <= number * number)
                {
                    result[x, y] = step++;
                    x++;
                }
                x--;
                y--;

                // fill bottom
                while (y >= round && step <= number * number)
                {
                    result[x, y] = step++;
                    y--;
                }
                y++;
                x--;

                // fill left
                while (x >= round + 1 && step <= number * number)
                {
                    result[x, y] = step++;
                    x--;
                }
                x++;
                y++;

                round++;
            }

            return GetList(result);
        }

        private List<List<int>> GetList(int[,] matrix)
        {
            var result = new List<List<int>>();
            var length = matrix.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var list = new List<int>();                
                for (int x = 0; x < length; x++)
                {
                    list.Add(matrix[i, x]);
                }
                result.Add(list);
            }

            return result;
        }

        public int[,] RotateLeft(int[,] matrix)
        {
            var length = matrix.GetLength(0);

            int x = 0;
            while (x < length / 2)
            {
                for (int i = x; i < length - x - 1; i++)
                {
                    Swap(ref matrix[x,i], ref matrix[i,length - x - 1]);
                    Swap(ref matrix[x,i], ref matrix[length - i - 1, x]);
                    Swap(ref matrix[length - i - 1,x], ref matrix[length - x - 1,length - i - 1]);
                }
                x++;
            }

            return matrix;
        }

        private void Swap(ref int first, ref int second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        public List<List<int>> GenerateMatrix2(int number)
        {
            var len = number * 2 - 1;
            var result = new int[len, len];

            var x = 0;
            var endX = len - 1;
            var y = 0;
            var endY = len - 1;
            var currentNumber = number;

            while (x < len && y < len && x <= endX && y <= endY)
            {
                // fill top
                for(int i = y; i <= endY; i++)
                {
                    result[x, i] = currentNumber;
                }

                // fill right
                for (int i = x; i <= endX; i++)
                {
                    result[i, endY] = currentNumber;
                }

                // fill bottom
                for (int i = y; i <= endY; i++)
                {
                    result[endX, i] = currentNumber;
                }

                // fill left
                for (int i = x; i <= endX; i++)
                {
                    result[i, y] = currentNumber;
                }

                currentNumber--;
                x++;
                y++;
                endX--;
                endY--;
            }

            return GetList(result);
        }

        public int GetMaxSquare(int[,] arr)
        {
            int minX = 0, maxX = 0;
            int minY = 0, maxY = 0;
            int maxSquare = 0;

            int height = arr.GetLength(0);
            int width = arr.GetLength(1);

            while(minY < width)
            {
                var x = minX;
                var y = minY;

                while (maxX < height)
                {
                    // find 1st 1 on X
                    while (x < height - 1 && arr[x, y] == 0)
                    {
                        x++;
                    }

                    if (x == height - 1 && arr[x, y] == 0)
                    {
                        break;
                    }

                    maxX = x;
                    while (maxX < height - 1 && arr[maxX + 1, y] == 1)
                    {
                        maxX++;
                    }

                    // find 1st 1 on Y
                    while (y < width - 1 && arr[x, y] == 0)
                    {
                        y++;
                    }

                    if (y == width - 1 && arr[x, y] == 0)
                    {
                        break;
                    }

                    maxY = y;
                    while (maxY < width - 1 && arr[x, maxY + 1] == 1)
                    {
                        maxY++;
                    }

                    // check if there is no 0 in rectangle
                    
                    bool isAcceptable = true;
                    var tempX = x;
                    var tempY = y;
                    while (tempX <= maxX)
                    {
                        //if (!isAcceptable)
                        //{
                        //    break;
                        //}
                        while (tempY <= maxY)
                        {
                            if (arr[tempX, tempY] == 0)
                            {
                                //isAcceptable = false;
                                maxY = tempY - 1;
                                maxX = tempX - 1;
                            }
                            tempY++;
                        }
                        tempY = minY;
                        tempX++;
                    }

                    if (isAcceptable)
                    {
                        var max = (maxY - y + 1) * (maxX - x + 1);
                        if (max > maxSquare)
                        {
                            maxSquare = max;
                        }
                    }

                    x++;
                    maxX = x;
                }

                minY++;
                maxY = minY;

                minX = 0;
                maxX = 0;
            }

            return maxSquare;
        }

        public int GetMaxSquareForTest(List<List<int>> arr)
        {
            int minX = 0, maxX = 0;
            int minY = 0, maxY = 0;
            int maxSquare = 0;

            int height = arr.Count;
            int width = arr[0].Count;

            while (minY < width)
            {
                var x = minX;
                var y = minY;

                while (maxX < height)
                {
                    // find 1st 1 on X
                    while (x < height - 1 && arr[x][y] == 0)
                    {
                        x++;
                    }

                    if (x == height - 1 && arr[x][y] == 0)
                    {
                        break;
                    }

                    maxX = x;
                    while (maxX < height - 1 && arr[maxX + 1][y] == 1)
                    {
                        maxX++;
                    }

                    // find 1st 1 on Y
                    while (y < width - 1 && arr[x][y] == 0)
                    {
                        y++;
                    }

                    if (y == width - 1 && arr[x][y] == 0)
                    {
                        break;
                    }

                    maxY = y;
                    while (maxY < width - 1 && arr[x][maxY + 1] == 1)
                    {
                        maxY++;
                    }

                    // check if there is no 0 in rectangle

                    bool isAcceptable = true;
                    var tempX = x;
                    var tempY = y;
                    while (tempX <= maxX)
                    {
                        if (!isAcceptable)
                        {
                            break;
                        }
                        while (tempY <= maxY)
                        {
                            if (arr[tempX][tempY] == 0)
                            {
                                isAcceptable = false;
                                break;
                            }
                            tempY++;
                        }
                        tempY = minY;
                        tempX++;
                    }

                    if (isAcceptable)
                    {
                        var max = (maxY - y + 1) * (maxX - x + 1);
                        if (max > maxSquare)
                        {
                            maxSquare = max;
                        }
                    }

                    x++;
                    maxX = x;
                }

                minY++;
                maxY = minY;

                minX = 0;
                maxX = 0;
            }

            return maxSquare;
        }
    }
}
