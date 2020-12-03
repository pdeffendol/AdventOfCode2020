using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map(File.ReadAllLines("input.txt").ToList());

            var walkers = new List<MapWalker>
            {
                new MapWalker(map, right: 1, down: 1),
                new MapWalker(map, 3, 1),
                new MapWalker(map, 5, 1),
                new MapWalker(map, 7, 1),
                new MapWalker(map, 1, 2)
            };

            long product = 1;
            foreach (var w in walkers)
            {
                var t = w.CountTrees();
                Console.WriteLine($"{w.StepsRight} right and {w.StepsDown} down finds {t} trees");
                product = product * t;
            }

            Console.WriteLine($"Product is {product}");
        }
    }
}
