using CodingProblems;
using Xunit;

namespace CodingProblemsTests
{
    public class OtherProblemsTests
    {
        [Theory]
        [MemberData(nameof(FindMinClassroomsAmountTestData))]
        public void FindMinClassroomsAmountTest((int, int)[] intervals, int expected)
        {
            Assert.Equal(expected, OtherProblems.FindMinClassroomsAmount(intervals));
        }

        public static TheoryData<(int, int)[], int> FindMinClassroomsAmountTestData => new TheoryData<(int, int)[], int>
            {
                { new[] { (30, 75), (0, 50), (60, 150) }, 2 }
            };

        [Theory]
        [MemberData(nameof(ReverseBetweenTestData))]
        public void ReverseBetweenTest(ListNode sourseList, int beg, int end, int[] expectedValues)
        {
            ListNode resultingList = LinkedListReverser.ReverseBetween(sourseList, beg, end);
            ListNode currentNode = resultingList;

            foreach (int expectedVal in expectedValues)
            {
                Assert.Equal(expectedVal, currentNode.val);
                currentNode = currentNode.next;
            }
        }

        public static object[][] ReverseBetweenTestData()
        {
            return new object[][]
            {
                new object[] { createFilledLinkedList(1), 1, 1, new[] { 1 } },

                new object[] { createFilledLinkedList(2), 1, 1, new[] { 1, 2 } },
                new object[] { createFilledLinkedList(2), 2, 2, new[] { 1, 2 } },
                new object[] { createFilledLinkedList(2), 1, 2, new[] { 2, 1 } },

                new object[] { createFilledLinkedList(5), 3, 3, new[] { 1, 2, 3, 4, 5 } },
                new object[] { createFilledLinkedList(5), 2, 4, new[] { 1, 4, 3, 2, 5 } },
                new object[] { createFilledLinkedList(5), 1, 5, new[] { 5, 4, 3, 2, 1 } },
            };
        }

        private static ListNode createFilledLinkedList(int length)
        {
            if (length < 1)
                return null;

            ListNode head = new ListNode(1);
            ListNode last = head;
            for (int i = 2; i <= length; i++)
            {
                last.next = new ListNode(i);
                last = last.next;
            }

            return head;
        }
    }
}
