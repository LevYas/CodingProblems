namespace CodingProblemsTests.Indices;

public class MagicDictionary_Search
{
    private readonly MagicDictionary _sut = new();

    [Theory]
    [InlineData(new[] { "hello", "leetcode" }, "hello", false)]
    [InlineData(new[] { "hello", "leetcode" }, "helll", true)]
    [InlineData(new[] { "hello", "leetcode" }, "halll", false)]
    [InlineData(new[] { "hello", "leetcode" }, "leetcod", false)]
    public void Works(string[] dict, string target, bool expected)
    {
        _sut.BuildDict(dict);

        bool result = _sut.Search(target);

        result.Should().Be(expected);
    }
}
