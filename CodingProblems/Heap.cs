using System;
using System.Text;

namespace CodingProblems
{
    public static class HeapPrinter
    {
        public static void PrintHeap()
        {
            var heap = new Heap();

            foreach (int val in new[] { 7, 5, 6, 4, 8, 10, 2, 3, 1, 9, 11 })
            {
                heap.Add(val);
            }

            Console.WriteLine(heap.Print());
        }
    }

    internal class Heap
    {
        private readonly int[] _nodes = new int[1000];
        private int _numNodes;

        public void Add(int val)
        {
            _nodes[_numNodes] = val;
            correctNodePos(_numNodes++);
        }

        private void correctNodePos(int nodeIdx)
        {
            if (nodeIdx == 0)
                return;

            int upperNodeIdx = (nodeIdx - 1) / 2;

            int currNodeVal = _nodes[nodeIdx];
            int upperNodeVal = _nodes[upperNodeIdx];

            if (currNodeVal < upperNodeVal)
                return;

            _nodes[nodeIdx] = upperNodeVal;
            _nodes[upperNodeIdx] = currNodeVal;
            correctNodePos(upperNodeIdx);
        }

        public string Print()
        {
            int linesCount = (int)Math.Log(_numNodes, 2) + 1;

            StringBuilder sb = new StringBuilder();

            for (int lineIdx = 0; lineIdx <= linesCount; ++lineIdx)
            {
                sb.Append(' ', (linesCount - lineIdx) * 2);

                int startIdx = (int)Math.Pow(2, lineIdx) - 1;
                int endIdx = (int)Math.Pow(2, lineIdx + 1) - 2;

                for (int i = startIdx; i <= endIdx && i < _numNodes; ++i)
                {
                    sb.Append(' ', 2 * (linesCount - lineIdx));
                    sb.Append(_nodes[i]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
