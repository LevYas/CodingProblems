namespace CodingProblems.Indices;

// 417. Pacific Atlantic Water Flow
// There is an m x n rectangular island that borders both the Pacific Ocean and Atlantic Ocean.
// The Pacific Ocean touches the island's left and top edges, and the Atlantic Ocean touches the island's right and bottom edges.

// The island is partitioned into a grid of square cells. You are given an m x n integer matrix heights where heights[r][c] represents
// the height above sea level of the cell at coordinate (r, c).

// The island receives a lot of rain, and the rain water can flow to neighboring cells directly
// north, south, east, and west if the neighboring cell's height is less than or equal to the current cell's height.
// Water can flow from any cell adjacent to an ocean into the ocean.

// Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes that rain water can flow
// from cell (ri, ci) to both the Pacific and Atlantic oceans.
// https://leetcode.com/problems/pacific-atlantic-water-flow/

public class PacificAtlanticFlowFinder
{
    public IList<IList<int>> FindFlows(int[][] heights)
    {
        bool[][] toPacific = new bool[heights.Length][];
        bool[][] toAtlantic = new bool[heights.Length][];

        for (int i = 0; i < heights.Length; i++)
        {
            toPacific[i] = new bool[heights[i].Length];
            toAtlantic[i] = new bool[heights[i].Length];
        }

        List<(int r, int c)> nearPacific = new();
        List<(int r, int c)> nearAtlantic = new();

        int rows = heights.Length;
        int cols = heights[0].Length;

        // filling with left and right side
        for (int r = 0; r < rows; r++)
        {
            nearPacific.Add((r, 0));
            nearAtlantic.Add((r, cols - 1));
        }

        // top and bottom
        for (int c = 0; c < cols; c++)
        {
            nearPacific.Add((0, c));
            nearAtlantic.Add((rows - 1, c));
        }

        floodTheIsland(nearPacific, heights, toPacific);
        floodTheIsland(nearAtlantic, heights, toAtlantic);

        List<List<int>> result = new();

        for (int r = 0; r < heights.Length; r++)
        {
            for (int c = 0; c < heights[r].Length; c++)
            {
                if (toPacific[r][c] && toAtlantic[r][c])
                    result.Add(new() { r, c });
            }
        }

        return result.Cast<IList<int>>().ToList();
    }

    private void floodTheIsland(List<(int r, int c)> startingCoords, int[][] heights, bool[][] result)
    {
        Queue<(int r, int c)> toMarkAsFlooded = new(startingCoords);
        bool[][] visited = new bool[heights.Length][];

        for (int i = 0; i < heights.Length; i++)
            visited[i] = new bool[heights[i].Length];

        while (toMarkAsFlooded.Any())
        {
            (int r, int c) = toMarkAsFlooded.Dequeue();

            if (visited[r][c])
                continue;

            visited[r][c] = true;
            result[r][c] = true;

            int currentHeight = heights[r][c];

            foreach ((int nr, int nc) in getNeighborCoords(heights.Length, heights[0].Length, r, c))
            {
                // we simulate the opposite of the rain direction, from ocean to the top
                // if the neighbor height is less, we skip it, since water will not be able to go from the lower level
                if (heights[nr][nc] < currentHeight || visited[nr][nc])
                    continue;

                toMarkAsFlooded.Enqueue((nr, nc));
            }
        }
    }

    private IEnumerable<(int, int)> getNeighborCoords(int height, int width, int r, int c)
    {
        if (r < height - 1)
            yield return (r + 1, c);

        if (c < width - 1)
            yield return (r, c + 1);

        if (r > 0)
            yield return (r - 1, c);

        if (c > 0)
            yield return (r, c - 1);
    }
}
