namespace CodingProblems.Sorting;

// 373. Find K Pairs with Smallest Sums
// You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.
// Define a pair (u, v) which consists of one element from the first array and one element from the second array.
// Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.
// https://leetcode.com/problems/find-k-pairs-with-smallest-sums/

public class KthSmallestPairsFinder
{
    public IList<IList<int>> FindSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        List<IList<int>> result = new();
        HashSet<(int, int)> usedPairs = new();
        PriorityQueue<(int i1, int i2), int> pairsToProcess = new();

        usedPairs.Add((0, 0));
        pairsToProcess.Enqueue((0, 0), nums1[0] + nums2[0]);

        void enqueueIfNotUsed((int i1, int i2) n)
        {
            if (usedPairs.Add(n))
                pairsToProcess.Enqueue(n, nums1[n.i1] + nums2[n.i2]);
        }

        while (result.Count < k && pairsToProcess.Count > 0)
        {
            (int i1, int i2) = pairsToProcess.Dequeue();
            result.Add(new List<int>() { nums1[i1], nums2[i2] });

            (int i1, int i2) n = (i1 + 1, i2);
            if (n.i1 < nums1.Length )
                enqueueIfNotUsed(n);
            
            n = (i1, i2 + 1);
            if (n.i2 < nums2.Length)
                enqueueIfNotUsed(n);
        }

        return result;
    }
}
