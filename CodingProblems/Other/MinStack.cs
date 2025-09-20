namespace CodingProblems.Other;

// 155. Min Stack
// Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
// Implement the MinStack class:
//      MinStack() initializes the stack object.
//      void push(int val) pushes the element val onto the stack.
//      void pop() removes the element on the top of the stack.
//      int top() gets the top element of the stack.
//      int getMin() retrieves the minimum element in the stack.
// You must implement a solution with O(1) time complexity for each function.
// https://leetcode.com/problems/min-stack/

public class MinStack
{
    private readonly Stack<int> _stack = new();
    private readonly Stack<int> _minimums = new();

    public void Push(int val)
    {
        _stack.Push(val);
        _minimums.Push(_minimums.Any() ? Math.Min(_minimums.Peek(), val) : val);
    }

    public void Pop()
    {
        _stack.Pop();
        _minimums.Pop();
    }

    public int Top() => _stack.Peek();

    public int GetMin() => _minimums.Peek();
}
