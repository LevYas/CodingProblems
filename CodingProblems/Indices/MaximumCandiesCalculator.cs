namespace CodingProblems.Indices;

// 2226. Maximum Candies Allocated to K Children
// You are given a 0-indexed integer array candies.
// Each element in the array denotes a pile of candies of size candies[i].
// You can divide each pile into any number of sub piles, but you cannot merge two piles together.
// You are also given an integer k.
// You should allocate piles of candies to k children such that each child gets the same number of candies.
// Each child can take at most one pile of candies and some piles of candies may go unused.
// Return the maximum number of candies each child can get.
//https://leetcode.com/problems/maximum-candies-allocated-to-k-children/

public class MaximumCandiesCalculator
{
    public int Calculate(int[] candies, long k)
    {
        long sum = 0;

        // .Sum doesn't work because of big numbers
        foreach (int subCandies in candies)
            sum += subCandies;

        double mean = (double)sum / k;

        if (mean < 1.0)
            return 0;

        // Try each value, but optimize using binary search
        return findAnswer(candies, k, 1, (int)mean);
    }

    private static int findAnswer(int[] candies, long childrenAmount, int min, int max)
    {
        if (min == max)
            return min;

        if (canAllocate(candies, childrenAmount, max))
            return max;

        int middle = min + (max - min) / 2;

        if (canAllocate(candies, childrenAmount, middle))
            return findAnswer(candies, childrenAmount, middle, max - 1);

        return findAnswer(candies, childrenAmount, min, middle - 1);
    }

    private static bool canAllocate(int[] candies, long childrenAmount, int perChild)
    {
        long allocated = 0;

        foreach (int subCandies in candies)
        {
            allocated += subCandies / perChild;

            if (allocated >= childrenAmount)
                return true;
        }

        return false;
    }
}
