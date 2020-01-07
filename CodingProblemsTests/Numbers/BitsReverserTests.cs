using CodingProblems.Numbers;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class BitsReverserTests
    {
        [Theory]
        [InlineData(43261596, 964176192)]
        [InlineData(4294967293, 3221225471)]
        public void ReverseBitsWorks(uint input, uint expected)
        {
            Assert.Equal(expected, BitsReverser.ReverseBits(input));
        }
    }
}
