using System.Collections.Generic;
using System.Linq;

namespace CodingProblems.Other
{
    // A cinema has n rows of seats, numbered from 1 to n and there are ten seats in each row, labeled from 1 to 10.
    // Given the array reservedSeats containing the numbers of seats already reserved, for example,
    //      reservedSeats[i] = [3,8] means the seat located in row 3 and labeled with 8 is already reserved.
    // Return the maximum number of four-person groups you can assign on the cinema seats.
    // A four-person group occupies four adjacent seats in one single row.
    // Seats across an aisle (such as [3,3] and [3,4]) are not considered to be adjacent,
    // but there is an exceptional case on which an aisle split a four-person group, in that case,
    // the aisle split a four-person group in the middle, which means to have two people on each side.
    // https://leetcode.com/problems/cinema-seat-allocation/
    public static class CinemaSeatAllocator
    {
        public static int MaxNumberOfFamilies(int numberOfRows, int[][] reservedSeats)
        {
            // We use integer in value as mask. It's not kind of a real world solution,
            // but LeetCode wants to process thousand values very quickly
            var reservations = new Dictionary<int, int>();

            // we are not interested in end seats
            foreach (int[] reservedSeat in reservedSeats.Where(c => c[1] > 1 && c[1] < 10))
            {
                if (reservations.TryGetValue(reservedSeat[0], out int rowMask))
                    reservations[reservedSeat[0]] = rowMask | 1 << reservedSeat[1] - 2;
                else
                    reservations.Add(reservedSeat[0], 1 << reservedSeat[1] - 2);
            }

            int possiblePlacementsAmount = numberOfRows * 2;

            foreach (int rowMask in reservations.Values)
            {
                bool areLeftSeatsFree = (rowMask & 0b1111) == 0;
                bool areCenterSeatsFree = (rowMask & 0b111100) == 0;
                bool areRightSeatsFree = (rowMask & 0b11110000) == 0;

                if (areLeftSeatsFree || areCenterSeatsFree || areRightSeatsFree)
                    possiblePlacementsAmount--;
                else
                    possiblePlacementsAmount -= 2;
            }

            return possiblePlacementsAmount;
        }
    }
}
