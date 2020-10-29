#include "pch.h"
#include "..\CppCodingProblems\FrequentElementsFinder.h"

typedef std::tuple<std::vector<int>, std::vector<int>, int> FrequentElementsFinderParameter;
class FrequentElementsFinderTestsFx : public ::testing::TestWithParam<FrequentElementsFinderParameter>
{};

TEST_P(FrequentElementsFinderTestsFx, FrequentElementsFinderTest)
{
    auto param = GetParam();

    std::vector<int> result = FrequentElementsFinder::topKFrequent(std::get<1>(param), std::get<2>(param));

    std::sort(std::get<0>(param).begin(), std::get<0>(param).end());
    std::sort(result.begin(), result.end());
    EXPECT_EQ(std::get<0>(param), result);
}

INSTANTIATE_TEST_CASE_P(FrequentElementsFinderTests, FrequentElementsFinderTestsFx,
    ::testing::Values(
        FrequentElementsFinderParameter({ 1,2 }, { 1,1,1,2,2,3 }, 2),
        FrequentElementsFinderParameter({ 1 }, { 1 }, 1),
        FrequentElementsFinderParameter({ 2,1,5,7 }, { 1,1,1,2,2,3,5,2,2,5,5,5,2,6,2,7,5,1,1,7 }, 4)
    ));