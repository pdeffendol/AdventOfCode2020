using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    public record SledRentalPasswordInfo
    {
        // 1-3 a: abcde
        private static Regex _matcher = new Regex(@"(\d+)-(\d+) (.): (.*)");

        public int MinAllowed { get; set; }

        public int MaxAllowed { get; set; }

        public char RequiredLetter { get; set; }

        public string Password { get; set; }

        public bool IsValid()
        {
            var occurrences = Password.Count(c => c == RequiredLetter);

            return occurrences >= MinAllowed && occurrences <= MaxAllowed;
        }

        public static SledRentalPasswordInfo FromString(string passwordString)
        {
            var match = _matcher.Match(passwordString);

            if (!match.Success)
                throw new ArgumentException($"Not a valid password info string ('{passwordString}')");

            return new SledRentalPasswordInfo
            {
                MinAllowed = Int32.Parse(match.Groups[1].Value),
                MaxAllowed = Int32.Parse(match.Groups[2].Value),
                RequiredLetter = match.Groups[3].Value[0],
                Password = match.Groups[4].Value
            };
        }
    }
}
