namespace CodingProblemsTests.Indices;

public class WiggleSubsequence_GetMaxLength
{
    [Theory]
    [InlineData(new[] { 1, 7, 4, 9, 2, 5 }, 6)]
    [InlineData(new[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 }, 7)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2)]
    [InlineData(new[] { 0 }, 1)]
    [InlineData(new[] { 0, 0, 0 }, 1)]
    [InlineData(new[] { 5, 5, 5 }, 1)]
    public void Works(int[] nums, int expected)
    {
        int result = new WiggleSubsequence().GetMaxLength(nums);

        result.Should().Be(expected);
    }
}
