using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class OtherProblems
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

        // The n-queens puzzle is the problem of placing n queens on an n×n chessboard such 
        // that no two queens attack each other.
        // Given an integer n, return all distinct solutions to the n-queens puzzle.
        // Each solution contains a distinct board configuration of the n-queens' placement,
        // where 'Q' and '.' both indicate a queen and an empty space respectively.
        // https://leetcode.com/problems/n-queens/
        // Right answers here: https://oeis.org/A000170
        public static IList<IList<string>> SolveNQueens(int n)
        {
            if (n == 1)
                return new List<IList<string>>() { new List<string>() { "Q" } };

            if (n == 2 || n == 3)
                return new List<IList<string>>();

            var results = new List<IList<string>>();

            solveNQueens(results, n, new List<int>());

            return results;
        }

        private static void solveNQueens(List<IList<string>> results, int n, List<int> queensIds)
        {
            if (queensIds.Count == n)
            {
                results.Add(printBoard(queensIds, n));
                return;
            }

            for (int x = 0; x < n; x++)
            {
                queensIds.Add(x);

                if (isLastQueenPlacementValid(queensIds))
                    solveNQueens(results, n, queensIds);

                queensIds.RemoveAt(queensIds.Count - 1);
            }
        }

        private static bool isLastQueenPlacementValid(List<int> queensIds)
        {
            int lastQueenY = queensIds.Count - 1;
            int lastQueenX = queensIds[lastQueenY];

            for (int y = 0; y < lastQueenY; y++)
            {
                int diff = Math.Abs(queensIds[y] - lastQueenX);

                if (diff == 0 || diff == lastQueenY - y)
                    return false;
            }

            return true;
        }

        private static IList<string> printBoard(List<int> queensIds, int n)
        {
            var rows = new List<string>(n);

            for (int y = 0; y < n; y++)
                rows.Add(new string('.', queensIds[y]) + "Q" + new string('.', n - queensIds[y] - 1));

            return rows;
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
    public class LinkedListReverser
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
