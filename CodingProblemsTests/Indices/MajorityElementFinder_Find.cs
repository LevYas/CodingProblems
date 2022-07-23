namespace CodingProblemsTests.Indices;

public class MajorityElementFinder_Find
{
    [Theory]
    [InlineData(new[] { 3, 2, 3 }, 3)]
    [InlineData(new[] { 2, 3, 3 }, 3)]
    [InlineData(new[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    [InlineData(new[] { 7, 7, 5, 7, 5, 1, 5, 7, 5, 5, 7, 7, 5, 5, 5, 5 }, 5)]
    [InlineData(new[] { 7, 7, 5, 7, 5, 1, 5, 7, 5, 5, 7, 7, 7, 7, 7, 7 }, 7)]
    public void Works(int[] nums, int expected)
    {
        int result = new MajorityElementFinder().Find(nums);

        result.Should().Be(expected);
    }
}
