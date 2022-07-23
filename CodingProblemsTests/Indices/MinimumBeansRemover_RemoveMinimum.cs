namespace CodingProblemsTests.Indices;

public class MinimumBeansRemover_RemoveMinimum
{
    [Theory]
    [InlineData(new[] { 4, 1, 6, 5 }, 4)]
    [InlineData(new[] { 2, 10, 3, 2 }, 7)]
    public void Works(int[] beans, long expected)
    {
        long result = new MinimumBeansRemover().RemoveMinimum(beans);

        result.Should().Be(expected);
    }
}
