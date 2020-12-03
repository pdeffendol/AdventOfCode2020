using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var validPasswords = input.Select(line => SledRentalPasswordInfo.FromString(line)).Count(p => p.IsValid());

            Console.WriteLine($"There are {validPasswords} valid passwords using the sled rental policy");

            validPasswords = input.Select(line => TobogganPasswordInfo.FromString(line)).Count(p => p.IsValid());

            Console.WriteLine($"There are {validPasswords} valid passwords using the toboggan rental policy");
        }
    }
}
