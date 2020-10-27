using CodingProblems.Lists;
using CodingProblems.Utility;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Lists
{
    public class ListCopier_CopyRandomList
    {
        [Theory]
        [MemberData(nameof(CopyRandomListTestData))]
        public void PreservesValues(NodeWithRandom input)
        {
            string initialListValues = input.PrintValues();

            ListCopier.CopyRandomList(input).PrintValues().Should().Be(initialListValues);
        }

        [Theory]
        [MemberData(nameof(CopyRandomListTestData))]
        public void MakesNewObjects(NodeWithRandom input)
        {
            NodeWithRandom copied = ListCopier.CopyRandomList(input);

            while (input != null)
            {
                copied.Should().NotBe(input);
                input = input.next;
                copied = copied.next;
            }
        }

        [Fact]
        public void ReturnsNullOnEmptyInput()
        {
            ListCopier.CopyRandomList(null).Should().BeNull();
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
