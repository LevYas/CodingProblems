namespace CodingProblemsTests.Indices;

public class PalindromicSubstringsCounter_CountSubstrings
{
    [Theory]
    [InlineData("abc", 3)]
    [InlineData("aaa", 6)]
    [InlineData("abba", 6)]
    [InlineData("cabbad", 8)]
    [InlineData("aba", 4)]
    [InlineData("cabad", 6)]
    [InlineData("aaaa", 10)]
    public void Works(string s, int expected)
    {
        int result = new PalindromicSubstringsCounter().CountSubstrings(s);

        result.Should().Be(expected);
    }
}
