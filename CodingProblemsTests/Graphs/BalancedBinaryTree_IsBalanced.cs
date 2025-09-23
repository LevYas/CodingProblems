namespace CodingProblemsTests.Graphs;

public class BalancedBinaryTree_IsBalanced
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(TreeNode root, bool expected)
    {
        bool result = BalancedBinaryTree.IsBalanced(root);

        result.Should().Be(expected);
    }

    public static TheoryData<TreeNode, bool> TestData() =>
        new()
        {
            { new(3, new(9), new(20, new(15), new(7))), true },
            { new(1, new(2, new(3, new(4), new(4)), new(3)), new(2)), false },
            { new(1, new(2, new(3))), false },
            { new(1, new(2, new(4, new(8)), new(5)), new(3, new(6))), true },
            { null, true },
            { new(), true },
        };
}
