using CodingProblems.Other;
using Xunit;

namespace CodingProblemsTests.Other
{
    public class ValidParenthesesCheckerTests
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
            Assert.Equal(expected, ValidParenthesesChecker.IsValid(input));
        }
    }
}
