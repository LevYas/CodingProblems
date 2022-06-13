using System;

namespace CodingProblems.Indices;

// 875. Koko Eating Bananas
// Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas.
// The guards have gone and will come back in h hours.
// 
// Koko can decide her bananas-per-hour eating speed of k.
// Each hour, she chooses some pile of bananas and eats k bananas from that pile.
// If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.
//
// Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.
//
// Return the minimum integer k such that she can eat all the bananas within h hours.
// https://leetcode.com/problems/koko-eating-bananas/

public class EatingSpeedCalculator
{
    public int FindMinEatingSpeed(int[] piles, int h)
    {
        // Initially I tried to find min and max boundaries, but we can just get them from the constraints
        // Then use binary search to find minimum speed
        
        int lo = 1;
        int hi = 1000000000;
        
        while (lo < hi)
        {
            int middle = (lo + hi) / 2;
            
            if (canEatAll(piles, middle, h))
                hi = middle;
            else
                lo = middle + 1;
        }
        
        return lo;
    }
    
    private static bool canEatAll(int[] piles, int speed, int hoursLeft)
    {  
        foreach(int pile in piles)
        {
            hoursLeft -= (int)Math.Ceiling((double)pile / speed);
            if (hoursLeft < 0)
                return false;
        }
        
        return true;
    }
}
