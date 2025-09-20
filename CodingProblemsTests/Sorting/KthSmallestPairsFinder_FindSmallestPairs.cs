namespace CodingProblemsTests.Sorting;

public class KthSmallestPairsFinder_FindSmallestPairs
{
    [Theory]
    [InlineData(new[] { 1, 7, 11 }, new[] { 2, 4, 6 }, 3, "[[1,2],[1,4],[1,6]]")]
    [InlineData(new[] { 1, 1, 2 }, new[] { 1, 2, 3 }, 2, "[[1,1],[1,1]]")]
    [InlineData(new[] { 1, 2 }, new[] { 3 }, 3, "[[1,3],[2,3]]")]
    [InlineData(new[] { 1, 7, 11 }, new[] { 2, 4, 20 }, 3, "[[1,2],[1,4],[7,2]]")]
    public void Works(int[] nums1, int[] nums2, int k, string expectedStr)
    {
        IList<IList<int>> expected = expectedStr.ToILists();

        IList<IList<int>> result = new KthSmallestPairsFinder().FindSmallestPairs(nums1, nums2, k);

        result.Should().Equal(expected, (l1, l2) => l1[0] == l2[0] && l1[1] == l2[1]);
    }
}
