namespace CodingProblemsTests.Indices;

public class TotalStepsFinder_TotalSteps
{
    [Theory]
    [InlineData(new[] { 5, 3, 4, 4, 7, 3, 6, 11, 8, 5, 11 }, 3)]
    [InlineData(new[] { 4, 5, 7, 7, 13 }, 0)]
    [InlineData(new[] { 7, 14, 4, 14, 13, 2, 6, 13 }, 3)]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, 1)]
    [InlineData(new[] { 10, 1, 2, 3, 4, 5, 6, 1, 2, 3 }, 6)]
    public void Works(int[] nums, int expected)
    {
        int result = new TotalStepsFinder().TotalSteps(nums);

        result.Should().Be(expected);
    }
}
