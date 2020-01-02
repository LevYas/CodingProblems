using CodingProblems.Numbers;
using Xunit;

namespace CodingProblemsTests.NumbersTests
{
    public class BinaryOperationsTests
    {
        [Theory]
        [InlineData("1", "1", "10")]
        [InlineData("11", "1", "100")]
        [InlineData("1010", "1011", "10101")]
        public void AddsBinaryNumbers(string str1, string str2, string expected)
        {
            Assert.Equal(expected, BinaryOperations.AddBinary(str1, str2));
        }
    }
}
