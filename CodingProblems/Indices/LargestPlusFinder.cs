using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Indices;

// 764. Largest Plus Sign
// You are given an integer n.
// You have an n x n binary grid grid with all values initially 1's except for some indices given in the array mines.
// The ith element of the array mines is defined as mines[i] = [xi, yi] where grid[xi][yi] == 0.
// Return the order of the largest axis-aligned plus sign of 1's contained in grid. If there is none, return 0.
// An axis-aligned plus sign of 1's of order k has some center grid[r][c] == 1 along with
//      four arms of length k - 1 going up, down, left, and right, and made of 1's.
// Note that there could be 0's or 1's beyond the arms of the plus sign, only the relevant area of the plus sign is checked for 1's.
// https://leetcode.com/problems/largest-plus-sign/

public class LargestPlusFinder
{
    public int OrderOfLargestPlusSign(int n, int[][] mines)
    {
        HashSet<(int r, int c)> minesSet = new();

        foreach (int[] mine in mines)
            minesSet.Add((mine[0], mine[1]));

        int[][] rowsLR = new int[n][];
        int[][] rowsRL = new int[n][];
        int[][] colsTB = new int[n][];
        int[][] colsBT = new int[n][];

        for (int r = 0; r < n; r++)
        {
            rowsLR[r] = new int[n];
            colsTB[r] = new int[n];

            for (int c = 0; c < n; c++)
            {
                if (minesSet.Contains((r, c)))
                    continue;

                rowsLR[r][c] = (c > 0 ? rowsLR[r][c - 1] : 0) + 1;
                colsTB[r][c] = (r > 0 ? colsTB[r - 1][c] : 0) + 1;
            }
        }

        for (int r = n - 1; r >= 0; r--)
        {
            rowsRL[r] = new int[n];
            colsBT[r] = new int[n];

            for (int c = n - 1; c >= 0; c--)
            {
                if (minesSet.Contains((r, c)))
                    continue;

                rowsRL[r][c] = (c < n - 1 ? rowsRL[r][c + 1] : 0) + 1;
                colsBT[r][c] = (r < n - 1 ? colsBT[r + 1][c] : 0) + 1;
            }
        }

        int result = 0;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (minesSet.Contains((r, c)))
                    continue;

                int[] toSides = { rowsLR[r][c], rowsRL[r][c], colsTB[r][c], colsBT[r][c] };
                result = Math.Max(result, toSides.Min());
            }
        }

        return result;
    }
}
