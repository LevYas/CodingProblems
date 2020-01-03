using System.Linq;

namespace CodingProblems
{
    public static class OtherProblems
    {
        // Given an array of time intervals (start, end) for classroom lectures (possibly overlapping),
        // find the minimum number of rooms required.
        public static int FindMinClassroomsAmount((int beg, int end)[] intervals)
        {
            int currentlyOccupiedRooms = 0;

            return intervals.SelectMany(interval => new (int time, int occupationChange)[] { (interval.beg, 1), (interval.end, -1) })
               .OrderBy(i => i.time)
               .Max(occupanceChange =>
               {
                   currentlyOccupiedRooms += occupanceChange.occupationChange;
                   return currentlyOccupiedRooms;
               });
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            return $"val={val}, next='{(next == null ? "null" : next.val.ToString())}'";
        }
    }

    // Reverse a linked list from position m to n. Do it in one-pass.
    // Note: 1 ≤ m ≤ n ≤ length of list.
    // https://leetcode.com/problems/reverse-linked-list-ii/
    public static class LinkedListReverser
    {
        public static ListNode ReverseBetween(ListNode head, int begPos, int endPos)
        {
            ListNode prev  = null;
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

                ListNode next = current.next;

                if (currentPos > begPos && currentPos <= endPos)
                    current.next = prev;

                prev = current;
                current = next;
            }

            if (beforeBegPosNode != null)
                beforeBegPosNode.next = endPosNode;
            else
                head = endPosNode;

            begPosNode.next = afterEndPosNode;

            return head;
        }
    }
}
