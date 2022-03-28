using System;
using System.Collections.Generic;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Task();

            //Console.WriteLine(task.GetLongestCommonPrefix(new List<string>
            //{
            //    "abcdefgh", "aefghijk", "abcefgh"
            //}));

            Console.WriteLine(task.Reverse("   this    is   my       string        "));
        }
    }
}
