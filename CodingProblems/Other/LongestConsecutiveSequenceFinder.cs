namespace CodingProblems.Other;

public class LongestConsecutiveSequenceFinder
{
    public int Find(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        HashSet<int> numSet = new();

        foreach (int num in nums)
            numSet.Add(num);

        int maxLength = 1;

        foreach (int num in nums)
        {
            if (!numSet.Contains(num))
                continue;

            int currentLength = 1;

            int nextNum = num + 1;
            // try find next elements
            while (numSet.Contains(nextNum))
            {
                currentLength++;
                numSet.Remove(nextNum);
                nextNum++;
            }

            // try find prev elements
            int prevNum = num - 1;
            while (numSet.Contains(prevNum))
            {
                currentLength++;
                numSet.Remove(prevNum);
                prevNum--;
            }

            if (currentLength > maxLength)
                maxLength = currentLength;
        }

        return maxLength;
    }
}
