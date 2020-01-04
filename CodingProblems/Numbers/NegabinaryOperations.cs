using System;
using System.Collections.Generic;

namespace CodingProblems.Numbers
{
    public static class NegabinaryOperations
    {
        // Translation to negabinary number system, i.e.
        // 9 => 11001 (9 = 16 - 8 + 1)
        public static int[] ToNegabinary(int number)
        {
            var result = new List<int>();

            while (number != 0)
            {
                int quotient = number / -2;
                int reminder = number % -2;

                if (reminder < 0)
                {
                    quotient++;
                    reminder += 2;
                }

                number = quotient;
                result.Add(reminder);
            }

            result.Reverse();

            return result.ToArray();
        }

        public static int FromNegabinary(int[] arr)
        {
            int result = 0;

            for (int pow = 0, bitNumber = arr.Length - 1; bitNumber >= 0; --bitNumber, ++pow)
                result += arr[bitNumber] * (int)Math.Pow(-2, pow);

            return result;
        }

        public static int[] AddNegabinarySimple(int[] arr1, int[] arr2)
        {
            return ToNegabinary(FromNegabinary(arr1) + FromNegabinary(arr2));
        }

        // Adding Two Negabinary Numbers
        // Given two numbers arr1 and arr2 in base -2, return the result of adding them together.
        // Each number is given in array format:  as an array of 0s and 1s, from most significant bit to least significant bit.
        // Return the result of adding arr1 and arr2 in the same format: as an array of 0s and 1s with no leading zeros.
        // https://leetcode.com/problems/adding-two-negabinary-numbers/
        public static int[] AddNegabinary(int[] arr1, int[] arr2)
        {
            Stack<int> result = new Stack<int>(Math.Max(arr1.Length, arr2.Length) + 1);

            int curIdx1 = arr1.Length - 1;
            int curIdx2 = arr2.Length - 1;

            int carry = 0, bit;
            int itemFrom1, itemFrom2;

            while (curIdx1 >= 0 || curIdx2 >= 0 || carry != 0)
            {
                itemFrom1 = curIdx1 >= 0 ? arr1[curIdx1--] : 0;
                itemFrom2 = curIdx2 >= 0 ? arr2[curIdx2--] : 0;

                (bit, carry) = findBitAndCarry(carry + itemFrom1 + itemFrom2);
                result.Push(bit);
            }

            while (result.Peek() == 0 && result.Count > 1)
                result.Pop();

            return result.ToArray();
        }

        private static (int, int) findBitAndCarry(int sum)
        {
            switch (sum)
            {
                case -2: return (0, 1);
                case -1: return (1, 1);
                case 0: return (0, 0);
                case 1: return (1, 0);
                case 2: return (0, -1);
                case 3: return (1, -1);
                default: throw new ArgumentOutOfRangeException(nameof(sum));
            }
        }
    }
}
