namespace CodingProblemsTests.Lists;

public class AddTwoNumbersSolver_AddTwoNumbers
{
    [Theory]
    [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    [InlineData(new[] { 9, 0, 1 }, new[] { 2, 9 }, new[] { 1, 0, 2 })]
    [InlineData(new[] { 9, 9 }, new[] { 1 }, new[] { 0, 0, 1 })]
    public void Works(int[] arr1, int[] arr2, int[] expectedValues)
    {
        ListNode l1 = DebugLinkedListFactory.Create<ListNode>(arr1);
        ListNode l2 = DebugLinkedListFactory.Create<ListNode>(arr2);

        ListNode result = new AddTwoNumbersSolver().AddTwoNumbers(l1, l2);

        ListNode currentNode = result;
        foreach (int expectedVal in expectedValues)
        {
            currentNode.Val.Should().Be(expectedVal);
            currentNode = currentNode.Next;
        }
    }
}
