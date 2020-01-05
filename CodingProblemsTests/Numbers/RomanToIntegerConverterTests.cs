using CodingProblems.Numbers;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class RomanToIntegerConverterTests
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("V", 5)]
        [InlineData("M", 1000)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void ConvertsToInt(string input, int expected)
        {
            Assert.Equal(expected, RomanToIntegerConverter.RomanToInt(input));
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(1000, "M")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(58, "LVIII")]
        [InlineData(1994, "MCMXCIV")]
        public void ConvertsToRoman(int input, string expected)
        {
            Assert.Equal(expected, RomanToIntegerConverter.IntToRoman(input));
        }
    }
}
