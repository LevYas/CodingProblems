#include "pch.h"
#include "..\CppCodingProblems\IntervalMap.h"

void assignAndCheck(interval_map<key_type, value_type>& im, int beg, int end, char val)
{
    key_type begk{ beg };
    key_type endk{ end };
    value_type valv{ val };

    value_type valBeforeTheRange = im[key_type{ beg - 1 }];
    value_type valAtTheRangeStart = im[begk];
    value_type valAtTheRangeEnd = im[endk];
    value_type valAfterTheRange = im[key_type{ end + 1 }];

    im.assign(begk, endk, valv);

    ASSERT_EQ(valBeforeTheRange, im[key_type{ beg - 1 }]);

    if (!(valAtTheRangeStart == valv))
        ASSERT_FALSE(valAtTheRangeStart == im[begk]);

    ASSERT_EQ(valv, im[begk]);

    if (end > beg + 1)
        ASSERT_EQ(valv, im[key_type{ beg + 1 }]);

    ASSERT_EQ(valAtTheRangeEnd, im[endk]);

    if (endk < std::numeric_limits<key_type>::max())
        ASSERT_EQ(valAfterTheRange, im[key_type{ end + 1 }]);
    else
        ASSERT_EQ(valAfterTheRange, im[key_type{ end }]);

    ASSERT_TRUE(im.checkCanonicalness());
}

interval_map<key_type, value_type> createZfilledMap()
{
    return interval_map<key_type, value_type>(value_type{ 'z' });
}

class IntervalMapTest : public ::testing::Test
{
protected:
    interval_map<key_type, value_type> IntervalMap = createZfilledMap();
};

TEST_F(IntervalMapTest, CreationAndSimpleRangeOverlapping)
{
    assignAndCheck(IntervalMap, 1, 10, 'a');
    assignAndCheck(IntervalMap, 10, 15, 'b');
    assignAndCheck(IntervalMap, 15, std::numeric_limits<int>::max(), 'c');

    assignAndCheck(IntervalMap, 7, 13, 'e');
}

TEST_F(IntervalMapTest, KeysOverlapping)
{
    assignAndCheck(IntervalMap, 1, 10, 'a');
    assignAndCheck(IntervalMap, 7, 10, 'e');
}

TEST_F(IntervalMapTest, KeysFullOverlapping)
{
    assignAndCheck(IntervalMap, 1, 10, 'a');
    assignAndCheck(IntervalMap, 1, 10, 'a');
}

TEST_F(IntervalMapTest, OneKey)
{
    assignAndCheck(IntervalMap, 1, 2, 'a');
}

TEST_F(IntervalMapTest, RangesOverriding)
{
    assignAndCheck(IntervalMap, 1, 10, 'a');
    assignAndCheck(IntervalMap, 10, 15, 'b');
    assignAndCheck(IntervalMap, 15, std::numeric_limits<int>::max(), 'c');

    assignAndCheck(IntervalMap, 10, 15, 'e');
}

TEST_F(IntervalMapTest, SeveralRangesOverlapping)
{
    assignAndCheck(IntervalMap, 1, 5, 'a');
    assignAndCheck(IntervalMap, 5, 10, 'b');
    assignAndCheck(IntervalMap, 10, 12, 'c');
    assignAndCheck(IntervalMap, 12, 15, 'd');
    assignAndCheck(IntervalMap, 15, std::numeric_limits<int>::max(), 'f');

    assignAndCheck(IntervalMap, std::numeric_limits<int>::lowest(), std::numeric_limits<int>::max(), 'z');

    assignAndCheck(IntervalMap, -1, 20, 'e');
}

TEST_F(IntervalMapTest, InsertingTheRangeWithSameVals)
{
    assignAndCheck(IntervalMap, 1, 10, 'a');
    assignAndCheck(IntervalMap, 3, 5, 'a');
    assignAndCheck(IntervalMap, 5, 10, 'a');
    assignAndCheck(IntervalMap, 1, 5, 'a');
}

TEST_F(IntervalMapTest, InsertingOverridingRangeWithSameVals)
{
    assignAndCheck(IntervalMap, 1, 10, 'a');
    assignAndCheck(IntervalMap, 10, 15, 'b');
    assignAndCheck(IntervalMap, 15, 20, 'a');
    assignAndCheck(IntervalMap, 1, 18, 'a');
}

TEST_F(IntervalMapTest, DISABLED_InsertingOverridingRangeWithSameValsIncrementally)
{
    assignAndCheck(IntervalMap, 1, 10, 'a');
    assignAndCheck(IntervalMap, 10, 11, 'a');
    assignAndCheck(IntervalMap, 11, 12, 'a');
    assignAndCheck(IntervalMap, 12, 13, 'a');
    assignAndCheck(IntervalMap, 11, 13, 'a');
}

TEST_F(IntervalMapTest, SeveralNegativeRangesOverlapping)
{
    assignAndCheck(IntervalMap, -15, -12, 'a');
    assignAndCheck(IntervalMap, -12, -10, 'b');
    assignAndCheck(IntervalMap, -10, -5, 'c');
    assignAndCheck(IntervalMap, -5, -1, 'f');
    assignAndCheck(IntervalMap, -1, std::numeric_limits<int>::max(), 'g');

    assignAndCheck(IntervalMap, -14, -1, 'e');
}

TEST_F(IntervalMapTest, FillingFromLowest)
{
    assignAndCheck(IntervalMap, std::numeric_limits<int>::lowest(), std::numeric_limits<int>::max(), 'a');
}
