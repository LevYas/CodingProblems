namespace CodingProblems.Indices;

// 1208. Get Equal Substrings Within Budget
// You are given two strings s and t of the same length and an integer maxCost.
// You want to change s to t. Changing the ith character of s to ith character of t costs |s[i] - t[i]|
//      (i.e., the absolute difference between the ASCII values of the characters).
// Return the maximum length of a substring of s that can be changed to be the same as the corresponding substring
//      of t with a cost less than or equal to maxCost.
// If there is no substring from s that can be changed to its corresponding substring from t, return 0.
// https://leetcode.com/problems/get-equal-substrings-within-budget/

public class EqualSubstringWithinBudgetFinder
{
    public int GetEqualSubstringsWithinBudget(string s, string t, int maxCost)
    {
        int maxLength = 0;
        
        int start = 0;
        int end = 0;
        int currentCost = Math.Abs(s[end] - t[end]);
        
        while (start < s.Length && end < s.Length)
        {
            if (currentCost <= maxCost)
            {
                maxLength = Math.Max(maxLength, end - start + 1);

                end++;

                if (end < s.Length)
                    currentCost += Math.Abs(s[end] - t[end]);
            }
            else
            {
                if (start < s.Length)
                    currentCost -= Math.Abs(s[start] - t[start]);

                start++;
            }
        }
        
        return maxLength;
    }
}