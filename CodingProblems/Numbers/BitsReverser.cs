namespace CodingProblems.Numbers
{
    public static class BitsReverser
    {
        // Reverse Bits
        // Reverse bits of a given 32 bits unsigned integer.
        // Runtime: 40 ms, faster than 93.82% of C# online submissions
        // https://leetcode.com/problems/reverse-bits/
        public static uint ReverseBits(uint number)
        {
            uint result = 0;

            for (int i = 0; i < 32; i++)
            {
                uint reminder = number % 2;
                number /= 2;

                result += reminder << 31 - i;
            }

            return result;
        }
    }
}
