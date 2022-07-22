namespace CodingProblems.MathProblems;

// 2266. Count Number of Texts
// Alice is texting Bob using her phone. The mapping of digits to letters is shown in the figure below.
// In order to add a letter, Alice has to press the key of the corresponding digit i times, where i is the position of the letter in the key.
// For example, to add the letter 's', Alice has to press '7' four times. Similarly, to add the letter 'k', Alice has to press '5' twice.
// Note that the digits '0' and '1' do not map to any letters, so Alice does not use them.
// However, due to an error in transmission, Bob did not receive Alice's text message but received a string of pressed keys instead.
// 
// For example, when Alice sent the message "bob", Bob received the string "2266622".
// Given a string pressedKeys representing the string received by Bob, return the total number of possible text messages Alice could have sent.
// 
// Since the answer may be very large, return it modulo 109 + 7.
// https://leetcode.com/problems/count-number-of-texts/

public class NumberOfTextsCounter
{
    // More examples to understand the task:
    // "2" - a - 1
    // "22" - b, aa - 2
    // "222" - c, ab, ba, aaa - 4
    // "2222" - ca, ac, aba, baa, aab, aaaa, bb - 7
    // "7777" - pppp, pqp, qq, ppq, qpp, rp, pr, s - 8

    // "2223" - same as 222 but all the combinations end with d
    // next digit 3 will double the combinations since we will have the same previous combinations but with two set of endings 'dd' or 'e'

    public int CountTexts(string pressedKeys)
    {
        int[] dp = new int[pressedKeys.Length + 1];
        dp[0] = 1;
        dp[1] = 1;
        int count = 1;

        for (int i = 1; i < pressedKeys.Length; i++)
        {
            if (pressedKeys[i] != pressedKeys[i - 1])
                count = 0;

            count++;

            for (int j = 0; j < Math.Min(getMaxSymbols(pressedKeys[i]), count); j++)
            {
                dp[i + 1] += dp[i - j];
                dp[i + 1] %= 1000000007;
            }
        }

        return dp[^1];
    }

    private static int getMaxSymbols(char c) => c is '7' or '9' ? 4 : 3;
}
