namespace CodingProblems.Numbers;

// 367. Valid Perfect Square
// Given a positive integer num, write a function which returns True if num is a perfect square else False.
// https://leetcode.com/problems/valid-perfect-square/

public class PerfectSquareValidator
{
    public bool IsPerfectSquare(int num)
    {
        if (num == 1)
            return true;
        
        long lo = 1;
        long hi = num / 2;
        
        while (lo <= hi)
        {
            long mid = (lo + hi) / 2;
            long sq = mid * mid;
            
            if (sq == num)
                return true;
            
            if (sq < num)
                lo = mid + 1;
            else
                hi = mid - 1;
        }
        
        return false;
    }
}
