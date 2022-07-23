namespace CodingProblemsTests.Graphs;

public class WordFinder_Exist
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Works(char[][] board, string word, bool expected)
    {
        bool result = new WordFinder().Exist(board, word);

        result.Should().Be(expected);
    }

    public static TheoryData<char[][], string, bool> Data
        => new()
        {
            {
                new[]
                {
                    new[] { 'A','B','C','E' },
                    new[] { 'S','F','C','S' },
                    new[] { 'A','D','E','E' },
                },
                "ABCCED",
                true
            },
            {
                new[]
                {
                    new[] { 'A','B','C','E' },
                    new[] { 'S','F','C','S' },
                    new[] { 'A','D','E','E' },
                },
                "SEE",
                true
            },
            {
                new[]
                {
                    new[] { 'A','B','C','E' },
                    new[] { 'S','F','C','S' },
                    new[] { 'A','D','E','E' },
                },
                "ABCB",
                false
            },
        };
}
