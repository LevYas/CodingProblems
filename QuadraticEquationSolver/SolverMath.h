#pragma once
#include <vector>
#include "./utility/ReturningResult.h"

inline Result<std::vector<double>> solve_quadratic_equation(const double a, const double b, const double c)
{
   if (a == 0)
   {
      // ternary operator is not work with initializer lists
      if (b == 0)
         return { {}, "x can have any value" };

      return { {-c / b}, {} }; // actually it's not a quadratic equation
   }

   const double discriminant = b * b - 4 * a * c;

   if (discriminant < 0)
      return { {}, "no roots" };

   if (discriminant == 0)
      return { { -b / (2 * a) }, {} };

   const double discriminantRoot = std::sqrt(discriminant);

   const double root1 = (-b - discriminantRoot) / (2 * a);
   const double root2 = (-b + discriminantRoot) / (2 * a);

   return { { root1, root2 }, {} };
}
