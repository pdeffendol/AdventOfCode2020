using System;
using System.Collections.Generic;
using Xunit;

namespace Day3.Tests
{
    public class MapWalkerTests
    {
        [Fact]
        public void CountTrees()
        {
            var map = new Map(new List<string>
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            });

            var sut = new MapWalker(map, 3, 1);

            Assert.Equal(7, sut.CountTrees());
        }
    }
}
