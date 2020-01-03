
namespace CodingProblems
{
    public static class Sorting
    {
        // Inverted elements are considered to be "out of order". To correct an inversion, we can swap adjacent elements.
        // Print the number of inversions that must be swapped to sort each dataset.
        // https://www.hackerrank.com/challenges/ctci-merge-sort/problem
        public static long CountInversions(int[] arr)
        {
            int overallSwapsAmount = 0;

            int currentSwapsAmount;
            do
            {
                currentSwapsAmount = 0;

                for (int i = 0; i < arr.Length - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        ++currentSwapsAmount;
                    }
                }

                overallSwapsAmount += currentSwapsAmount;
            }
            while (currentSwapsAmount != 0);

            return overallSwapsAmount;
        }
    }
}
