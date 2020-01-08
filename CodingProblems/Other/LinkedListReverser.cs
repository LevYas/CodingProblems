using CodingProblems.Utility;

namespace CodingProblems.Other
{
    public class ListNode : DebugLinkedList
    {
        public ListNode(int x) : base(x) { }

        public ListNode Next
        {
            get => NextNode as ListNode;
            set => NextNode = value;
        }

        public int Val => Value;
    }

    // Reverse a linked list from position m to n. Do it in one-pass.
    // Note: 1 ≤ m ≤ n ≤ length of list.
    // https://leetcode.com/problems/reverse-linked-list-ii/
    public static class LinkedListReverser
    {
        public static ListNode ReverseBetween(ListNode head, int begPos, int endPos)
        {
            ListNode prev = null;
            ListNode current = head;

            ListNode beforeBegPosNode = null;
            ListNode begPosNode = null;

            ListNode endPosNode = null;
            ListNode afterEndPosNode = null;

            for (int currentPos = 1; currentPos <= endPos + 1; currentPos++)
            {
                if (currentPos == begPos - 1)
                    beforeBegPosNode = current;
                else if (currentPos == begPos)
                    begPosNode = current;

                if (currentPos == endPos)
                    endPosNode = current;
                else if (currentPos == endPos + 1)
                {
                    afterEndPosNode = current;
                    break;
                }

                ListNode next = current.Next;

                if (currentPos > begPos && currentPos <= endPos)
                    current.Next = prev;

                prev = current;
                current = next;
            }

            if (beforeBegPosNode != null)
                beforeBegPosNode.Next = endPosNode;
            else
                head = endPosNode;

            begPosNode.Next = afterEndPosNode;

            return head;
        }
    }
}
