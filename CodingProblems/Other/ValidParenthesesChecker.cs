using System;
using System.Collections.Generic;

namespace CodingProblems.Other
{
    // Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    // An input string is valid if:
    //      Open brackets must be closed by the same type of brackets.
    //      Open brackets must be closed in the correct order.
    // Note that an empty string is also considered valid.
    // https://leetcode.com/problems/valid-parentheses/
    public static class ValidParenthesesChecker
    {
        public static bool IsValid(string str)
        {
            if (String.IsNullOrEmpty(str))
                return true;

            var parentheses = new Stack<char>(str.Length / 2);

            foreach (char parenthesis in str)
            {
                if (parenthesis == '(' || parenthesis == '[' || parenthesis == '{')
                {
                    parentheses.Push(parenthesis);
                    continue;
                }

                if (parentheses.Count == 0 || !areMatching(parentheses.Pop(), parenthesis))
                    return false;
            }

            return parentheses.Count == 0;
        }

        private static bool areMatching(char opening, char closing)
            => closing switch
            {
                ')' => opening == '(',
                ']' => opening == '[',
                '}' => opening == '{',
                _ => false,
            };
    }
}
