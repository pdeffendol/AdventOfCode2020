using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var bags = File.ReadAllLines("input.txt").Select(Bag.FromString).ToDictionary(k => k.Color);

            var gold = FindAncestors(bags["shiny gold"], bags);

            Console.WriteLine($"{gold.Count} bags can contain shiny gold");

            var contained = BagsInside(bags["shiny gold"], bags);

            Console.WriteLine($"{contained} bags are inside shiny gold");
        }

        private static Dictionary<string, Bag> FindAncestors(Bag current, Dictionary<string, Bag> allBags)
        {
            var direct = allBags.Where(b => b.Value.Contained.ContainsKey(current.Color)).ToDictionary(i => i.Key, i => i.Value);
           
            var all = new Dictionary<string, Bag>(direct);
            foreach (var d in direct)
            {
                foreach (var i in FindAncestors(d.Value, allBags))
                {
                    if (!all.ContainsKey(i.Key))
                        all.Add(i.Key, i.Value);
                }
            }

            return all;
        }

        private static int BagsInside(Bag current, Dictionary<string, Bag> allBags)
        {
            var contained = 0;
            foreach (var i in current.Contained)
            { 
                contained += i.Value;
                contained += i.Value * BagsInside(allBags[i.Key], allBags);
            }

            return contained;
        }
    }
}
