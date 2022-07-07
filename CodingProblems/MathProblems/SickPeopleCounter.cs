namespace CodingProblems.MathProblems;

// 2327. Number of People Aware of a Secret
// On day 1, one person discovers a secret.
// You are given an integer delay, which means that each person will share the secret with a new person every day,
//      starting from delay days after discovering the secret.
// You are also given an integer forget, which means that each person will forget the secret forget days after discovering it.
// A person cannot share the secret on the same day they forgot it, or on any day afterwards.
// Given an integer n, return the number of people who know the secret at the end of day n.
// Since the answer may be very large, return it modulo 109 + 7.
// https://leetcode.com/problems/number-of-people-aware-of-a-secret/

// Looks like the task is more about virus with incubation period and contagious people, so I'll use this notation

public class SickPeopleCounter
{
    public int Calculate(int n, int delay, int forget)
    {
        long[] newCases = new long[n];
        newCases[0] = 1;
        long currentlyContagious = 0;
        const long mod = 1_000_000_007;

        for (int i = 1; i < n; i++)
        {
            currentlyContagious += i >= delay ? newCases[i - delay] : 0;
            currentlyContagious -= i >= forget ? newCases[i - forget] : 0;
            currentlyContagious = (currentlyContagious + mod) % mod;
            newCases[i] = currentlyContagious;
        }

        long result = 0;

        for (int i = n - forget; i < n; i++)
        {
            result += i >= 0 ? newCases[i] : 0;
            result %= mod;
        }

        return (int)result;
    }
}
