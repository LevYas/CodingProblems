namespace CodingProblemsTests.Graphs;

public class BinaryTreeInverter_InvertBinaryTree
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(TreeNode root, TreeNode expected)
    {

        TreeNode result = BinaryTreeInverter.InvertBinaryTree(root);

        result.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<TreeNode, TreeNode> TestData() =>
        new()
        {
            { null, null },
            {
                new(4, new(2, new(1), new(3)), new(7, new(6), new(9))),
                new(4, new(7, new(9), new(6)), new(2, new(3), new(1)))
            },
            {
                new(2, new(1), new(3)),
                new(2, new(3), new(1))
            },
            {
                new(4, new(2, new(1)), new(7, null, new(9))),
                new(4, new(7, new(9)), new(2, null, new(1)))
            },
        };
}
