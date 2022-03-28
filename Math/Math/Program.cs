using System;
using System.Collections.Generic;

namespace Math
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Tasks();
            Console.WriteLine(tasks.GetSumOfHammingDistances(new List<int> { 2, 4, 6 }));
        }
    }
}
