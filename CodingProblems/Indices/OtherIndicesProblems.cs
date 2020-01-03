using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodingProblems.Indices
{
    // Manipulations of array and string indices
    public static class OtherIndicesProblems
    {
        // Given an array of integers and an integer k, 
        // you need to find the total number of continuous subarrays whose sum equals to k.
        // https://leetcode.com/problems/subarray-sum-equals-k/
        public static int CalcSubarraysAmount(int[] numbers, int requiredSubarraySum)
        {
            int numberOfFragments = 0, currentSum = 0;
            Dictionary<int, int> sumToNumberOfRepetitions = new Dictionary<int, int>
            {
                { 0, 1 }
            };

            foreach (int number in numbers)
            {
                currentSum += number;
                int numToFind = currentSum - requiredSubarraySum;
                if (sumToNumberOfRepetitions.ContainsKey(numToFind))
                    numberOfFragments += sumToNumberOfRepetitions[numToFind];

                if (!sumToNumberOfRepetitions.ContainsKey(currentSum))
                    sumToNumberOfRepetitions.Add(currentSum, 0);

                ++sumToNumberOfRepetitions[currentSum];
            }

            return numberOfFragments;
        }

        // New Year Chaos
        // There are a number of people queued up, and each person wears a sticker indicating their initial position in the queue.
        // Initial positions increment by  from  at the front of the line to  at the back.
        // Any person in the queue can bribe the person directly in front of them to swap positions.
        // If two people swap positions, they still wear the same sticker denoting their original places in line.
        // One person can bribe at most two others. For example, if n=8 and P5 bribes P4, the queue will look like this: 1 2 3 5 4 6 7 8.
        // Fascinated by this chaotic queue, you decide you must know the minimum number of bribes that took place
        // to get the queue into its current state!
        // https://www.hackerrank.com/challenges/new-year-chaos/problem
        public static void CalcMinimumBribesAmount(TextWriter console, int[] queue)
        {
            decimal seqSize = queue.Length;
            decimal estimatedSum = (seqSize / 2) * (seqSize + 1);
            decimal actualSum = 0;

            foreach (int position in queue)
                actualSum += position;

            if (estimatedSum != actualSum)
            {
                console.WriteLine("Too chaotic");
                return;
            }

            int overallSwapsAmount = 0;

            int currentSwapsAmount;
            do
            {
                currentSwapsAmount = 0;

                for (int pos = 0; pos < queue.Length - 1; ++pos)
                {
                    int expectedVal = pos + 1;
                    int diff = queue[pos] - expectedVal;

                    if (Math.Abs(diff) > 2)
                    {
                        console.WriteLine("Too chaotic");
                        return;
                    }

                    if (queue[pos] > queue[pos + 1])
                    {
                        int temp = queue[pos];
                        queue[pos] = queue[pos + 1];
                        queue[pos + 1] = temp;
                        ++currentSwapsAmount;
                    }
                }

                overallSwapsAmount += currentSwapsAmount;
            }
            while (currentSwapsAmount != 0);

            console.WriteLine(overallSwapsAmount);
        }

        // A left rotation operation on an array shifts each of the array's elements 1 unit to the left.
        // https://www.hackerrank.com/challenges/ctci-array-left-rotation/problem
        public static int[] RotateLeft(int[] array, int rotationsNumber)
        {
            if (rotationsNumber == array.Length)
                return array;

            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length; ++i)
            {
                int swapIdx = (i + rotationsNumber) % array.Length;
                result[i] = array[swapIdx];
            }

            return result;
        }

        // 2D Array - DS
        // We define an hourglass in array to be a subset of values with indices falling in this pattern in array's graphical representation:
        // a b c
        //   d
        // e f g
        // Calculate the hourglass sum for every hourglass in arr, then print the maximum hourglass sum.
        // https://www.hackerrank.com/challenges/2d-array/problem
        public static int CalcMaxHourglassSum(int[][] arr)
        {
            int maxSum = Int32.MinValue;

            for (int y = 0; y <= 3; ++y)
            {
                for (int x = 0; x <= 3; ++x)
                {
                    int h1 = arr[y][x];
                    int h2 = arr[y][x + 1];
                    int h3 = arr[y][x + 2];
                    int h4 = arr[y + 1][x + 1];
                    int h5 = arr[y + 2][x];
                    int h6 = arr[y + 2][x + 1];
                    int h7 = arr[y + 2][x + 2];

                    int sum = h1 + h2 + h3 + h4 + h5 + h6 + h7;

                    if (sum > maxSum)
                        maxSum = sum;
                }
            }

            return maxSum;
        }

        // You have given a array and you have to give number of continuous subarray which the sum is zero.
        public static int CalcZeroFragmentsCount(int[] arr)
        {
            int[] sums = new int[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
                sums[i + 1] = sums[i] + arr[i];

            int numberOfFragments = 0;
            Dictionary<int, int> sumToNumberOfRepetitions = new Dictionary<int, int>();

            foreach (int item in sums)
            {
                if (sumToNumberOfRepetitions.ContainsKey(item))
                    numberOfFragments += sumToNumberOfRepetitions[item];
                else
                    sumToNumberOfRepetitions.Add(item, 0);

                sumToNumberOfRepetitions[item]++;
            }

            return numberOfFragments;
        }

        // Reverse String II
        // Given a string and an integer k, you need to reverse the first k characters for every 2k characters
        //      counting from the start of the string. If there are less than k characters left, reverse all of them.
        // If there are less than 2k but greater than or equal to k characters, then reverse the first k characters
        // and left the other as original.
        // https://leetcode.com/problems/reverse-string-ii/
        public static string ReverseString(string s, int k)
        {
            if (k == 1)
                return s;

            StringBuilder sb = new StringBuilder(s.Length);

            for (int i = 0; i < s.Length; i += 2 * k)
            {
                int charsLeft = s.Length - i;

                foreach (char c in s.Substring(i, charsLeft > k ? k : charsLeft).Reverse())
                    sb.Append(c);

                if (charsLeft <= k)
                    break;

                charsLeft -= k;

                sb.Append(s, i + k, charsLeft > k ? k : charsLeft);
            }

            return sb.ToString();
        }
    }
}
