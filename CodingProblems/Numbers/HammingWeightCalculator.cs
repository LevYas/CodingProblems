namespace CodingProblems.Numbers;

// 191. Number of 1 Bits
// Write a function that takes an unsigned integer and returns the number of '1' bits it has (also known as the Hamming weight).
// https://leetcode.com/problems/number-of-1-bits/

public class HammingWeightCalculator
{
    public int Calc(uint n)
    {
        int result = 0;

        for (int i = 0; i <= 31; i++)
        {
            uint mask = (uint)1 << i;
            if ((n & mask) == mask)
                result++;
        }

        return result;
    }
}
