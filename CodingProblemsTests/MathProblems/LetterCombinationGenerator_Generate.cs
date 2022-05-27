using CodingProblems.MathProblems;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingProblemsTests.MathProblems;

public class LetterCombinationGenerator_Generate
{
    [Theory]
    [InlineData("", new string[0])]
    [InlineData("2", new[] { "a", "b", "c" })]
    [InlineData("23", new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
    public void Works(string digits, string[] expected)
    {
        IList<string> result = new LetterCombinationGenerator().Generate(digits);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("", new string[0])]
    [InlineData("2", new[] { "a", "b", "c" })]
    [InlineData("23", new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
    public void WorksViaRecursion(string digits, string[] expected)
    {
        IList<string> result = new LetterCombinationGenerator().GenerateViaRecursion(digits);

        result.Should().BeEquivalentTo(expected);
    }
}
