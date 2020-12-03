using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Day1.Tests
{
    public class CombinationFinderTests
    {
        private CombinationFinder _sut;

        public CombinationFinderTests()
        {
            _sut = new CombinationFinder();
        }

        [Fact]
        public void EmptyList()
        {
            var list = new List<int>();

            var result = _sut.FindCombinations(list, 1).ToList();

            Assert.Empty(result);
        }

        [Fact]
        public void TooManyItems()
        { 
            var list = new List<int>() { 1 };

            Assert.Empty(_sut.FindCombinations(list, 2));
        }

        [Fact]
        public void SingleItem()
        { 
            var list = new List<int>() { 1 };

            var result = _sut.FindCombinations(list, 1).ToList();

            Assert.Single(result);
            Assert.Single(result[0]);
            Assert.Equal(1, result[0][0]);
        }

        [Fact]
        public void TwoItemsTakeOne()
        { 
            var list = new List<int>() { 1, 2 };

            var result = _sut.FindCombinations(list, 1).ToList();

            Assert.Equal(2, result.Count);
            Assert.Single(result[0]);
            Assert.Equal(1, result[0][0]);
            Assert.Single(result[1]);
            Assert.Equal(2, result[1][0]);
        }

        [Fact]
        public void TwoItemsTakeTwo()
        { 
            var list = new List<int>() { 1, 2 };

            var result = _sut.FindCombinations(list, 2).ToList();

            Assert.Single(result);
            Assert.Equal(2, result[0].Count);
            Assert.Equal(1, result[0][0]);
            Assert.Equal(2, result[0][1]);
        }


        [Fact]
        public void ThreeItemsTakeTwo()
        { 
            var list = new List<int>() { 1, 2, 3 };

            var result = _sut.FindCombinations(list, 2).ToList();

            Assert.Equal(3, result.Count);
            Assert.Equal(2, result[0].Count);
            Assert.Equal(1, result[0][0]);
            Assert.Equal(2, result[0][1]);
        }


        [Fact]
        public void ManyItemsTakeThree()
        { 
            var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            var result = _sut.FindCombinations(list, 3).ToList();

            Assert.Equal(3, result.Count);
         }
    }
}
