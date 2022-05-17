using CodingProblems.Other;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Other;

public class FreqStack_PushPop
{
    private readonly FreqStack _sut = new();

    [Theory]
    [InlineData(new[] { 5 }, new[] { 5 })]
    [InlineData(new[] { 5, 7, 5, 7, 4, 5 }, new[] { 5, 7, 5, 4, 7, 5 })]
    [InlineData(new[] { 5, 5, 5, 1, 3, 3, 3, 2, 4, 4 }, new[] { 3, 5, 4, 3, 5, 4, 2, 3, 1, 5 })]
    public void Works(int[] input, int[] expected)
    {
        foreach (int i in input)
            _sut.Push(i);

        foreach (int i in expected)
            _sut.Pop().Should().Be(i);
    }
}
