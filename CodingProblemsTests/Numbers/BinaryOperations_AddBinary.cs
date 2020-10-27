using CodingProblems.Numbers;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Numbers
{
    public class BinaryOperations_AddBinary
    {
        [Theory]
        [InlineData("1", "1", "10")]
        [InlineData("11", "1", "100")]
        [InlineData("1010", "1011", "10101")]
        public void Adds(string str1, string str2, string expected)
        {
            BinaryOperations.AddBinary(str1, str2).Should().Be(expected);
        }
    }
}
