namespace CodingProblemsTests.Graphs;

public class DuplicatedFolderCleaner_Cleans
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(string[][] paths, string[][] expected)
    {
        var pathsLists = paths.Select(a => (IList<string>)a.ToList()).ToList();

        IList<IList<string>> result = new DuplicatedFolderCleaner().DeleteDuplicateFolder(pathsLists);

        // Not perfect, because we need to compare sub-arrays ordered, but much simpler than a proper comparison
        result.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<string[][], string[][]> TestData
        => new()
        {
            {
                new[] { new[] { "a" }, new[] { "c" }, new[] { "d" }, new[] { "a", "b" }, new[] { "c", "b" }, new[] { "d", "a" } },
                new[] { new[] { "d" }, new[] { "d", "a" } }
            },
            {
                new[]
                {
                    new[] { "a" }, new[] { "c" }, new[] { "a", "b" }, new[] { "c", "b" }, new[] { "a", "b", "x" }, new[] { "a", "b", "x", "y" },
                    new[] { "w" }, new[] { "w", "y" },
                },
                new[] { new[] { "c" }, new[] { "c", "b" }, new[] { "a" }, new[] { "a", "b" } }
            },
            {
                new[]
                {
                    new[] { "a" }, new[] { "c" }, new[] { "a", "b" }, new[] { "c", "b" }, new[] { "a", "b", "x" }, new[] { "a", "b", "x", "y" },
                    new[] { "w" }, new[] { "w", "y" }, new[] { "w", "y", "z" },
                },
                new[]
                {
                    new[] { "a" }, new[] { "c" }, new[] { "a", "b" }, new[] { "c", "b" }, new[] { "a", "b", "x" }, new[] { "a", "b", "x", "y" },
                    new[] { "w" }, new[] { "w", "y" }, new[] { "w", "y", "z" },
                }
            },
            {
                new[] { new[] { "a", "b" }, new[] { "c", "d" }, new[] { "c" }, new[] { "a" } },
                new[] { new[] { "c" }, new[] { "c", "d" }, new[] { "a" }, new[] { "a", "b" } }
            },
            {
                new[] { new[] { "a" }, new[] { "a", "x" }, new[] { "a", "x", "y" }, new[] { "a", "z" },
                    new[] { "b" }, new[] { "b", "x" }, new[] { "b", "x", "y" }, new[] { "b", "z" } },
                Array.Empty<string[]>()
            },
            {
                new[] { new[] { "a" }, new[] { "a","c" }, new[] { "a","d" }, new[] { "a","d","e" },
                    new[] { "b" }, new[] { "b","e" }, new[] { "b","c" }, new[] { "b","c","d" }, new[] { "f" },
                    new[] { "f","h" }, new[] { "f","h","i" }, new[] { "f","j" }, new[] { "g" }, new[] { "g","j" },
                    new[] { "g","h" }, new[] { "g","h","i"} },

                new[] { new[] { "a" }, new[] { "b" }, new[] { "a","c" }, new[] { "a","d" }, new[] { "b","e" },
                    new[] { "b","c" }, new[] { "a","d","e" }, new[] { "b","c","d" } }
            },
        };
}
