using System;
using System.Collections.Generic;

namespace HeapsAndMaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new LRUCache(4);
            cache.Set(5, 13);
            cache.Set(9, 6);
            cache.Set(4, 1);
            Console.WriteLine(cache.Get(4));
            cache.Set(6, 1);
            cache.Set(8, 11);
            Console.WriteLine(cache.Get(13)); //-1
            Console.WriteLine(cache.Get(1)); //-1
            cache.Set(12, 12); 
            Console.WriteLine(cache.Get(10));//-1
            cache.Set(15, 13);
            cache.Set(2, 12);
            cache.Set(7, 5);
            cache.Set(10, 3);
            Console.WriteLine(cache.Get(6));
        }
    }
}
