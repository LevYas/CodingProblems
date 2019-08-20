#include "pch.h"
#include "..\CppCodingProblems\Sorting.h"

typedef std::tuple<long, std::vector<int>> CountInversionParameter;
class CountInversionsTestsFx : public ::testing::TestWithParam<CountInversionParameter>
{
public:
};

TEST_P(CountInversionsTestsFx, CountInversionsTest)
{
    auto param = GetParam();
    EXPECT_EQ(std::get<0>(param), countInversions(std::get<1>(param)));
}

INSTANTIATE_TEST_CASE_P(CountInversionsTests, CountInversionsTestsFx,
    ::testing::Values(
        CountInversionParameter(2, { 2, 4, 1 }),
        CountInversionParameter(9, { 8, 1, 7, 4, 2, 5 }),
        CountInversionParameter(0, { 1, 1, 2, 2, 2, 3, 10 })));