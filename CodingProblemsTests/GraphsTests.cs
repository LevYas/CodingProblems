using CodingProblems;
using System.Collections.Generic;
using Xunit;
using CodingProblemsTests.Utility;

namespace CodingProblemsTests
{
    public class GraphsTests
    {
        [Theory]
        [MemberData(nameof(ArrsForIsGraphBipartite))]
        public void IsGraphBipartiteTest(int[][] graph, bool expected)
        {
            Assert.Equal(expected, Graphs.IsGraphBipartite(graph));
        }

        public static TheoryData<int[][], bool> ArrsForIsGraphBipartite
        {
            get => new TheoryData<int[][], bool>
                {
                    {
                        new int[][] { new[] { 1, 3 }, new[] { 0, 2 }, new[] { 1, 3 }, new[] { 0, 2 }, },
                        true
                    },
                    {
                        new int[][] { new[] { 1, 2, 3 }, new[] { 0, 2 }, new[] { 0, 1, 3 }, new[] { 0, 2 }, },
                        false
                    },
                    {
                        new int[][] { new[] { 4, 5 }, new[] { 2 }, new[] { 1 }, new int[] { }, new[] { 0 }, new[] { 0 },},
                        true
                    },
                    {
                        new int[][] { new[] { 4, 5 }, new[] { 3, 4, 5 }, new[] { 4 }, new[] { 1 }, new[] { 0, 1, 2 }, new[] { 0, 1 },},
                        true
                    },
                    {
                        new int[][] { new[] { 4, 5 }, new[] { 3, 4, 5 }, new[] { 4 }, new[] { 1 }, new[] { 0, 1, 2, 5 }, new[] { 0, 1, 4 },},
                        false
                    },
                };
        }

        [Theory]
        [MemberData(nameof(ArrsForPossibleBipartition))]
        public void PossibleBipartitionTest(int n, int[][] dislikes, bool expected)
        {
            Assert.Equal(expected, Graphs.PossibleBipartition(n, dislikes));
        }

        public static TheoryData<int, int[][], bool> ArrsForPossibleBipartition
        {
            get => new TheoryData<int, int[][], bool>
                {
                    {
                        5,
                        new int[][] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 5 }, new[] { 1, 5 } },
                        false
                    },

                    {
                        3,
                        new int[][] { new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 3 } },
                        false
                    },

                    {
                        4,
                        new int[][] { new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 4 } },
                        true
                    },

                    { 1, new int[][] { }, true },

                    {
                        5,
                        new int[][] { new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 4 } },
                        true
                    },

                    { 3, new int[][] { }, true },

                    {
                        5,
                        new int[][] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 4, 5 }, },
                        true
                    },

                    {
                        50,
                        "[[21, 47],[4, 41],[2, 41],[36, 42],[32, 45],[26, 28],[32, 44],[5, 41],[29, 44],[10, 46],[1, 6],[7, 42],[46, 49],[17, 46],[32, 35],[11, 48],[37, 48],[37, 43],[8, 41],[16, 22],[41, 43],[11, 27],[22, 44],[22, 28],[18, 37],[5, 11],[18, 46],[22, 48],[1, 17],[2, 32],[21, 37],[7, 22],[23, 41],[30, 39],[6, 41],[10, 22],[36, 41],[22, 25],[1, 12],[2, 11],[45, 46],[2, 22],[1, 38],[47, 50],[11, 15],[2, 37],[1, 43],[30, 45],[4, 32],[28, 37],[1, 21],[23, 37],[5, 37],[29, 40],[6, 42],[3, 11],[40, 42],[26, 49],[41, 50],[13, 41],[20, 47],[15, 26],[47, 49],[5, 30],[4, 42],[10, 30],[6, 29],[20, 42],[4, 37],[28, 42],[1, 16],[8, 32],[16, 29],[31, 47],[15, 47],[1, 5],[7, 37],[14, 47],[30, 48],[1, 10],[26, 43],[15, 46],[42, 45],[18, 42],[25, 42],[38, 41],[32, 39],[6, 30],[29, 33],[34, 37],[26, 38],[3, 22],[18, 47],[42, 48],[22, 49],[26, 34],[22, 36],[29, 36],[11, 25],[41, 44],[6, 46],[13, 22],[11, 16],[10, 37],[42, 43],[12, 32],[1, 48],[26, 40],[22, 50],[17, 26],[4, 22],[11, 14],[26, 39],[7, 11],[23, 26],[1, 20],[32, 33],[30, 33],[1, 25],[2, 30],[2, 46],[26, 45],[47, 48],[5, 29],[3, 37],[22, 34],[20, 22],[9, 47],[1, 4],[36, 46],[30, 49],[1, 9],[3, 26],[25, 41],[14, 29],[1, 35],[23, 42],[21, 32],[24, 46],[3, 32],[9, 42],[33, 37],[7, 30],[29, 45],[27, 30],[1, 7],[33, 42],[17, 47],[12, 47],[19, 41],[3, 42],[24, 26],[20, 29],[11, 23],[22, 40],[9, 37],[31, 32],[23, 46],[11, 38],[27, 29],[17, 37],[23, 30],[14, 42],[28, 30],[29, 31],[1, 8],[1, 36],[42, 50],[21, 41],[11, 18],[39, 41],[32, 34],[6, 37],[30, 38],[21, 46],[16, 37],[22, 24],[17, 32],[23, 29],[3, 30],[8, 30],[41, 48],[1, 39],[8, 47],[30, 44],[9, 46],[22, 45],[7, 26],[35, 42],[1, 27],[17, 30],[20, 46],[18, 29],[3, 29],[4, 30],[3, 46]]"
                            .ToArrays(),
                        true
                    }
                };
        }
    }

    public class NQueensSolverTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void SolveNQueensTest(int numberOfQueensAndSize, int solutionsAmount, IList<IList<string>> expectedBoards = null)
        {
            var result = NQueensSolver.SolveNQueens(numberOfQueensAndSize);

            Assert.Equal(solutionsAmount, result.Count);

            if (expectedBoards == null)
                return;

            for (int resultIdx = 0; resultIdx < expectedBoards.Count; resultIdx++)
            {
                for (int rowIdx = 0; rowIdx < expectedBoards[resultIdx].Count; rowIdx++)
                    Assert.Equal(expectedBoards[resultIdx][rowIdx], result[resultIdx][rowIdx]);
            }
        }

        public static object[][] TestData()
        {
            return new object[][]
            {
                new object[] { 0, 1 },
                new object[] { 1, 1, new List<IList<string>>() { new List<string>() { "Q" } } },
                new object[] { 2, 0 },
                new object[] { 3, 0 },

                new object[] { 4, 2, new List<IList<string>>()
                    {
                        new List<string>() { ".Q..", "...Q", "Q...", "..Q." },
                        new List<string>() { "..Q.", "Q...", "...Q", ".Q.." }
                    },
                },

                // Others are from: https://oeis.org/A000170
                new object[] { 5, 10 },
                new object[] { 6, 4 },
                new object[] { 7, 40 },
                new object[] { 8, 92 },
                new object[] { 9, 352 },
                new object[] { 10, 724 },
            };
        }
    }

    public class SudokuSolverTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void SolveSudokuTest(char[][] board, char[][] expectedBoard)
        {
            SudokuSolver.SolveSudoku(board);

            for (int y = 0; y < expectedBoard.Length; y++)
            {
                for (int x = 0; x < expectedBoard[y].Length; x++)
                    Assert.Equal(expectedBoard[y][x], board[y][x]);
            }
        }

        public static object[][] TestData()
        {
            return new object[][]
            {
                new object[] { new char[][]
                    {
                        new char[]{ '5', '3', '.',  '.', '7', '.',  '.', '.', '.' },
                        new char[]{ '6', '.', '.',  '1', '9', '5',  '.', '.', '.' },
                        new char[]{ '.', '9', '8',  '.', '.', '.',  '.', '6', '.' },

                        new char[]{ '8', '.', '.',  '.', '6', '.',  '.', '.', '3' },
                        new char[]{ '4', '.', '.',  '8', '.', '3',  '.', '.', '1' },
                        new char[]{ '7', '.', '.',  '.', '2', '.',  '.', '.', '6' },

                        new char[]{ '.', '6', '.',  '.', '.', '.',  '2', '8', '.' },
                        new char[]{ '.', '.', '.',  '4', '1', '9',  '.', '.', '5' },
                        new char[]{ '.', '.', '.',  '.', '8', '.',  '.', '7', '9' },
                    },
                    new char[][]
                    {
                        new char[]{ '5', '3', '4',  '6', '7', '8',  '9', '1', '2' },
                        new char[]{ '6', '7', '2',  '1', '9', '5',  '3', '4', '8' },
                        new char[]{ '1', '9', '8',  '3', '4', '2',  '5', '6', '7' },

                        new char[]{ '8', '5', '9',  '7', '6', '1',  '4', '2', '3' },
                        new char[]{ '4', '2', '6',  '8', '5', '3',  '7', '9', '1' },
                        new char[]{ '7', '1', '3',  '9', '2', '4',  '8', '5', '6' },

                        new char[]{ '9', '6', '1',  '5', '3', '7',  '2', '8', '4' },
                        new char[]{ '2', '8', '7',  '4', '1', '9',  '6', '3', '5' },
                        new char[]{ '3', '4', '5',  '2', '8', '6',  '1', '7', '9' },
                    },
                },
            };
        }
    }
}
