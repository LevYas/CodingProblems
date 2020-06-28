#pragma once
#include <vector>
#include <algorithm>
#include <queue>
#include <unordered_map>

// Top K Frequent Elements
// Given a non-empty array of integers, return the k most frequent elements.
// https://leetcode.com/problems/top-k-frequent-elements/
class FrequentElementsFinder {
public:
    typedef std::pair<int, size_t> NumberToUsages;

    static std::vector<int> topKFrequent(std::vector<int>& nums, int k)
    {
        std::unordered_map<int, size_t> numsToUsages;

        for (int num : nums)
            numsToUsages[num]++;

        // This comparator defines the max-heap which uses number of usages as a parameter
        auto cmp = [](const auto& left, const auto& right) { return left.second < right.second; };

        // For the maximum efficiency we could limit the heap size by using min-heap and check it's top element
        // before inserting, if the new element is smaller, do not insert it
        std::priority_queue<NumberToUsages, std::vector<NumberToUsages>, decltype(cmp)>
            mostFrequentElements(numsToUsages.begin(), numsToUsages.end(), cmp);

        std::vector<int> result(k);

        for (size_t i = 0; i < k; i++)
        {
            result[i] = mostFrequentElements.top().first;
            mostFrequentElements.pop();
        }

        return result;
    }
};