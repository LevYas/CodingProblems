namespace CodingProblemsTests.Lists;

public class LinkedListCycleFinder_DetectCycle
{
    [Theory]
    [InlineData(new[] { 1 })]
    [InlineData(new[] { 1, 2, 3 })]
    public void Works(int[] sourceArr)
    {
        ListNode head = DebugLinkedListFactory.Create<ListNode>(sourceArr);

        ListNode result = new LinkedListCycleFinder().DetectCycle(head);

        result.Should().BeNull();
    }

    [Fact]
    public void WorksForGeneralCase()
    {
        ListNode head = DebugLinkedListFactory.Create<ListNode>(new[] { 1, 2, 3, 4 });

        head.Next.Next.Next.Next = head.Next;

        ListNode result = new LinkedListCycleFinder().DetectCycle(head);

        result.Should().Be(head.Next);
    }

    [Fact]
    public void WorksForCycleInTheBeginning()
    {
        ListNode head = DebugLinkedListFactory.Create<ListNode>(new[] { 1, 2 });

        head.Next.Next = head;

        ListNode result = new LinkedListCycleFinder().DetectCycle(head);

        result.Should().Be(head);
    }
}
