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

        // Integer to Roman.
        // Given an integer, convert it to a roman numeral.
        // https://leetcode.com/problems/integer-to-roman/
        public static string IntToRoman(int num)
        {
            string result = "";

            void extractRomanNumeral(int numeralValue, string romanValue)
            {
                while (num - numeralValue >= 0)
                {
                    result += romanValue;
                    num -= numeralValue;
                }
            }

            extractRomanNumeral(1000, "M");
            extractRomanNumeral(900, "CM");

            extractRomanNumeral(500, "D");
            extractRomanNumeral(400, "CD");

            extractRomanNumeral(100, "C");
            extractRomanNumeral(90, "XC");

            extractRomanNumeral(50, "L");
            extractRomanNumeral(40, "XL");

            extractRomanNumeral(10, "X");
            extractRomanNumeral(9, "IX");

            extractRomanNumeral(5, "V");
            extractRomanNumeral(4, "IV");

            extractRomanNumeral(1, "I");

            return result;
        }
    }
}
