namespace CodingProblemsTests.Graphs;

public class FlattenBinaryTreeToLinkedList_Flatten
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(TreeNode root, TreeNode expected)
    {
        new FlattenBinaryTreeToLinkedList().Flatten(root);

        root.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<TreeNode, TreeNode> TestData() =>
        new()
        {
            {
                new(1, new(2, new(3), new(4)), new(5, null, new(6))),
                new(1, null, new(2, null, new(3, null, new(4, null, new(5, null, new(6))))))
            },
            {
                null,
                null
            },
            {
                new(),
                new()
            },
        };
}
