namespace CodingProblemsTests.Graphs;

public class SubtreeFinder_IsSubtree
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(TreeNode root, TreeNode subRoot, bool expected)
    {
        bool result = new SubtreeFinder().IsSubtree(root, subRoot);

        result.Should().Be(expected);
    }

    public static TheoryData<TreeNode, TreeNode, bool> TestData() =>
        new()
        {
            {
                new(3, new(4, new(1), new(2)), new(5)),
                new(4, new(1), new(2)),
                true
            },
            {
                new(3, new(4, new(1), new(2, new())), new(5)),
                new(4, new(1), new(2)),
                false
            },
        };
}
