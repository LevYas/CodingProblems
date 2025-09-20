namespace CodingProblemsTests.Numbers;

public class MaxXorFinder_FindMaximumXor
{
    [Theory]
    [InlineData(new[] { 3, 10, 5, 25, 2, 8 }, 28)]
    [InlineData(new[] { 14, 70, 53, 83, 49, 91, 36, 80, 92, 51, 66, 70 }, 127)]
    public void Works(int[] nums, int expected)
    {
        int result = new MaxXorFinder().FindMaximumXor(nums);

        result.Should().Be(expected);
    }
}
