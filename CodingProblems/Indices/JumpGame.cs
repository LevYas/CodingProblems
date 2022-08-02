namespace CodingProblems.Indices;

// 55. Jump Game
// You are given an integer array nums.
// You are initially positioned at the array's first index, and each element in the array
//      represents your maximum jump length at that position.
// Return true if you can reach the last index, or false otherwise.
// https://leetcode.com/problems/jump-game/

public class JumpGame
{
    public bool CanJump(int[] nums)
    {
        int maxRightIndex = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxRightIndex)
                return false;
            
            maxRightIndex = Math.Max(maxRightIndex, i + nums[i]);
            
            if (maxRightIndex >= nums.Length - 1)
                return true;
        }
        
        return false;
    }
}
