namespace CodingProblems.Other;

// Design a class to find the kth largest element in a stream.
// Note that it is the kth largest element in the sorted order, not the kth distinct element.
// https://leetcode.com/problems/kth-largest-element-in-a-stream/
public class KthLargestElementFinder
{
    private readonly short[] _pq;

    public KthLargestElementFinder(int k, int[] nums)
    {
        _pq = new short[k];

        for (int i = 0; i < _pq.Length; i++)
            _pq[i] = short.MinValue;

        foreach (int num in nums)
            add((short)num);
    }
    
    public int Add(int val)
    {
        add((short)val);
        return _pq[0];
    }

    private void add(short val)
    {
        if (val <= _pq[0])
            return;

        _pq[0] = val;
        sink();
    }

    private void sink()
    {
        int parent = 1;

        while (2 * parent <= _pq.Length)
        {
            int smallestChild = 2 * parent;

            if (smallestChild < _pq.Length && isLess(smallestChild + 1, smallestChild))
                smallestChild++;

            if (!isLess(smallestChild, parent))
                break;

            exchange(parent, smallestChild);
            parent = smallestChild;
        }
    }

    private bool isLess(int left, int right) => _pq[left - 1] < _pq[right - 1];
    private void exchange(int i1, int i2) => (_pq[i1 - 1], _pq[i2 - 1]) = (_pq[i2 - 1], _pq[i1 - 1]);
}