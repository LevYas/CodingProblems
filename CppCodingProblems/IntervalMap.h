#pragma once
#include <map>
#include <limits>

// Efficient interval map implementation

// Only operator < and numeric_limits::lowest nesessary for keys and operator == for values,
// so it's safer to use custom types with only needed functionality

struct key_type
{
    int value;
};

bool operator <(const key_type& key1, const key_type& key2)
{
    return key1.value < key2.value;
}

struct value_type
{
    char value;
};

bool operator == (const value_type& val1, const value_type& val2)
{
    return val1.value == val2.value;
}

namespace std {
    template<> class numeric_limits<key_type> {
    public:
        static key_type lowest() { 
            return key_type{ numeric_limits<int>::lowest() };
        };
        static key_type max() {
            return key_type{ numeric_limits<int>::max() };
        };
    };
}

#define _ITERATOR_DEBUG_LEVEL 2

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

        auto areKeysEq = [](const K& k1, const K& k2) -> bool { return !(k1 < k2) && !(k1 < k2); };

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
        auto itAtTheEntryAfterTheBegin = _map.upper_bound(keyBegin); // itD
        auto itAtCurrentEntryAtTheBegin = std::prev(itAtTheEntryAfterTheBegin); //itE

        // i.e. if keyBegin == 7
        //          itE     itD        
        // lower    1       10          15
        // z        a       b           z

        // TODO: Fix canonicalness problem while adding incremental ranges
        // This code can fix it in this case, but it will fail other cases
        //if (areKeysEq(itAtCurrentEntryAtTheBegin->first, keyBegin))
        //    itAtTheEntryAfterTheBegin = itAtCurrentEntryAtTheBegin;

        while (itAtTheEntryAfterTheBegin != itAtTheEndOfComposedRange)
            itAtTheEntryAfterTheBegin = _map.erase(itAtTheEntryAfterTheBegin++);

        // 3rd stage: try to insert new start entry
        if (!(std::prev(itAtTheEntryAfterTheBegin)->second == val))
        {
            if (areKeysEq(itAtCurrentEntryAtTheBegin->first, keyBegin))
                itAtCurrentEntryAtTheBegin->second = val;
            else
                _map.insert(itAtTheEntryAfterTheBegin, std::make_pair(keyBegin, val));
        }
    }

    V const& operator[](K const& key) const {
        return (--_map.upper_bound(key))->second;
    }

    bool checkCanonicalness()
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
