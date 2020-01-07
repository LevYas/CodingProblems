using CodingProblems.Numbers;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class PrimeNumbersCounterTests
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
        public void CountPrimesWorks(int input, int expected)
        {
            Assert.Equal(expected, PrimeNumbersCounter.CountPrimes(input));
        }
    }
}
