using CodingProblems.Numbers;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class PrimeNumbersCounter_CountPrimes
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 2)]
        [InlineData(6, 3)]
        [InlineData(7, 3)]
        [InlineData(8, 4)]
        [InlineData(9, 4)]
        [InlineData(10, 4)]
        public void Works(int input, int expected)
        {
            PrimeNumbersCounter.CountPrimes(input).Should().Be(expected);
        }
    }
}
