using CodingProblems.Indices;
using FluentAssertions;
using System;
using Xunit;

namespace CodingProblemsTests.Indices;

public class ReplacedStringMatcher_MatchReplacement
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(string s, string sub, char[][] mappings, bool expected)
    {
        bool result = new ReplacedStringMatcher().MatchReplacement(s, sub, mappings);

        result.Should().Be(expected);
    }

    public static TheoryData<string, string, char[][], bool> TestData
        => new()
        {
            {
                "fool3e7bar",
                "leet",
                new[]
                {
                    new[] { 'e','3' },
                    new[] { 't','7' },
                    new[] { 't','8' },
                },
                true
            },
            {
                "fooleetbar",
                "f00l",
                new[]
                {
                    new[] { 'O','0' },
                },
                false
            },
            {
                "Fool33tbaR",
                "leetd",
                new[]
                {
                    new[] { 'e','3' },
                    new[] { 't','7' },
                    new[] { 't','8' },
                    new[] { 'd','b' },
                    new[] { 'p','b' },
                },
                true
            },

        };
}
