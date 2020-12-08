using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    public class Bag
    {
        public string Color { get; set; }
        public Dictionary<string, int> Contained {get;set; } = new Dictionary<string, int>();

        // plaid coral bags contain 3 posh fuchsia bags, 3 dotted beige bags, 2 wavy turquoise bags.
        // bright gold bags contain no other bags.

        private Regex containedRegex = new Regex(@"(\d+) ([\w\s]+) bags\.?");

        public static Bag FromString(string bagString)
        { 
            var split = bagString.Split(" bags contain ");
            var color = split[0];

            var containedRegex = new Regex(@"((\d+) (\w+ \w+) bags?)");
            var containedMatches = containedRegex.Matches(split[1]);

            return new Bag
            {
                Color = color,
                Contained = containedMatches.ToDictionary(m => m.Groups[3].Value, m => int.Parse(m.Groups[2].Value))
            };
        }
    }
}
