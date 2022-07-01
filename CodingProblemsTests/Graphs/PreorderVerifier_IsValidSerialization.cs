using CodingProblems.Graphs;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Graphs;

public class PreorderVerifier_IsValidSerialization
{
    [Theory]
    [InlineData("9,3,4,#,#,1,#,#,2,#,6,#,#", true)]
    [InlineData("1,#", false)]
    [InlineData("9,#,#,1", false)]
    [InlineData("#", true)]
    public void Works(string preorder, bool expected)
    {
        bool result = new PreorderVerifier().IsValidSerialization(preorder);

        result.Should().Be(expected);
    }
}
