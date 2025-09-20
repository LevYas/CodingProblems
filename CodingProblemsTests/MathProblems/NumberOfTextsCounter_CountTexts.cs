namespace CodingProblemsTests.MathProblems;

public class NumberOfTextsCounter_CountTexts
{
    [Theory]
    [InlineData("2", 1)]
    [InlineData("22", 2)]
    [InlineData("222", 4)]
    [InlineData("2223", 4)]
    [InlineData("2222", 7)]
    [InlineData("7777", 8)]
    [InlineData("22233", 8)]
    [InlineData("222222222222222222222222222222222222", 82876089)]
    public void Works(string pressedKeys, int expected)
    {
        int result = new NumberOfTextsCounter().CountTexts(pressedKeys);

        result.Should().Be(expected);
    }
}
