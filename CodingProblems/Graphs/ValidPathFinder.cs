namespace CodingProblems.Graphs;

// 1971. Find if Path Exists in Graph
// There is a bi-directional graph with n vertices, where each vertex is labeled from 0 to n - 1 (inclusive).
// The edges in the graph are represented as a 2D integer array edges,
//      where each edges[i] = [ui, vi] denotes a bi-directional edge between vertex ui and vertex vi.
// Every vertex pair is connected by at most one edge, and no vertex has an edge to itself.
// You want to determine if there is a valid path that exists from vertex source to vertex destination.
// Given edges and the integers n, source, and destination, return true if there is a valid path from
//      source to destination, or false otherwise.
// https://leetcode.com/problems/find-if-path-exists-in-graph/

public class ValidPathFinder
{
    public bool Find(int n, int[][] edges, int source, int destination)
    {
        Dictionary<int, List<int>> adjacency = new();

        void addEdge(int v1, int v2)
        {
            adjacency.TryAdd(v1, new List<int>());
            adjacency[v1].Add(v2);
        }

        foreach (int[] edge in edges)
        {
            addEdge(edge[0], edge[1]);
            addEdge(edge[1], edge[0]);
        }

        HashSet<int> visited = new();
        Queue<int> queue = new();

        queue.Enqueue(source);

        while (queue.Any())
        {
            int vertex = queue.Dequeue();
            visited.Add(vertex);

            if (vertex == destination)
                return true;

            if (!adjacency.ContainsKey(vertex))
                continue;

            foreach (int nextVertex in adjacency[vertex])
            {
                if (!visited.Contains(nextVertex))
                    queue.Enqueue(nextVertex);
            }
        }

        return false;
    }
}
