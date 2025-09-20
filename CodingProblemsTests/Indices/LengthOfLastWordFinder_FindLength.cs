namespace CodingProblemsTests.Indices;

public class LengthOfLastWordFinder_FindLength
{
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("a", 1)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    public void Works(string s, int expected)
    {
        int result = new LengthOfLastWordFinder().FindLength(s);

        result.Should().Be(expected);
    }
}
