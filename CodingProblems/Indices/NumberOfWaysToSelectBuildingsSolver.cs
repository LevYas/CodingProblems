namespace CodingProblems.Indices;

// 2222. Number of Ways to Select Buildings

// You are given a 0-indexed binary string s which represents the types of buildings along a street where:
//   s[i] = '0' denotes that the ith building is an office and
//   s[i] = '1' denotes that the ith building is a restaurant.
// As a city official, you would like to select 3 buildings for random inspection.
// However, to ensure variety, no two consecutive buildings out of the selected buildings can be of the same type.
// 
// For example, given s = "001101", we cannot select the 1st, 3rd, and 5th buildings as that would form "011" which is not allowed
// due to having two consecutive buildings of the same type.
//     Return the number of valid ways to select 3 buildings.
// https://leetcode.com/problems/number-of-ways-to-select-buildings/

public class NumberOfWaysToSelectBuildingsSolver
{
    public long Calculate(string s)
    {
        // We have 2 possible patterns - 101 and 010
        // For each pattern, number of extra 1 or 0 adds possible options
        // So we will scan the string looking for those patterns, and for each pattern we will check, how many 1 and 0 to the left and right

        long n0Left = 0, n1Left = 0;

        foreach (char c in s)
        {
            if (c == '0')
                n0Left++;
            else
                n1Left++;
        }

        long n0Current = 0, n1Current = 0;
        long answer = 0;

        foreach (char c in s)
        {
            if (c == '1') // pattern 010
            {
                answer += n0Current * n0Left;
                n1Left--;
                n1Current++;
            }
            else // c == '0' - pattern 101
            {
                answer += n1Current * n1Left;
                n0Left--;
                n0Current++;
            }
        }

        return answer;
    }
}
