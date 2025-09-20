namespace CodingProblemsTests.Indices;

public class NumberOfWaysToSelectBuildingsSolver_Calculate
{
    [Theory]
    [InlineData("000", 0)]
    [InlineData("111", 0)]
    [InlineData("000111", 0)]
    [InlineData("1111000", 0)]
    [InlineData("010", 1)]
    [InlineData("101", 1)]
    [InlineData("0010", 2)]
    [InlineData("1101", 2)]
    [InlineData("0101", 2)]
    [InlineData("1011", 2)]
    [InlineData("001101", 6)]
    public void Works(string s, long expected)
    {
        long result = new NumberOfWaysToSelectBuildingsSolver().Calculate(s);

        result.Should().Be(expected);
    }
}
