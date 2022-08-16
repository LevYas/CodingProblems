namespace CodingProblemsTests.Indices;

public class MinimumSizeSubarraySum_MinSubArrayLen
{
    [Theory]
    [InlineData(7, new[] { 2, 3, 1, 2, 4, 3 }, 2)]
    [InlineData(4, new[] { 1, 4, 4 }, 1)]
    [InlineData(11, new[] { 1, 1, 1, 1, 1 }, 0)]
    [InlineData(11, new[] { 1, 2, 3, 4, 5 }, 3)]
    public void Works(int target, int[] nums, int expected)
    {
        int result = new MinimumSizeSubarraySum().MinSubArrayLen(target, nums);

        result.Should().Be(expected);
    }
}
