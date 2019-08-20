#pragma once
#include <vector>
#include <algorithm>

long mergeAndCount(std::vector<int>& arr, std::vector<int>& temp, size_t startIdx, size_t middleIdx, size_t endIdx)
{
    long inversionsAmount = 0;
    
    size_t leftCursor = startIdx, rightCursor = middleIdx + 1;

    for (size_t i = startIdx; i <= endIdx; ++i)
    {
        int& curValue = temp[i];

        if (leftCursor > middleIdx)
        {
            curValue = arr[rightCursor++];
            continue;
        }
        else if (rightCursor > endIdx)
        {
            curValue = arr[leftCursor++];
            continue;
        }

        if (arr[rightCursor] >= arr[leftCursor])
        {
            curValue = arr[leftCursor++];
        }
        else
        {
            inversionsAmount += middleIdx - leftCursor + 1;
            curValue = arr[rightCursor++];
        }
    }

    std::copy(temp.begin() + startIdx, temp.begin() + endIdx + 1, arr.begin() + startIdx);

    return inversionsAmount;
}

long sortAndCount(std::vector<int>& arr, std::vector<int>& temp, size_t startIdx, size_t endIdx)
{
    if (startIdx == endIdx)
        return 0;

    long swapsAmount = 0;

    size_t middle = startIdx + (endIdx - startIdx) / 2;
    swapsAmount += sortAndCount(arr, temp, startIdx, middle);
    swapsAmount += sortAndCount(arr, temp, middle + 1, endIdx);
    swapsAmount += mergeAndCount(arr, temp, startIdx, middle, endIdx);    

    return swapsAmount;
}

// Inverted elements are considered to be "out of order". To correct an inversion, we can swap adjacent elements.
// Print the number of inversions that must be swapped to sort each dataset.
// https://www.hackerrank.com/challenges/ctci-merge-sort/problem
long countInversions(std::vector<int> arr)
{
    std::vector<int> temp(arr.size());
    return sortAndCount(arr, temp, 0, arr.size() - 1);
}