using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class MathProblems
    {
        // Daily Coding Problem: Problem #70 [Easy]
        // A number is considered perfect if its digits sum up to exactly 10.
        // Given a positive integer n, return the n-th perfect number.
        // For example, given 1, you should return 19. Given 2, you should return 28.
        public static int CalcNthPerfectNumber(int n)
        {
            return (int)Math.Pow(10, n / 10 + 1) + (n % 10 + n / 10) * 9;
        }

        // Daily Coding Problem: Problem #14
        // The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method. 
        // Hint: The basic equation of a circle is x2 + y2 = r2.
        public static double CalcPiUsingMonteCarlo()
        {
            double radius = 0.5;
            int insidePtsAmount = 0;
            int totalPoints = (int)1e8;

            Random rnd = new Random();

            for (int i = 0; i < totalPoints; ++i)
            {
                double x = rnd.NextDouble() - 0.5;
                double y = rnd.NextDouble() - 0.5;

                if (Math.Sqrt(x * x + y * y) < radius)
                    insidePtsAmount++;
            }

            double area = insidePtsAmount / ((double)totalPoints);
            return area / (radius * radius);
        }

        // Daily Coding Problem: Problem #37
        // The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.
        // For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.
        // You may also use a list or array to represent a set.
        public static IEnumerable<IEnumerable<int>> SetToPowerSet(IEnumerable<int> set)
        {
            List<List<int>> powerSet = new List<List<int>>();

            foreach (int elem in set)
            {
                var newElems = new List<List<int>>();

                foreach (List<int> subset in powerSet)
                {
                    var newSubset = subset.ToList();
                    newSubset.Add(elem);
                    newElems.Add(newSubset);
                }

                powerSet.Add(new List<int> { elem });

                if (newElems.Any())
                    powerSet.AddRange(newElems);
            }

            powerSet.Add(new List<int>());
            return powerSet;
        }
    }
}
