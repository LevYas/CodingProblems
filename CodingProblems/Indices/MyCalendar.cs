namespace CodingProblems.Indices;

// 729. My Calendar I
// You are implementing a program to use as your calendar. We can add a new event if adding the event will not cause a double booking.
// A double booking happens when two events have some non-empty intersection (i.e., some moment is common to both events.).
// The event can be represented as a pair of integers start and end that represents a booking on the half-open interval [start, end),
//      the range of real numbers x such that start <= x < end.
// Implement the MyCalendar class:
//      MyCalendar() Initializes the calendar object.
//      boolean book(int start, int end) Returns true if the event can be added to the calendar successfully without
//          causing a double booking. Otherwise, return false and do not add the event to the calendar.
// https://leetcode.com/problems/my-calendar-i/

public class MyCalendar
{
    private readonly List<(int start, int end)> _appointments = new();
    
    public bool Book(int start, int end)
    {
        int idxForNew = search(start);

        // conflict with current (which is equal or bigger) if any
        if (idxForNew < _appointments.Count && _appointments[idxForNew].start < end)
            return false;

        // Check for conflict with prev
        if (idxForNew > 0 && _appointments[idxForNew - 1].end > start)
            return false;

        // Check for conflict with next
        if (idxForNew < _appointments.Count - 1 && _appointments[idxForNew + 1].start < end)
            return false;

        _appointments.Insert(idxForNew, (start, end));
        return true;
    }

    private int search(int target)
    {
        int lo = 0;
        int hi = _appointments.Count;

        while (lo < hi)
        {
            int mid = (lo + hi) / 2;

            if (_appointments[mid].start == target)
                return mid;

            if (_appointments[mid].start > target)
                hi = mid;
            else
                lo = mid + 1;
        }

        return lo;
    }
}
