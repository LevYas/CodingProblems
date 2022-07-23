namespace CodingProblemsTests.Indices;

public class BinarySubarrayCounter_Count
{
    [Theory]
    [InlineData(new[] { 1, 0, 1, 0, 1 }, 2, 4)]
    [InlineData(new[] { 0, 0, 0, 0, 0 }, 0, 15)]
    [InlineData(new[] { 0, 1, 0 }, 1, 4)]
    [InlineData(new[] { 1, 1, 1 }, 1, 3)]
    public void Works(int[] nums, int goal, int expected)
    {
        int result = new BinarySubarrayCounter().Count(nums, goal);

        result.Should().Be(expected);
    }
}
