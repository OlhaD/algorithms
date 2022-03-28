using System;
using System.Collections.Generic;

namespace Backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Tasks();
            var combinations = tasks.GenerateParenthesis(4);
            foreach(var el in combinations)
            {
                foreach(var e in el)
                {
                    Console.Write(e + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
