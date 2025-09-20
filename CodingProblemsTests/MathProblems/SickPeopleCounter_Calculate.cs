namespace CodingProblemsTests.MathProblems;

public class SickPeopleCounter_Calculate
{
    [Theory]
    [InlineData(2, 3, 5, 1)]
    [InlineData(3, 3, 5, 1)]
    [InlineData(4, 3, 5, 2)]

    [InlineData(2, 2, 4, 1)]
    [InlineData(3, 2, 4, 2)]
    [InlineData(4, 2, 4, 3)]
    [InlineData(5, 2, 4, 3)]
    [InlineData(6, 2, 4, 5)]

    [InlineData(2, 1, 2, 2)]

    [InlineData(3, 1, 3, 4)]
    [InlineData(4, 1, 3, 6)]
    [InlineData(425, 81, 118, 1754995)]
    [InlineData(684, 18, 496, 653668527)]
    public void Works(int n, int delay, int forget, int expected)
    {
        int result = new SickPeopleCounter().Calculate(n, delay, forget);

        result.Should().Be(expected);
    }
}
