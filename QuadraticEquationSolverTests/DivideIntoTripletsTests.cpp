#include "pch.h"
#include "../QuadraticEquationSolver/CoefficientsDivider.h"
#include "gtest/gtest.h"

struct DivideIntoTripletsTestParameters
{
   std::vector<double> coefficients;
   std::vector<CoefficientsKit> expectedValues;
};

class DivideIntoTripletsTestsFx : public ::testing::TestWithParam<DivideIntoTripletsTestParameters>
{};

TEST_P(DivideIntoTripletsTestsFx, DivideIntoTripletsTest)
{
   auto param = GetParam();

   Result<std::vector<CoefficientsKit*>> divisionResult = divide_into_triplets(param.coefficients);

   ASSERT_EQ(divisionResult.value.size(), param.expectedValues.size());

   for (size_t i = 0; i < param.expectedValues.size(); ++i)
   {
      ASSERT_EQ(divisionResult.value[i]->a(), param.expectedValues[i].a());
      ASSERT_EQ(divisionResult.value[i]->b(), param.expectedValues[i].b());
      ASSERT_EQ(divisionResult.value[i]->c(), param.expectedValues[i].c());
   }
}

INSTANTIATE_TEST_CASE_P(DivideIntoTripletsTestsFxs, DivideIntoTripletsTestsFx,
   ::testing::Values(
      DivideIntoTripletsTestParameters{ { 1, -2, -3, 0, 4, -4, 11, 22 }, { { 1, -2, -3 }, { 0, 4, -4 } } },
      DivideIntoTripletsTestParameters{ { 1, -2, -3, 0, 4, -4 }, { { 1, -2, -3 }, { 0, 4, -4 } } },
      DivideIntoTripletsTestParameters{ { 1, -2 }, {} }
));
