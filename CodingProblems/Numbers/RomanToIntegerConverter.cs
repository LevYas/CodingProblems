using System;

namespace CodingProblems.Numbers
{
    public static class RomanToIntegerConverter
    {
        // Roman to Integer
        // Given a roman numeral, convert it to an integer.
        // https://leetcode.com/problems/roman-to-integer/
        public static int RomanToInt(string s)
        {
            int result = 0;
            int prevVal = -1;

            for (int i = s.Length - 1; i >= 0 ; i--)
            {
                int curVal = getSymbolValue(s[i]);

                if (result == 0 || curVal >= prevVal)
                    result += curVal;
                else
                    result -= curVal;

                prevVal = curVal;
            }

            return result;
        }

        private static int getSymbolValue(char s)
        {
            switch (s)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: throw new Exception();
            }
        }
    }
}
