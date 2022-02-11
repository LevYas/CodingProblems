using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Indices;

// You are given an m x n grid where each cell can have one of three values:
//      0 representing an empty cell,
//      1 representing a fresh orange, or
//      2 representing a rotten orange.
// Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.
// Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.
// https://leetcode.com/problems/rotting-oranges/

public class RottingOrangesSolver
{
    public int Solve(int[][] grid)
    {
        int maxMinutes = 0;
        Queue<(int, int, int)> rotten = new();
        int freshOrangesAmount = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    freshOrangesAmount++;
                    continue;
                }

                if (grid[i][j] != 2)
                    continue;

                rotten.Enqueue((i, j, 0));
            }
        }

        if (freshOrangesAmount == 0)
            return 0;

        while (rotten.Any())
        {
            (int currentY, int currentX, int minute) = rotten.Dequeue();

            if (minute > maxMinutes)
                maxMinutes = minute;

            bool isRotable(int y, int x) => grid[y][x] == 1;

            void rotAndMark(int y, int x)
            {
                grid[y][x] = 2;
                rotten.Enqueue((y, x, minute + 1));
                freshOrangesAmount--;
            }

            if (currentX > 0 && isRotable(currentY, currentX - 1))
                rotAndMark(currentY, currentX - 1);

            if (currentX < grid[currentY].Length - 1 && isRotable(currentY, currentX + 1))
                rotAndMark(currentY, currentX + 1);

            if (currentY > 0 && isRotable(currentY - 1, currentX))
                rotAndMark(currentY - 1, currentX);

            if (currentY < grid.Length - 1 && isRotable(currentY + 1, currentX))
                rotAndMark(currentY + 1, currentX);
        }

        return freshOrangesAmount == 0 ? maxMinutes : -1;
    }

    public int SolveUsingBruteforce(int[][] grid)
    {
        int minuteCounter = 0;
        bool hasRottenOrangesOnLastStep;
        HashSet<(int, int)> justRottenIds = new();

        do
        {
            hasRottenOrangesOnLastStep = false;
            justRottenIds.Clear();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int current = grid[i][j];

                    if (current != 2 || justRottenIds.Contains((i, j)))
                        continue;

                    if (j > 0 && grid[i][j - 1] == 1)
                    {
                        grid[i][j - 1] = 2;
                        justRottenIds.Add((i, j - 1));
                        hasRottenOrangesOnLastStep = true;
                    }

                    if (j < grid[i].Length - 1 && grid[i][j + 1] == 1)
                    {
                        grid[i][j + 1] = 2;
                        justRottenIds.Add((i, j + 1));
                        hasRottenOrangesOnLastStep = true;
                    }

                    if (i > 0 && grid[i - 1][j] == 1)
                    {
                        grid[i - 1][j] = 2;
                        justRottenIds.Add((i - 1, j));
                        hasRottenOrangesOnLastStep = true;
                    }

                    if (i < grid.Length - 1 && grid[i + 1][j] == 1)
                    {
                        grid[i + 1][j] = 2;
                        justRottenIds.Add((i + 1, j));
                        hasRottenOrangesOnLastStep = true;
                    }
                }
            }

            if (hasRottenOrangesOnLastStep)
                minuteCounter++;

        } while (hasRottenOrangesOnLastStep);


        foreach (int[] row in grid)
        {
            foreach (int val in row)
            {
                if (val == 1)
                    return -1;
            }
        }

        return minuteCounter;
    }
}