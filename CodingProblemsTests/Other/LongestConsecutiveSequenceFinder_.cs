namespace CodingProblemsTests.Other;

public class LongestConsecutiveSequenceFinder_Find
{
    [Theory]
    [InlineData(new int[0], 0)]
    [InlineData(new[] { -1000, 10000, -998, -998, -999 }, 3)]
    [InlineData(new[] { 100, 4, 200, 1, 3, 2 }, 4)]
    [InlineData(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
    public void Works(int[] nums, int expected)
    {
        int result = new LongestConsecutiveSequenceFinder().Find(nums);

        result.Should().Be(expected);
    }
}
