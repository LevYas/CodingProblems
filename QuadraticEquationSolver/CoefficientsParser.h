#pragma once
#include <vector>
#include <sstream>
#include "./utility/ReturningResult.h"
#include "./utility/StringStreamHelper.h"

inline Result<std::vector<double>> parse_coefficients(const int argc, char* argv[])
{
   Result<std::vector<double>> result;
   result.value.reserve(argc);

   for (int i = 0; i < argc; ++i)
   {
      std::istringstream ss(argv[i]);
      double coeff;
      ss >> coeff;

      if (ss.fail())
      {
         result.error = sstr() << "Failed to parse <" << argv[i] << ">, parsing stopped.";
         return result;
      }

      result.value.push_back(coeff);
   }

   return result;
}
