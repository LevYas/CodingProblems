using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class Graphs
    {
        // Given an undirected graph, return true if and only if it is bipartite.
        // https://leetcode.com/problems/is-graph-bipartite/
        public static bool IsGraphBipartite(int[][] graph)
        {
            if (graph.Length <= 2)
                return true;

            // -1 for color1, 0 for unset, 1 for color2
            sbyte[] colors = new sbyte[graph.Length];

            for (int i = 0; i < graph.Length; ++i)
            {
                if (colors[i] == 0)
                    colors[i] = -1;

                if (!paintConnectedVertices(graph, colors, i))
                    return false;
            }

            return true;
        }

        private static bool paintConnectedVertices(int[][] graph, sbyte[] colors, int currentVrtx)
        {
            foreach (int connectedIdx in graph[currentVrtx])
            {
                if (colors[connectedIdx] == colors[currentVrtx])
                    return false;

                if (colors[connectedIdx] == 0)
                {
                    colors[connectedIdx] = (sbyte)(colors[currentVrtx] == 1 ? -1 : 1);
                    paintConnectedVertices(graph, colors, connectedIdx);
                }
            }

            return true;
        }

        // Given a set of N people (numbered 1, 2, ..., N), we would like to split everyone into two groups of any size.
        // Each person may dislike some other people, and they should not go into the same group.
        // https://leetcode.com/problems/possible-bipartition/
        public static bool PossibleBipartition(int n, int[][] dislikes)
        {
            if (dislikes.Length <= 2)
                return true;

            // -1 for color, 0 for unset, 1 for color2
            sbyte[] colors = new sbyte[n];

            Dictionary<short, List<short>> personToAllDislikes = new Dictionary<short, List<short>>(n);

            for (short i = 0; i < n; i++)
                personToAllDislikes.Add(i, new List<short>());

            foreach (int[] entry in dislikes)
            {
                short person1Idx = (short)(entry[0] - 1);
                short person2Idx = (short)(entry[1] - 1);

                personToAllDislikes[person1Idx].Add(person2Idx);
                personToAllDislikes[person2Idx].Add(person1Idx);
            }

            Queue<short> queue = new Queue<short>();

            while (personToAllDislikes.Any())
            {
                short startingIdx = personToAllDislikes.First().Key;
                colors[startingIdx] = -1;
                queue.Enqueue(startingIdx);

                while (queue.Any() && personToAllDislikes.Any())
                {
                    short idxToProcess = queue.Dequeue();
                    sbyte currentColor = colors[idxToProcess];

                    foreach (short adjacentId in personToAllDislikes[idxToProcess])
                    {
                        sbyte adjacentColor = colors[adjacentId];
                        if (adjacentColor == currentColor)
                            return false;

                        if (adjacentColor == 0)
                        {
                            colors[adjacentId] = (sbyte)(currentColor == 1 ? -1 : 1);
                            queue.Enqueue(adjacentId);
                        }
                    }

                    personToAllDislikes.Remove(idxToProcess);
                }
            }

            return true;
        }
    }
}
