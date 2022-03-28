using System;
using System.Collections.Generic;

namespace StackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tasks = new Stack();
            //tasks.push(10);
            //tasks.push(9);
            //tasks.getMin();
            //tasks.push(8);
            //tasks.getMin();
            //tasks.push(7);
            //tasks.getMin();
            //tasks.push(6);
            //tasks.getMin();
            //tasks.pop();
            //tasks.getMin();
            //tasks.pop();
            //tasks.getMin();
            //tasks.pop();
            //tasks.getMin();
            //tasks.pop();
            //tasks.getMin();
            //tasks.pop();
            //tasks.pop();
            //tasks.pop();
            //tasks.pop();

            var tasks = new StackTasks();
            var next = tasks.GetNextGreater(new List<int>
            {
                4, 5, 2, 10
            });
            foreach(var a in next)
            {
                Console.WriteLine(a);
            }
        }
    }
}
