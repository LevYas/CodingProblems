namespace CodingProblems.Graphs;

// You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally
//      (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.
// The area of an island is the number of cells with a value 1 in the island.
// Return the maximum area of an island in grid. If there is no island, return 0.
// https://leetcode.com/problems/max-area-of-island/
public class MaxAreaFinder
{
    // Solved using a classical union-find data structure
    public static int Find(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[] parents = new int[m * n];
        int[] sizes = new int[parents.Length];

        for (int i = 0; i < parents.Length; i++)
        {
            parents[i] = i;
            sizes[i] = 1;
        }

        bool foundAtLeastOne = false;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                    continue;

                foundAtLeastOne = true;

                int flatIdx = i * n + j;

                if (j + 1 < n && grid[i][j + 1] != 0)
                    union(parents, sizes, flatIdx, flatIdx + 1);

                if (i + 1 < m && grid[i + 1][j] != 0)
                    union(parents, sizes, flatIdx, flatIdx + n);
            }
        }

        return foundAtLeastOne ? sizes.Max() : 0;
    }

    // We do path compression during find.
    private static int find(int[] parents, int p)
    {
        while (p != parents[p])
            p = parents[p];

        return p;
    }

    // We do weighting here to always append to larger root to make the tree more flat
    private static void union(int[] parents, int[] sizes, int a, int b)
    {
        int rootA = find(parents, a);
        int rootB = find(parents, b);

        if (rootA == rootB)
            return;

        if (sizes[rootA] < sizes[rootB])
        {
            parents[rootA] = rootB;
            sizes[rootB] += sizes[rootA];
        }
        else
        {
            parents[rootB] = rootA;
            sizes[rootA] += sizes[rootB];
        }
    }
}
