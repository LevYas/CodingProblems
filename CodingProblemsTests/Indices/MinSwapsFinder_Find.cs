namespace CodingProblemsTests.Indices;

public class MinSwapsFinder_Find
{
    [Theory]
    [InlineData(new[] { 0, 1, 0, 1, 1, 0, 0 }, 1)]
    [InlineData(new[] { 0, 1, 1, 1, 0, 0, 1, 1, 0 }, 2)]
    [InlineData(new[] { 1, 1, 0, 0, 1 }, 0)]
    public void Works(int[] nums, int expected)
    {
        int result = new MinSwapsFinder().Find(nums);

        result.Should().Be(expected);
    }
}
