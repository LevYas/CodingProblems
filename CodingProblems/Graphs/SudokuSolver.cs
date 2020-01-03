namespace CodingProblems.Graphs
{
    public static class SudokuSolver
    {
        // Write a program to solve a Sudoku puzzle by filling the empty cells.
        // A sudoku solution must satisfy all of the following rules:
        // - Each of the digits 1-9 must occur exactly once in each row.
        // - Each of the digits 1-9 must occur exactly once in each column.
        // - Each of the the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
        // Empty cells are indicated by the character '.'.
        // https://leetcode.com/problems/sudoku-solver/
        public static void SolveSudoku(char[][] board)
        {
            trySolveSudoku(board, (0, 0));
        }

        private static bool trySolveSudoku(char[][] board, (short y, short x) startCoords)
        {
            for (short y = startCoords.y; y < 9; y++)
            {
                for (short x = startCoords.x; x < 9; x++)
                {
                    if (board[y][x] >= '1' && board[y][x] <= '9')
                        continue;

                    for (char i = '1'; i <= '9'; i++)
                    {
                        board[y][x] = i;

                        if (isDigitValid(board, (y, x)) && trySolveSudoku(board, (y, x)))
                            return true;

                        board[y][x] = '.';
                    }

                    if (board[y][x] == '.')
                        return false;
                }

                startCoords.x = 0;
            }

            return true;
        }

        private static bool isDigitValid(char[][] board, (short y, short x) coords)
        {
            char digit = board[coords.y][coords.x];

            for (short i = 0; i < 9; i++)
            {
                if (i != coords.y && board[i][coords.x] == digit)
                    return false;

                if (i != coords.x && board[coords.y][i] == digit)
                    return false;
            }

            short subGridStartX = (short)(coords.x - (coords.x % 3));
            short subGridStartY = (short)(coords.y - (coords.y % 3));

            for (short y = subGridStartY; y < subGridStartY + 3; y++)
            {
                for (short x = subGridStartX; x < subGridStartX + 3; x++)
                {
                    if (y != coords.y && x != coords.x && board[y][x] == digit)
                        return false;
                }
            }

            return true;
        }
    }
}
