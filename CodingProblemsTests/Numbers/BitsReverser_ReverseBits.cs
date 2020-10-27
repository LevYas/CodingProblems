using CodingProblems.Numbers;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class BitsReverser_ReverseBits
    {
        [Theory]
        [InlineData(43261596, 964176192)]
        [InlineData(4294967293, 3221225471)]
        public void Works(uint input, uint expected)
        {
            BitsReverser.ReverseBits(input).Should().Be(expected);
        }
    }
}
