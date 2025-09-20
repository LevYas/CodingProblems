namespace CodingProblemsTests.Graphs;

public class KthSmallestElementInBstFinder_FindKthSmallest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Works(TreeNode root, int k, int expected)
    {
        int result = new KthSmallestElementInBstFinder().FindKthSmallest(root, k);

        result.Should().Be(expected);
    }

    public static TheoryData<TreeNode, int, int> TestData() =>
        new()
        {
            { new(3, new(1, null, new(2)), new(4)), 1, 1 },
            { new(3, new(1, null, new(2)), new(4)), 2, 2 },
            { new(3, new(1, null, new(2)), new(4)), 3, 3 },

            { new(5, new(3, new(2, new(1)), new(4)), new(6)), 3, 3 },
            { new(5, new(3, new(2, new(1)), new(4)), new(6)), 4, 4 },
            { new(5, new(3, new(2, new(1)), new(4)), new(6)), 6, 6 },
            { new(5, new(3, new(2, new(1)), new(4)), new(10)), 6, 10 },
        };
}
