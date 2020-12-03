using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    public record TobogganPasswordInfo
    {
        // 1-3 a: abcde
        private static Regex _matcher = new Regex(@"(\d+)-(\d+) (.): (.*)");

        public int CheckPosition1 { get; set; }

        public int CheckPosition2 { get; set; }

        public char RequiredLetter { get; set; }

        public string Password { get; set; }

        public bool IsValid()
        {
            return Password[CheckPosition1 - 1] == RequiredLetter
                ^ Password[CheckPosition2 - 1] == RequiredLetter;
        }

        public static TobogganPasswordInfo FromString(string passwordString)
        {
            var match = _matcher.Match(passwordString);

            if (!match.Success)
                throw new ArgumentException($"Not a valid password info string ('{passwordString}')");

            return new TobogganPasswordInfo
            {
                CheckPosition1 = Int32.Parse(match.Groups[1].Value),
                CheckPosition2 = Int32.Parse(match.Groups[2].Value),
                RequiredLetter = match.Groups[3].Value[0],
                Password = match.Groups[4].Value
            };
        }
    }
}
