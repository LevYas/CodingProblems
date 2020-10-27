using CodingProblems.Graphs;
using FluentAssertions;
using Xunit;

namespace CodingProblemsTests.Graphs
{
    public class SudokuSolver_SolveSudoku
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void SolvesSudoku(char[][] board, char[][] expectedBoard)
        {
            SudokuSolver.SolveSudoku(board);

            for (int y = 0; y < expectedBoard.Length; y++)
            {
                for (int x = 0; x < expectedBoard[y].Length; x++)
                    board[y][x].Should().Be(expectedBoard[y][x]);
            }
        }

        public static object[][] TestData()
        {
            return new[]
            {
                new object[] { new[]
                    {
                        new[]{ '5', '3', '.',  '.', '7', '.',  '.', '.', '.' },
                        new[]{ '6', '.', '.',  '1', '9', '5',  '.', '.', '.' },
                        new[]{ '.', '9', '8',  '.', '.', '.',  '.', '6', '.' },

                        new[]{ '8', '.', '.',  '.', '6', '.',  '.', '.', '3' },
                        new[]{ '4', '.', '.',  '8', '.', '3',  '.', '.', '1' },
                        new[]{ '7', '.', '.',  '.', '2', '.',  '.', '.', '6' },

                        new[]{ '.', '6', '.',  '.', '.', '.',  '2', '8', '.' },
                        new[]{ '.', '.', '.',  '4', '1', '9',  '.', '.', '5' },
                        new[]{ '.', '.', '.',  '.', '8', '.',  '.', '7', '9' },
                    },
                    new[]
                    {
                        new[]{ '5', '3', '4',  '6', '7', '8',  '9', '1', '2' },
                        new[]{ '6', '7', '2',  '1', '9', '5',  '3', '4', '8' },
                        new[]{ '1', '9', '8',  '3', '4', '2',  '5', '6', '7' },

                        new[]{ '8', '5', '9',  '7', '6', '1',  '4', '2', '3' },
                        new[]{ '4', '2', '6',  '8', '5', '3',  '7', '9', '1' },
                        new[]{ '7', '1', '3',  '9', '2', '4',  '8', '5', '6' },

                        new[]{ '9', '6', '1',  '5', '3', '7',  '2', '8', '4' },
                        new[]{ '2', '8', '7',  '4', '1', '9',  '6', '3', '5' },
                        new[]{ '3', '4', '5',  '2', '8', '6',  '1', '7', '9' },
                    },
                },
            };
        }
    }
}
