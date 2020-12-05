using System;
using System.IO;
using System.Linq;

namespace Day5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var passes = File.ReadAllLines("input.txt").Select(BoardingPass.FromString);

            var max = passes.Select(p => p.GetSeatId()).Max();
            Console.WriteLine($"Max seat ID = {max}");

            var allIds = passes
                .Where(p => p.Row != 0 && p.Row != 127)
                .Select(p => p.GetSeatId());

            var mine = allIds
                .First(id => !allIds.Contains(id + 1)
                    && allIds.Contains(id + 2));

            Console.WriteLine($"My seat ID = {mine}");
        }
    }
}

