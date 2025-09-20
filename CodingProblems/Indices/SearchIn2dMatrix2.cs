namespace CodingProblems.Indices;

// Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix.
// This matrix has the following properties:
//      Integers in each row are sorted in ascending from left to right.
//      Integers in each column are sorted in ascending from top to bottom.
// https://leetcode.com/problems/search-a-2d-matrix-ii/description/

public class SearchIn2dMatrix2
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        foreach (int[] row in matrix)
        {
            if (row[^1] < target)
                continue;

            if (row[0] > target)
                return false;

            if (Array.BinarySearch(row, target) >= 0)
                return true;
        }

        return false;
    }
}
