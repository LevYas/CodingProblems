#include "pch.h"
#include "../QuadraticEquationSolver/SolverMath.h"
#include "gtest/gtest.h"
#include <algorithm>

struct SolverMathTestParameters
{
   std::vector<double> roots;

   double a;
   double b;
   double c;
};

class SolverMathTestsFx : public ::testing::TestWithParam<SolverMathTestParameters>
{};

TEST_P(SolverMathTestsFx, SolverMathTest)
{
   auto param = GetParam();

   Result<std::vector<double>> solvingResult = solve_quadratic_equation(param.a, param.b, param.c);

   ASSERT_EQ(solvingResult.value.size(), solvingResult.value.size());

   std::sort(solvingResult.value.begin(), solvingResult.value.end());
   std::sort(param.roots.begin(), param.roots.end());

   for (size_t i = 0; i < param.roots.size(); ++i)
   {
      ASSERT_NEAR(solvingResult.value[i], param.roots[i], std::max(abs(param.roots[i]), 1.) * 1e-10);
   }
}

INSTANTIATE_TEST_CASE_P(SolverMathTestsFxs, SolverMathTestsFx,
   ::testing::Values(
      SolverMathTestParameters{ { 0, -2 }, 1, 2, 0 },
      SolverMathTestParameters{ {}, 3, 2, 3 },
      SolverMathTestParameters{ { -0.2, -1 }, 5, 6, 1 },
      SolverMathTestParameters{ { 0 }, 1, 0, 0 },
      SolverMathTestParameters{ {}, 0, 0, 4 },
      SolverMathTestParameters{ { -0.7483302851773, 0.16296443151877 }, 8.2, 4.8, -1 },
      SolverMathTestParameters{ { -1e-8, 0 }, 1, 1e-8, 0 },
      SolverMathTestParameters{ { -1000.000998002, -9.9900000199700e-7 }, 999999, 999999999, 999 },
      SolverMathTestParameters{ { -1, 3 }, 1, -2, -3 },
      SolverMathTestParameters{ { 1 }, -0, 4, -4 }
));