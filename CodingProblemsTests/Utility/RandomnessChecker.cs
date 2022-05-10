using System;
using System.Collections;

namespace CodingProblemsTests.Utility;

// Source: https://en.wikibooks.org/wiki/Algorithm_Implementation/Pseudorandom_Numbers/Chi-Square_Test

internal static class RandomnessChecker
{
    // Calculates the chi-square value for N positive integers less than r
    // Source: "Algorithms in C" - Robert Sedgewick - pp. 517
    // NB: Sedgewick recommends: "...to be sure, the test should be tried a few times,
    // since it could be wrong in about one out of ten times."
    public static bool IsRandom(this int[] randomNums, int r)
    {
        //Calculate the number of samples - N
        int n = randomNums.Length;

        //According to Sedgewick: "This is valid if N is greater than about 10r"
        if (n <= 10*r)
            return false;

        double nR = n / r;
        double chiSquare = 0;
        Hashtable ht;

        //PART A: Get frequency of randoms
        ht = randomFrequency (randomNums);

        //PART B: Calculate chi-square - this approach is in Sedgewick
        foreach (DictionaryEntry item in ht)
        {
            double f = (int)(item.Value) - nR;
            chiSquare += Math.Pow(f, 2);
        }
        chiSquare = chiSquare / nR;

        //PART C: According to Swdgewick: "The statistic should be within 2(r)^1/2 of r
        //This is valid if N is greater than about 10r"
        if((r - 2 * Math.Sqrt (r) <= chiSquare) &  (r + 2 * Math.Sqrt (r) >= chiSquare))
            return true;
        else
            return false;
    }

    //Gets the frequency of occurrence of a randomly generated array of integers
    //Output: A hashtable, key being the random number and value its frequency
    private static Hashtable randomFrequency(int[] randomNums)
    {
        Hashtable ht = new Hashtable();
        int n = randomNums.Length;

        for(int i = 0; i <= n-1; i++)
        {
            if (ht.ContainsKey(randomNums[i]))
                ht[randomNums[i]] = (int) ht[randomNums[i]] + 1;
            else
                ht[randomNums[i]] = 1;
        }
	
        return ht;
    }
}
