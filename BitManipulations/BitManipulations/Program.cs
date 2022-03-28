using System;
using System.Collections.Generic;

namespace BitManipulations
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Tasks();
            Console.WriteLine(a.SingleOfTrippleNumbers(new List<int>
            {
                1, 2, 4, 3, 3, 2, 2, 3, 1, 1
            }));
        }
    }
}
