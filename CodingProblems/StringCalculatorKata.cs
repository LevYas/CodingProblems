using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    // String Calculator Kata
    // This is a special kind of tasks, where you don't know what requirement will be the next
    // and you have only 30 minutes to complete all the steps.
    // Steps and instructions are here:
    // https://github.com/ardalis/kata-catalog/blob/master/katas/String%20Calculator.md or https://osherove.com/tdd-kata-1/
    // So, this code was written using TDD and in only 30 minutes from scratch (not on the first try, of course)
    public static class StringCalculator
    {
        public static int Add(string numSequence)
        {
            if (String.IsNullOrEmpty(numSequence))
                return 0;

            var delimiters = new List<string> { ",", "\n" };

            if (numSequence.StartsWith("//"))
            {
                if (numSequence[2] == '[')
                {
                    numSequence = numSequence.Substring(2);

                    while (numSequence.IndexOf(']') != -1)
                    {
                        numSequence = numSequence.Substring(1);

                        int closingBracketIdx = numSequence.IndexOf(']');
                        delimiters.Add(numSequence.Substring(0, closingBracketIdx));

                        numSequence = numSequence.Substring(closingBracketIdx + 1);
                    }

                    numSequence = numSequence.Substring(1);
                }
                else
                {
                    delimiters.Add(numSequence[2].ToString());
                    numSequence = numSequence.Substring(4);
                }
            }

            IEnumerable<int> nums = numSequence.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse);

            IEnumerable<int> negatives = nums.Where(n => n < 0);
            if (negatives.Any())
                throw new ArgumentException($"Negatives not allowed: {String.Join(",", negatives)}");

            return nums.Where(n => n < 1000).Sum();
        }
    }
}
