using CodingProblems.Utility;

namespace CodingProblems.Lists;

public class ListNode : DebugLinkedList
{
    public ListNode(int val) : base(val) {}

    public ListNode(int val = 0, ListNode next = null) : base(val)
    {
        NextNode = next;
    }

    public ListNode Next
    {
        get => NextNode as ListNode;
        set => NextNode = value;
    }

    public int Val => Value;
}