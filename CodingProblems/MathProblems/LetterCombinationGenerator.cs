namespace CodingProblems.MathProblems;

// 17. Letter Combinations of a Phone Number
// Given a string containing digits from 2-9 inclusive, return all possible letter combinations
//      that the number could represent. Return the answer in any order.
// A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
// https://leetcode.com/problems/letter-combinations-of-a-phone-number/submissions/

public class LetterCombinationGenerator
{
    // Top-down approach - slower in ~10 times than recursion
    public IList<string> Generate(string digits)
    {
        List<string> result = new();

        if (String.IsNullOrEmpty(digits))
            return result;

        result.Add("");

        foreach (char digit in digits)
        {
            List<string> newItems = new();

            foreach (string item in result)
                newItems.AddRange(getLetters(digit).Select(letter => item + letter));

            result = newItems;
        }

        return result;
    }

    // Bottom-up result generation
    public IList<string> GenerateViaRecursion(string digits) =>
        String.IsNullOrEmpty(digits)
            ? new List<string>()
            : collectCombinations(digits, 0);

    private List<string> collectCombinations(string digits, int idx)
    {
        if (idx == digits.Length)
            return new List<string> { "" };

        List<string> combinations = new();

        foreach (char letter in getLetters(digits[idx]))
            combinations.AddRange(collectCombinations(digits, idx + 1).Select(sub => letter + sub));

        return combinations;
    }

    private static string getLetters(char digit) =>
        digit switch
        {
            '2' => "abc",
            '3' => "def",
            '4' => "ghi",
            '5' => "jkl",
            '6' => "mno",
            '7' => "pqrs",
            '8' => "tuv",
            '9' => "wxyz",
            _ => "",
        };
}
