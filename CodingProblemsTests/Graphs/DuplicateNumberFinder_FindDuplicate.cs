namespace CodingProblemsTests.Graphs;

public class DuplicateNumberFinder_FindDuplicate
{
    [Theory]
    [InlineData(new[] { 1, 3, 4, 2, 2 }, 2)]
    [InlineData(new[] { 3, 1, 3, 4, 2 }, 3)]
    [InlineData(new[] { 1, 1, 1, 1, 2 }, 1)]
    public void Works(int[] nums, int expected)
    {
        int result = new DuplicateNumberFinder().FindDuplicate(nums);

        result.Should().Be(expected);
    }
}
