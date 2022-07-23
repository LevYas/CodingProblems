namespace CodingProblemsTests.Graphs;

public class TreeLevelOrderTraversal_LevelOrder
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(TreeNode root, int[][] expected)
    {
        IList<IList<int>> result = new TreeLevelOrderTraversal().LevelOrder(root);

        for (int i = 0; i < expected.Length; i++)
            result[i].Should().Equal(expected[i]);
    }

    public static TheoryData<TreeNode, int[][]> TestData() =>
        new()
        {
            {
                new(3, new(9), new(20, new(15), new(7))),
                new[] { new[] { 3 }, new[] { 9, 20 }, new[] { 15, 7 } }
            },
            {
                new(1),
                new[] { new[] { 1 } }
            },
        };
}
