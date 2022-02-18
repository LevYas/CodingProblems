using CodingProblems.Lists;
using FluentAssertions;
using CodingProblems.Utility;
using Xunit;

namespace CodingProblemsTests.Lists;

public class PalindromeListChecker_IsPalindrome
{
    [Theory]
    [InlineData(new[] { 1 }, true)]
    [InlineData(new[] { 1, 2 }, false)]
    [InlineData(new[] { 1, 1 }, true)]
    [InlineData(new[] { 1, 2, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 2, 0 }, false)]
    [InlineData(new[] { 1, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 0 }, false)]
    [InlineData(new[] { 1, 2, 3, 4, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 3, 2, 2 }, false)]
    public void Works(int[] sourceArr, bool expected)
    {
        var list = DebugLinkedListFactory.Create<PalindromeListChecker.ListNode>(sourceArr);

        bool result = new PalindromeListChecker().IsPalindrome(list);

        result.Should().Be(expected);
    }
}
