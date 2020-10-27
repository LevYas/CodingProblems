using CodingProblems.Other;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Other
{
    public class ValidParenthesesChecker_IsValid
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("{[]}", true)]
        [InlineData("([)]", false)]
        [InlineData("]", false)]
        public void ChecksCorrectly(string input, bool expected)
        {
            ValidParenthesesChecker.IsValid(input).Should().Be(expected);
        }
    }
}
