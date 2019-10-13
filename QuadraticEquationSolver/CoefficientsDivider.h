#pragma once
#include <vector>
#include "./utility/ReturningResult.h"
#include "./utility/StringStreamHelper.h"

struct CoefficientsKit
{
   double coefficients[3];

   double a() const { return coefficients[0]; }
   double b() const { return coefficients[1]; }
   double c() const { return coefficients[2]; }
};

inline Result<std::vector<CoefficientsKit*>> divide_into_triplets(std::vector<double>& coefficients)
{
   const size_t tripletsCount = coefficients.size() / 3;
   const size_t unusedCoefsAmount = coefficients.size() % 3;

   Result<std::vector<CoefficientsKit*>> result;
   result.value.reserve(tripletsCount);

   if (unusedCoefsAmount != 0)
      result.error = sstr() << "Invalid coefficients count, last " << unusedCoefsAmount << " coefficient(s) are ignored.";

   for (size_t i = 0; i < tripletsCount; ++i)
      result.value.push_back(reinterpret_cast<CoefficientsKit*>(&coefficients[i * 3]));

   return result;
}
