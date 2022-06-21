using System;

namespace CodingProblems.Indices;

// 2281. Sum of Total Strength of Wizards
// As the ruler of a kingdom, you have an army of wizards at your command.
// You are given a 0-indexed integer array strength, where strength[i] denotes the strength of the ith wizard.
// For a contiguous group of wizards (i.e. the wizards' strengths form a subarray of strength),
// the total strength is defined as the product of the following two values:
//      The strength of the weakest wizard in the group.
//      The total of all the individual strengths of the wizards in the group.
//
// Return the sum of the total strengths of all contiguous groups of wizards. Since the answer may be very large, return it modulo 10e9 + 7.
// 
// A subarray is a contiguous non-empty sequence of elements within an array.
// https://leetcode.com/problems/sum-of-total-strength-of-wizards/

public class WizardsTotalStrengthCalculator
{
    public int CalcTotalStrength(int[] strength)
    {
        int[] prefixSums = new int[strength.Length];
        
        prefixSums[0] = strength[0];
        
        for (int i = 1; i < strength.Length; i++)
            prefixSums[i] = prefixSums[i - 1] + strength[i];
        
        // example:  1, 3, 1, 2
        // pref sum: 1  4  5  7
        // sum of range [i, k] - pref[k] - pref[i - 1]
            
        int result = 0;
        
        int spanLength = 1;
        while (spanLength <= strength.Length)
        {
            for(int i = 0; i <= strength.Length - spanLength; i++)
            {
                int spanMin = Int32.MaxValue;
                
                for (int j = 0; j < spanLength; j++)
                    spanMin = Math.Min(spanMin, strength[i + j]);
                
                int prefixSumBeforeSpan = i > 0 ? prefixSums[i - 1] : 0;
                int sumOfSpan = prefixSums[i + spanLength - 1] - prefixSumBeforeSpan;
                
                result += spanMin * sumOfSpan;
                result %= 1000000007;
            }
            
            spanLength++;
        }
        
        return result;
    }
}
