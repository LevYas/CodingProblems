using CodingProblems.Indices;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Indices;

public class WiggleSorter_WiggleSort
{
    [Theory]
    [InlineData(new[] { 1 })]
    [InlineData(new[] { 5, 5, 6, 4 })]
    [InlineData(new[] { 4, 4, 4, 5, 5, 5 })]
    [InlineData(new[] { 1, 5, 1, 1, 6, 4 })]
    [InlineData(new[] { 1, 3, 2, 2, 3, 1 })]
    public void Works(int[] nums)
    {
        new WiggleSorter().WiggleSort(nums);

        for (int i = 1; i < nums.Length; i += 2)
        {
            nums[i].Should().BeGreaterThan(nums[i - 1]);

            if (i + 1 < nums.Length)
                nums[i].Should().BeGreaterThan(nums[i + 1]);
        }
    }
}
