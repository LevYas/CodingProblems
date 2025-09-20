namespace CodingProblemsTests.Graphs;

public class HouseRobberIIISolver_Solve
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Solves(TreeNode root, int expected)
    {
        int result = new HouseRobberIIISolver().Solve(root);

        result.Should().Be(expected);
    }

    public static TheoryData<TreeNode, int> TestData() =>
        new()
        {
            { new(7, new(2, new(5, new(20), new(30)), new(6, new()))), 63 },
            { new(4, new(1, new (2, new (3)))), 7 },
            { new(3, new(2, null, new(3)), new(3, null, new(1))), 7 },
            { new(3, new(4, new(1), new(3)), new(5, null, new(1))), 9 },
        };
}
