using CodingProblems.Lists;
using CodingProblems.Utility;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Lists
{
    public class LinkedListReverser_ReverseBetween
    {
        [Theory]
        [MemberData(nameof(ReverseBetweenTestData))]
        public void Works(ListNode sourceList, int beg, int end, int[] expectedValues)
        {
            ListNode resultingList = LinkedListReverser.ReverseBetween(sourceList, beg, end);
            ListNode currentNode = resultingList;

            foreach (int expectedVal in expectedValues)
            {
                currentNode.Val.Should().Be(expectedVal);
                currentNode = currentNode.Next;
            }
        }

        public static object[][] ReverseBetweenTestData()
        {
            return new[]
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
