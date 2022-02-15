using CodingProblems.Indices;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices;

public class ColorSorter_SortColors
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void SimpleVersionWorks(int[] nums, int[] expected)
    {
        new ColorSorter().SortColorsSimple(nums);

        nums.Should().Equal(expected);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(int[] nums, int[] expected)
    {
        new ColorSorter().SortColors(nums);

        nums.Should().Equal(expected);
    }

    public static TheoryData<int[], int[]> TestData =>
        new()
        {
            {
                new[] { 2, 0, 2, 1, 1, 0 }, new[] { 0, 0, 1, 1, 2, 2 }
            },
            {
                new[] { 2, 0, 1 }, new[] { 0, 1, 2 }
            },
            {
                new[] { 0, 0, 1, 1, 2, 2 }, new[] { 0, 0, 1, 1, 2, 2 }
            },
            {
                new[] { 0, 2, 1, 1, 0 }, new[] { 0, 0, 1, 1, 2 }
            },
            {
                new[] { 2, 0, 2, 1, 1, 2 }, new[] { 0, 1, 1, 2, 2, 2 }
            },
        };
}
