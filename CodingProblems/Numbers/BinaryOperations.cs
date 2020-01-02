using System;

namespace CodingProblems.Numbers
{
    public static class BinaryOperations
    {
        // Add Binary
        // Given two binary strings, return their sum (also a binary string).
        // https://leetcode.com/problems/add-binary/
        public static string AddBinary(string num1, string num2)
        {
            string result = "";

            int curIdx1 = num1.Length - 1;
            int curIdx2 = num2.Length - 1;

            string bit;
            int carry = 0;
            int itemFrom1, itemFrom2;

            while (curIdx1 >= 0 || curIdx2 >= 0 || carry != 0)
            {
                itemFrom1 = curIdx1 >= 0 ? num1[curIdx1--] - '0' : 0;
                itemFrom2 = curIdx2 >= 0 ? num2[curIdx2--] - '0' : 0;

                (bit, carry) = findBitAndCarry(carry + itemFrom1 + itemFrom2);
                result = bit + result;
            }

            return result;
        }

        private static (string, int) findBitAndCarry(int sum)
        {
            switch (sum)
            {
                case 0: return ("0", 0);
                case 1: return ("1", 0);
                case 2: return ("0", 1);
                case 3: return ("1", 1);
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
