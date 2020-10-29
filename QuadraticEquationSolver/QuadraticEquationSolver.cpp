#include "pch.h"
#include <iostream>
#include <chrono>
#include "./utility/ReturningResult.h"
#include "CoefficientsParser.h"
#include "CoefficientsDivider.h"
#include "SolverMath.h"

// The program divides the input into triplets and solve quadratic equation for each of them
int main(const int argc, char *argv[])
{
   if (argc < 2)
   {
      std::cout << "Nothing to solve, please run program with space-separated list of coefficients." << std::endl;
      std::cout << "Example: QuadraticEquationSolver.exe 1 -2 -3 0 4 -4 0 0 4 3.1 2.1 3.1 11 22 c" << std::endl;
      return 0;
   }

   auto start = std::chrono::high_resolution_clock::now();

   // the first arg element is a name of the executable file
   Result<std::vector<double>> parsingResult = parse_coefficients(argc - 1, argv + 1);

   if (!parsingResult.error.empty())
      std::cout << "An error occurred during parsing of input: " << parsingResult.error << std::endl;

   Result<std::vector<CoefficientsKit*>> divisionResult = divide_into_triplets(parsingResult.value);

   if (!divisionResult.error.empty())
      std::cout << "An error occurred during division into triplets: " << divisionResult.error << std::endl;

   for (const CoefficientsKit* const coefKit : divisionResult.value)
   {
      Result<std::vector<double>> solvingResult = solve_quadratic_equation(coefKit->a(), coefKit->b(), coefKit->c());

      std::stringstream sourceData;

      sourceData << "(" << coefKit->a() << " " << coefKit->b() << " " << coefKit->c() << ") => ";

      if (solvingResult.value.empty())
      {
         std::cout << sourceData.str() << solvingResult.error << std::endl;
         continue;
      }

      std::stringstream roots;

      for (size_t i = 0; i < solvingResult.value.size(); ++i)
      {
         if (i != 0)
            roots << ", ";
         roots << solvingResult.value[i];
      }

      std::cout << sourceData.str() << "(" << roots.str() << ")" << std::endl;
   }

   auto finish = std::chrono::high_resolution_clock::now();

   auto microseconds = std::chrono::duration_cast<std::chrono::microseconds>(finish - start);
   std::cout << microseconds.count() << "µs" << std::endl;

   return 0;
}
