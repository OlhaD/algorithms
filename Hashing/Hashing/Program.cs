using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Tasks();
            //var a = task.twoSum(new List<int>
            //{
            //    1, 1, 1
            //}, 2);

            //foreach(var b in a)
            //{
            //    Console.WriteLine(b);
            //}     

            var a = task.GetLongestConsecutive(new List<int> { -6, -4, -5, -2, -3 });
            Console.WriteLine(a);
            //foreach (var b in a)
            //{
            //    Console.WriteLine(b);
            //}
        }
    }
}
