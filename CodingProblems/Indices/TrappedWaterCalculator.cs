using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Indices
{
    public static class TrappedWaterCalculator
    {
        // https://leetcode.com/problems/trapping-rain-water/
        // Given n non-negative integers representing an elevation map 
        // where the width of each bar is 1, compute how much water it is able to trap after raining.
        public static int CalcTrappedWaterAmountUsingDP(int[] heights)
        {
            if (heights?.Any() != true)
                return 0;

            int heightsLen = heights.Length;
            int[] leftMax = new int[heightsLen], rightMax = new int[heightsLen];

            leftMax[0] = heights[0];

            for (int i = 1; i < heightsLen; ++i)
                leftMax[i] = Math.Max(leftMax[i - 1], heights[i]);

            rightMax[heightsLen - 1] = heights[heightsLen - 1];

            for (int i = heightsLen - 2; i >= 0; --i)
                rightMax[i] = Math.Max(rightMax[i + 1], heights[i]);

            int collectedCells = 0;

            for (int i = 0; i < heightsLen; ++i)
                collectedCells += Math.Min(leftMax[i], rightMax[i]) - heights[i];

            return collectedCells;
        }

        public static int CalcTrappedWaterAmountUsingTwoPointers(int[] heights)
        {
            if (heights == null)
                return 0;

            int leftIdx = 0; int rightIdx = heights.Length - 1;
            int collectedCells = 0;
            int maxLeftHeight = 0, maxRightHeight = 0;
            while (leftIdx <= rightIdx)
            {
                if (heights[leftIdx] <= heights[rightIdx])
                {
                    if (heights[leftIdx] >= maxLeftHeight)
                        maxLeftHeight = heights[leftIdx];
                    else
                        collectedCells += maxLeftHeight - heights[leftIdx];
                    ++leftIdx;
                }
                else
                {
                    if (heights[rightIdx] >= maxRightHeight)
                        maxRightHeight = heights[rightIdx];
                    else
                        collectedCells += maxRightHeight - heights[rightIdx];
                    --rightIdx;
                }
            }
            return collectedCells;
        }

        public static int CalcTrappedWaterAmountUsingStack(int[] heights)
        {
            if (heights?.Any() != true)
                return 0;

            Stack<int> previousBars = new Stack<int>();

            int collectedCells = 0;

            for (int i = 0; i < heights.Length; ++i)
            {
                while (previousBars.Any() && heights[previousBars.Peek()] < heights[i])
                {
                    int lowestBarIdx = previousBars.Pop();

                    if (!previousBars.Any())
                        break;

                    int distance = i - previousBars.Peek() - 1;
                    int columnHeight = Math.Min(heights[i], heights[previousBars.Peek()]) - heights[lowestBarIdx];
                    collectedCells += columnHeight * distance;
                }

                previousBars.Push(i);
            }

            return collectedCells;
        }
    }
}
