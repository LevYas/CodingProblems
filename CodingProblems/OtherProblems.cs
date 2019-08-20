using System.Linq;

namespace CodingProblems
{
    public class OtherProblems
    {
        // Given an array of time intervals (start, end) for classroom lectures (possibly overlapping),
        // find the minimum number of rooms required.
        public static int FindMinClassroomsAmount((int beg, int end)[] intervals)
        {
            int currentlyOccupiedRooms = 0;

            return intervals.SelectMany(interval => new (int time, int occupationChange)[] { (interval.beg, 1), (interval.end, -1) })
               .OrderBy(i => i.time)
               .Max(occupanceChange =>
               {
                   currentlyOccupiedRooms += occupanceChange.occupationChange;
                   return currentlyOccupiedRooms;
               });
        }
    }
}
