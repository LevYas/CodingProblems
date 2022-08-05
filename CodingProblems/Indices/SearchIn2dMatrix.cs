using System.Collections;

namespace CodingProblems.Indices;

// 74. Search a 2D Matrix
// Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:
// Integers in each row are sorted from left to right.
// The first integer of each row is greater than the last integer of the previous row.
// https://leetcode.com/problems/search-a-2d-matrix/

public class SearchIn2dMatrix
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int row = Array.BinarySearch(matrix, target, new MyComparer());

        if (row >= 0) // Means the exact value was found
            return true;

        // Otherwise it points to the first value larger than target, but we need the previous row
        row = ~row - 1;

        if (row < 0) // If initially array had only one wrong element
            return false;

        return Array.BinarySearch(matrix[row], target) > 0;
    }

    private class MyComparer : IComparer
    {
        public int Compare(object x, object y) => ((int[])x)[0].CompareTo(y);
    }
}
