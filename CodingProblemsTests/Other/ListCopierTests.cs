using CodingProblems.Other;
using CodingProblems.Utility;
using System;
using System.Linq;
using Xunit;

namespace CodingProblemsTests.Other
{
    public class ListCopierTests
    {
        [Theory]
        [MemberData(nameof(CopyRandomListTestData))]
        public void CopiedListContainsTheSameValues(NodeWithRandom input)
        {
            string initialListVals = input.PrintValues();

            Assert.Equal(initialListVals, ListCopier.CopyRandomList(input).PrintValues());
        }

        [Theory]
        [MemberData(nameof(CopyRandomListTestData))]
        public void CopiedListConsistOfAnotherObjects(NodeWithRandom input)
        {
            var copied = ListCopier.CopyRandomList(input);

            while (input != null)
            {
                Assert.NotSame(input, copied);
                input = input.next;
                copied = copied.next;
            }
        }

        [Fact]
        public void ReturnsNullOnEmptyInput()
        {
            Assert.Null(ListCopier.CopyRandomList(null));
        }

        public static TheoryData<NodeWithRandom> CopyRandomListTestData => new TheoryData<NodeWithRandom>
        {
            createListWithRndValues(new (int, int?)[] { (0, 0), (1, 2), (2, null), (3, 1) }),
            createListWithRndValues(new (int, int?)[] { (7, null), (13, 0), (11, 4), (10, 2), (1, 0) }),
            createListWithRndValues(new (int, int?)[] { (1, 1), (2, 1) }),
            createListWithRndValues(new (int, int?)[] { (3, null), (3, 0), (3, null) }),
        };

        private static NodeWithRandom createListWithRndValues((int val, int? rndIdx)[] values)
        {
            NodeWithRandom head = DebugLinkedListFactory.Create<NodeWithRandom>(values.Select(v => v.val).ToArray());

            return head.ForAll<NodeWithRandom>(node =>
                node.random = (NodeWithRandom)(values[node.Index].rndIdx == null ? null : head[values[node.Index].rndIdx.Value]));
        }
    }
}
