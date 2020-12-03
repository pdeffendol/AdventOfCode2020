using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Day2.Tests
{
    public class TobogganRentalPasswordInfoTests
    {
        [Fact]
        public void FromString()
        {
            var passwordString = "1-3 a: abcde";

            var info = TobogganPasswordInfo.FromString(passwordString);

            Assert.Equal(1, info.CheckPosition1);
            Assert.Equal(3, info.CheckPosition2);
            Assert.Equal('a', info.RequiredLetter);
            Assert.Equal("abcde", info.Password);
        }

        [Theory]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 a: abade", false)]
        [InlineData("1-3 f: abcde", false)]
        [InlineData("10-13 m: abcdefghijklmno", true)]
       public void IsValid(string passwordString, bool isValid)
        {
            var info = TobogganPasswordInfo.FromString(passwordString);

            Assert.Equal(isValid, info.IsValid());
        }
    }
}
