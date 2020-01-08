using CodingProblems.Lists;
using CodingProblems.Utility;
using Xunit;

namespace CodingProblemsTests.Lists
{
    public class LinkedListReverserTests
    {
        [Theory]
        [MemberData(nameof(ReverseBetweenTestData))]
        public void ReverseBetweenTest(ListNode sourseList, int beg, int end, int[] expectedValues)
        {
            ListNode resultingList = LinkedListReverser.ReverseBetween(sourseList, beg, end);
            ListNode currentNode = resultingList;

            foreach (int expectedVal in expectedValues)
            {
                Assert.Equal(expectedVal, currentNode.Val);
                currentNode = currentNode.Next;
            }
        }

        public static object[][] ReverseBetweenTestData()
        {
            return new object[][]
            {
                new object[] { DebugLinkedListFactory.Create<ListNode>(new[] { 1 }), 1, 1, new[] { 1 } },

                new object[] { DebugLinkedListFactory.Create<ListNode>(new[] { 1, 2 }), 1, 1, new[] { 1, 2 } },
                new object[] { DebugLinkedListFactory.Create<ListNode>(new[] { 1, 2 }), 2, 2, new[] { 1, 2 } },
                new object[] { DebugLinkedListFactory.Create<ListNode>(new[] { 1, 2 }), 1, 2, new[] { 2, 1 } },

                new object[] { DebugLinkedListFactory.Create<ListNode>(new[] { 1, 2, 3, 4, 5 }), 3, 3, new[] { 1, 2, 3, 4, 5 } },
                new object[] { DebugLinkedListFactory.Create<ListNode>(new[] { 1, 2, 3, 4, 5 }), 2, 4, new[] { 1, 4, 3, 2, 5 } },
                new object[] { DebugLinkedListFactory.Create<ListNode>(new[] { 1, 2, 3, 4, 5 }), 1, 5, new[] { 5, 4, 3, 2, 1 } },
            };
        }
    }
}
