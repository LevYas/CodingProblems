using System;
using System.Globalization;
using System.Text;

namespace CodingProblems.Utility
{
    public abstract class DebugLinkedList
    {
        public DebugLinkedList(int x) { Value = x; }

        public DebugLinkedList NextNode { get; set; }
        protected int Value { get; set; }
        public int Index { get; set; } = 0;

        public TList ForAll<TList>(Action<TList> action) where TList: DebugLinkedList
        {
            TList current = (TList)this;

            while (current != null)
            {
                action(current);
                current = (TList)current.NextNode;
            }

            return (TList)this;
        }

        public DebugLinkedList this[int key]
        {
            get
            {
                DebugLinkedList current = this;
                while (current.Index != key)
                {
                    if (current.NextNode != null)
                        current = current.NextNode;
                    else
                        throw new ArgumentOutOfRangeException(nameof(key));

                    continue;
                }

                return current;
            }
        }

        public string PrintValues()
        {
            StringBuilder sb = new StringBuilder();
            ForAll<DebugLinkedList>(node => sb.Append($"{node.Value}" + (node.NextNode == null ? "" : ",")));
            return sb.ToString();
        }

        public override string ToString()
        {
            string nextNodeValue = NextNode == null ? "null" : NextNode.Value.ToString(CultureInfo.InvariantCulture);
            return $"val= {Value}, next= {nextNodeValue}";
        }
    }
}
