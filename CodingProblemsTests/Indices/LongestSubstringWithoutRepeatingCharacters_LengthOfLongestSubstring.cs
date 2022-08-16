namespace CodingProblemsTests.Indices;

public class LongestSubstringWithoutRepeatingCharacters_LengthOfLongestSubstring
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("", 0)]
    [InlineData("a", 1)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("abcdce", 4)]
    [InlineData("ababc", 3)]
    public void Works(string s, int expected)
    {
        int result = new LongestSubstringWithoutRepeatingCharacters().LengthOfLongestSubstring(s);

        result.Should().Be(expected);
    }
}
