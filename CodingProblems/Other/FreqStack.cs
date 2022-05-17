using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Other;

// 895. Maximum Frequency Stack
// Design a stack-like data structure to push elements to the stack and pop the most frequent element from the stack.
// Implement the FreqStack class:
// FreqStack() constructs an empty frequency stack.
// void push(int val) pushes an integer val onto the top of the stack.
// int pop() removes and returns the most frequent element in the stack.
//     If there is a tie for the most frequent element, the element closest to the stack's top is removed and returned.
// https://leetcode.com/problems/maximum-frequency-stack/

public class FreqStack
{
    // The main idea is to keep stack to use for every frequency
    // If we have values 3, 1, 3, we will have
    //      _valueToFrequency: 3 - 2 and 1 - 1
    //      _frequencyToValues: 1 - 3, 1 and 2 - 3
    //      _maxFrequency: 2

    // On POP, we will clear the values stack for the maximum frequency, then for _maxFrequency-1, and so on


    private readonly Dictionary<int, int> _valueToFrequency = new();
    private readonly Dictionary<int, Stack<int>> _frequencyToValues = new();
    private int _maxFrequency;
    
    public void Push(int val)
    {
        if (!_valueToFrequency.TryAdd(val, 1))
            _valueToFrequency[val]++;
        
        int newFrequency = _valueToFrequency[val];
        _maxFrequency = Math.Max(newFrequency, _maxFrequency);

        _frequencyToValues.TryAdd(newFrequency, new Stack<int>());
        _frequencyToValues[newFrequency].Push(val);
    }
    
    public int Pop()
    {
        int val = _frequencyToValues[_maxFrequency].Pop();
        
        _valueToFrequency[val]--;

        if (!_frequencyToValues[_maxFrequency].Any())
            _maxFrequency--;
        
        return val;
    }
}
