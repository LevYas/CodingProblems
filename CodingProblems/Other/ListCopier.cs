using CodingProblems.Utility;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CodingProblems.Other
{
    public static class ListCopier
    {
        public static NodeWithRandom CopyRandomList(NodeWithRandom head)
        {
            if (head == null)
                return null;

            NodeWithRandom preHeadCopy = new NodeWithRandom(-1);

            NodeWithRandom current = head;
            NodeWithRandom currentCopy = preHeadCopy;

            var index = new Dictionary<NodeWithRandom, NodeWithRandom>();

            while (current != null)
            {
                currentCopy.next = new NodeWithRandom(current.val);
                currentCopy = currentCopy.next;

                index[current] = currentCopy;

                current = current.next;
            }

            current = head;
            NodeWithRandom headCopy = preHeadCopy.next;
            currentCopy = headCopy;

            while (current != null)
            {
                currentCopy.random = current.random == null ? null : index[current.random];

                currentCopy = currentCopy.next;
                current = current.next;
            }

            return headCopy;
        }
    }

    public class NodeWithRandom : DebugLinkedList
    {
        public NodeWithRandom(int nodeVal) : base(nodeVal) { }

        public NodeWithRandom next
        {
            get => NextNode as NodeWithRandom;
            set => NextNode = value;
        }

        public int val => Value;

        public NodeWithRandom random { get; set; }

        public new string PrintValues()
        {
            StringBuilder sb = new StringBuilder();

            ForAll<NodeWithRandom>(node =>
            {
                string rndIndex = node.random == null ? "null" : node.random.val.ToString(CultureInfo.InvariantCulture);
                sb.Append($"[{node.val},{rndIndex}]" + (node.next == null ? "" : ","));
            });

            return sb.ToString();
        }
    }
}
