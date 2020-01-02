using CodingProblems.Numbers;
using Xunit;

namespace CodingProblemsTests.NumbersTests
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
        public void ProducesTheRightResult(string input, int expected)
        {
            Assert.Equal(expected, RomanToIntegerConverter.RomanToInt(input));
        }
    }
}
