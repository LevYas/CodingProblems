using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Numbers
{
    // MissingInteger
    // Write a function that, given an array A of N integers,
    // returns the smallest positive integer(greater than 0) that does not occur in A.
    // https://app.codility.com/programmers/lessons/4-counting_elements/missing_integer/
    public static class MissingIntegerFinder
    {
        public static int Find(int[] arr)
        {
            var set = new HashSet<int>();

            foreach (int item in arr.Where(n => n > 0))
                set.Add(item);

            int lastCheckedInt;
            for (lastCheckedInt = 1; lastCheckedInt <= arr.Length; lastCheckedInt++)
            {
                if (!set.Contains(lastCheckedInt))
                    return lastCheckedInt;
            }

            return lastCheckedInt;
        }
    }
}
