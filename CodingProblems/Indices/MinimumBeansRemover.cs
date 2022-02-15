using System;

namespace CodingProblems.Indices;

// You are given an array of positive integers beans, where each integer represents the number of magic beans found in a particular magic bag.
// Remove any number of beans (possibly none) from each bag such that the number of beans in each remaining non-empty bag (still containing at least one bean) is equal. Once a bean has been removed from a bag, you are not allowed to return it to any of the bags.
// Return the minimum number of magic beans that you have to remove.
// https://leetcode.com/problems/removing-minimum-number-of-magic-beans/

public class MinimumBeansRemover
{
    public long RemoveMinimum(int[] beans)
    {
        ulong totalSum = 0;
        
        foreach(int beanAmount in beans)
            totalSum += (ulong)beanAmount;
        
        Array.Sort(beans);

        ulong minRemovedBeans = totalSum;
        
        for (int i = 0; i < beans.Length; i++)
        {
            // We calculate, how many beans should we remove to equalize the values
            // To do that, we just need to extract from the sum beans that we don't need to remove
            ulong beansToRemove = totalSum - (ulong)beans[i] * (ulong)(beans.Length - i);
            
            minRemovedBeans = Math.Min(beansToRemove, minRemovedBeans);
        }
        
        return (long)minRemovedBeans;
    }
}