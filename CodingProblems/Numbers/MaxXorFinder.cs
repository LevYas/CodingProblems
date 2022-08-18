namespace CodingProblems.Numbers;

// 421. Maximum XOR of Two Numbers in an Array
// Given an integer array nums, return the maximum result of nums[i] XOR nums[j], where 0 <= i <= j < n.
// https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/

public class MaxXorFinder
{
    private class TrieNode
    {
        public readonly TrieNode[] Children = new TrieNode[2];
    }

    private readonly TrieNode _root = new();

    public int FindMaximumXor(int[] nums)
    {
        foreach (int num in nums)
        {
            TrieNode current = _root;

            for (int i = 31; i >= 0; i--)
            {
                int currentBit = (num & (1 << i)) > 0 ? 1 : 0;

                current.Children[currentBit] ??= new TrieNode();
                current = current.Children[currentBit];
            }
        }
        
        int max = 0;

        foreach (int num in nums)
        {
            TrieNode current = _root;
            int bestNumToXor = 0;

            for (int i = 31; i >= 0; i--)
            {
                int desiredBit = (num & (1 << i)) > 0 ? 0 : 1;

                if (current.Children[desiredBit] != null)
                {
                    bestNumToXor |= desiredBit << i;
                    current = current.Children[desiredBit];
                }
                else
                {
                    int otherBit = desiredBit == 0 ? 1 : 0;
                    bestNumToXor |= otherBit << i;
                    current = current.Children[otherBit];
                }
            }

            max = Math.Max(max, num ^ bestNumToXor);
        }

        return max;
    }
}
