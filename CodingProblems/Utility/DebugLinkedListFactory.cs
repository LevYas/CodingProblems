using System;

namespace CodingProblems.Utility
{
    public static class DebugLinkedListFactory
    {
        public static TList Create<TList>(int[] values) where TList : DebugLinkedList
        {
            if (values.Length == 0)
                return null;

            TList head = createNode<TList>(values[0]);
            TList last = head;
            for (int i = 1; i < values.Length; i++)
            {
                last.NextNode = createNode<TList>(values[i]);
                last.NextNode.Index = i;
                last = (TList)last.NextNode;
            }

            return head;
        }

        private static TList createNode<TList>(int val) => (TList)Activator.CreateInstance(typeof(TList), new object[] { val });
    }
}
