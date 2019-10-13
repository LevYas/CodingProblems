#include "pch.h"
#include "../QuadraticEquationSolver/CoefficientsParser.h"
#include "gtest/gtest.h"

struct ParseCoefficientsTestParameters
{
   std::vector<std::string> coefficients;
   std::vector<double> expectedValues;
};

class ParseCoefficientsTestsFx : public ::testing::TestWithParam<ParseCoefficientsTestParameters>
{};

TEST_P(ParseCoefficientsTestsFx, ParseCoefficientsTest)
{
   auto param = GetParam();

   std::vector<std::vector<char>> charedCoefficients;

   for (const std::string& coefficient : param.coefficients)
   {
      std::vector<char> writable(coefficient.begin(), coefficient.end());
      writable.push_back('\0');

      charedCoefficients.push_back(writable);
   }

   std::vector<char*> ptrsToCharedCoefs;

   for (std::vector<char>& coefficient : charedCoefficients)
      ptrsToCharedCoefs.push_back(&coefficient[0]);

   Result<std::vector<double>> parsingResult = parse_coefficients((int)ptrsToCharedCoefs.size(), &ptrsToCharedCoefs[0]);

   ASSERT_EQ(parsingResult.value, param.expectedValues);
}

INSTANTIATE_TEST_CASE_P(ParseCoefficientsTestsFxs, ParseCoefficientsTestsFx,
   ::testing::Values(
      ParseCoefficientsTestParameters{ { "1", "-2", "-3", "0", "4", "-4", "11", "22", "c" }, { 1, -2, -3, 0, 4, -4, 11, 22 } },
      ParseCoefficientsTestParameters{ { "1.2", "-2e3", "-3", "0.1", "4", "-4", "11", "0" }, { 1.2, -2e3, -3, 0.1, 4, -4, 11, 0 } },
      ParseCoefficientsTestParameters{ { "c", "-2", "-3" }, { } }
));