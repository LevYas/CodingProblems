namespace CodingProblemsTests.Indices;

public class SetMismatchFinder_FindErrorNums
{
    [Theory]
    [InlineData(new[] { 1, 2, 2, 4 }, new[] { 2, 3 })]
    [InlineData(new[] { 1, 1 }, new[] { 1, 2 })]
    [InlineData(new[] { 4, 3, 3, 1 }, new[] { 3, 2 })]
    public void Works(int[] nums, int[] expected)
    {
        int[] result = new SetMismatchFinder().FindErrorNums(nums);

        result.Should().Equal(expected);
    }
}
