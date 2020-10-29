#pragma once
#include <map>
#include <limits>

// Efficient interval map implementation
// The tests are located in the CppCodingProblemsTests project in the IntervalMapTests.cpp file

// Only operator < and numeric_limits::lowest necessary for keys and operator == for values,
// so it's safer to use custom types with only needed functionality

struct key_type
{
    int value;
};

inline bool operator <(const key_type& key1, const key_type& key2)
{
    return key1.value < key2.value;
}

struct value_type
{
    char value;
};

inline bool operator == (const value_type& val1, const value_type& val2)
{
    return val1.value == val2.value;
}

namespace std {
    template<> class numeric_limits<key_type> {
    public:
        static key_type lowest() { 
            return key_type{ numeric_limits<int>::lowest() };
        }
        static key_type max() {
            return key_type{ numeric_limits<int>::max() };
        }
    };
}

template<typename K, typename V>
class interval_map {
    std::map<K, V> _map;

public:
    interval_map(V const& val) {
        _map.insert(_map.end(), std::make_pair(std::numeric_limits<K>::lowest(), val));
    }

    void assign(K const& keyBegin, K const& keyEnd, V const& val) {
        if (!(keyBegin < keyEnd))
            return;

        // 1st stage: try to insert new end entry
        auto itAtTheEntryAfterTheEnd = _map.upper_bound(keyEnd); // itA
        auto itAtTheEndOfComposedRange = itAtTheEntryAfterTheEnd; // itB
        auto itAtCurrentEntryAtTheEnd = std::prev(itAtTheEntryAfterTheEnd); // itC

        auto areKeysEq = [](const K& k1, const K& k2) -> bool { return !(k1 < k2) && !(k2 < k1); };

        // i.e. if keyEnd == 10
        //              itC  itA, itB
        // lower    1   10   15
        // z        a   b    z

        if (!(itAtCurrentEntryAtTheEnd->second == val))
        {
            itAtTheEndOfComposedRange = itAtCurrentEntryAtTheEnd;

            // i.e. if keyEnd == 10
            //              itC, itB    itA
            // lower    1   10          15
            // z        a   b           z

            if (!areKeysEq(itAtCurrentEntryAtTheEnd->first, keyEnd))
                itAtTheEndOfComposedRange = _map.insert(itAtTheEntryAfterTheEnd, std::make_pair(keyEnd, itAtCurrentEntryAtTheEnd->second));

            // i.e. if keyEnd == 12
            //              itC     itB    itA
            // lower    1   10      12      15
            // z        a   b       b       z
        }

        // 2nd stage: cleaning up existing entries in the range
        auto itBeforeOrAtTheBeginOfInsertingRange = std::prev(_map.upper_bound(keyBegin)); //itE

        // i.e. if keyBegin == 7
        //          itE
        // lower    1       10          15
        // z        a       b           z

        if (areKeysEq(itBeforeOrAtTheBeginOfInsertingRange->first, keyBegin) && itBeforeOrAtTheBeginOfInsertingRange != _map.begin())
        {
            auto itAtThePrevRangeBegin = std::prev(itBeforeOrAtTheBeginOfInsertingRange);
            if (itAtThePrevRangeBegin->second == val)
                itBeforeOrAtTheBeginOfInsertingRange = itAtThePrevRangeBegin;
        }

        while (std::next(itBeforeOrAtTheBeginOfInsertingRange) != itAtTheEndOfComposedRange)
            _map.erase(std::next(itBeforeOrAtTheBeginOfInsertingRange));

        // 3rd stage: try to insert new start entry
        if (!(itBeforeOrAtTheBeginOfInsertingRange->second == val))
        {
            if (areKeysEq(itBeforeOrAtTheBeginOfInsertingRange->first, keyBegin))
                itBeforeOrAtTheBeginOfInsertingRange->second = val;
            else
                _map.insert(itAtTheEndOfComposedRange, std::make_pair(keyBegin, val));
        }
    }

    V const& operator[](K const& key) const {
        return (--_map.upper_bound(key))->second;
    }

    bool checkIfCanonical()
    {
        auto itCurElem = _map.begin();

        value_type curVal = itCurElem->second;

        while (++itCurElem != _map.end())
        {
            if (curVal == itCurElem->second)
                return false;

            curVal = itCurElem->second;
        }

        return true;
    }
};
