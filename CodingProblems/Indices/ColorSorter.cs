namespace CodingProblems.Indices;

// Given an array nums with n objects colored red, white, or blue, sort them in-place
//      so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
// We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
// You must solve this problem without using the library's sort function.
// https://leetcode.com/problems/sort-colors/

public class ColorSorter
{
    public void SortColorsSimple(int[] nums)
    {
        int[] counts = new int[3];

        foreach (int num in nums)
            counts[num]++;

        int pos = 0;
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < counts[i]; ++j)
                nums[pos++] = i;
        }
    }

    // Follow up: Could you come up with a one-pass algorithm using only constant extra space?
    public void SortColors(int[] nums)
    {
        int lastIdxOfZero = -1;
        int firstIdxOfTwo = nums.Length;

        int currentIdx = 0;

        void swap(int a, int b) => (nums[a], nums[b]) = (nums[b], nums[a]);

        while (currentIdx < firstIdxOfTwo)
        {
            switch (nums[currentIdx])
            {
                case 0:
                    swap(currentIdx, ++lastIdxOfZero);
                    currentIdx++;
                    continue;
                case 1:
                    currentIdx++;
                    continue;
                case 2:
                    swap(currentIdx, --firstIdxOfTwo);
                    continue;
            }
        }
    }
}
