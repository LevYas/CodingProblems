#include "pch.h"
#include "../CppCodingProblems/NPuzzleSolver.h"

struct nPuzzleSolverParameters
{
    Board initialBoard;
    bool expectedSolvability;
    size_t expectedTurnsAmount;
};

class NPuzzleSolver_SolveFx : public testing::TestWithParam<nPuzzleSolverParameters>
{};

TEST_P(NPuzzleSolver_SolveFx, NPuzzleSolver_Solve)
{
    const nPuzzleSolverParameters param = GetParam();

    const auto [isSolvable, turns] = solve(param.initialBoard);

    EXPECT_EQ(isSolvable, param.expectedSolvability);
    EXPECT_EQ(turns.size(), param.expectedTurnsAmount);
}

INSTANTIATE_TEST_CASE_P(NPuzzleSolver_Solve, NPuzzleSolver_SolveFx,
    ::testing::Values(
        nPuzzleSolverParameters({ {0, 1, 2}, {3, 4, 5}, {6, 7, 8} }, true, 0),
        nPuzzleSolverParameters({ {1, 2, 3}, {4, 5, 6}, {8, 7, 0} }, false, 0),
        nPuzzleSolverParameters({ {1, 0, 2}, {3, 4, 5}, {6, 7, 8} }, true, 1),
        nPuzzleSolverParameters({ {0, 3, 8}, {4, 1, 7}, {2, 6, 5} }, true, 20),
        nPuzzleSolverParameters({ {1, 4, 2}, {3, 5, 8}, {6, 7, 0} }, true, 4)
    ));