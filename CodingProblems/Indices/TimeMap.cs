namespace CodingProblems.Indices;

// 981. Time Based Key-Value Store
// Design a time-based key-value data structure that can store multiple values for the same key at different time stamps
//      and retrieve the key's value at a certain timestamp.
// Implement the TimeMap class:
//      TimeMap() Initializes the object of the data structure.
//      void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
//      String get(String key, int timestamp) Returns a value such that set was called previously, with timestamp_prev <= timestamp.
//          If there are multiple such values, it returns the value associated with the largest timestamp_prev.
//          If there are no values, it returns "".
// https://leetcode.com/problems/time-based-key-value-store/

public class TimeMap
{
    private readonly Dictionary<string, List<(int, string)>> _keysToTimedValues = new();

    public void Set(string key, string value, int timestamp)
    {
        _keysToTimedValues.TryAdd(key, new List<(int, string)>());
        _keysToTimedValues[key].Add((timestamp, value));
    }

    public string Get(string key, int timestamp)
    {
        if (!_keysToTimedValues.ContainsKey(key))
            return "";

        List<(int timestamp, string value)> timesWithValues = _keysToTimedValues[key];

        if (timesWithValues[^1].timestamp <= timestamp)
            return timesWithValues[^1].value;

        if (timesWithValues[0].timestamp > timestamp)
            return "";

        var comparer = Comparer<(int t, string v)>.Create((a, b) => a.t.CompareTo(b.t));

        int idx = timesWithValues.BinarySearch((timestamp, ""), comparer);

        if (idx < 0)
            idx = ~idx - 1;

        return timesWithValues[idx].value;
    }
}
