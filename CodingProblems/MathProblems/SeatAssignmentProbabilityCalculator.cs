namespace CodingProblems.MathProblems;

// 1227. Airplane Seat Assignment Probability
// n passengers board an airplane with exactly n seats.
//      The first passenger has lost the ticket and picks a seat randomly.
//      But after that, the rest of the passengers will:
//          Take their own seat if it is still available, and
//              Pick other seats randomly when they find their seat occupied
//              Return the probability that the nth person gets his own seat.
// https://leetcode.com/problems/airplane-seat-assignment-probability/

public class SeatAssignmentProbabilityCalculator
{
    // The tricky part here is the math
    // You can write down the tree of possible seat allocations and see that there are always half of the cases are successful
    // For random person k, which found his place occupied, we have 3 choices:
    //      Sit on seat 1 in which case last person will surely sit on his seat.
    //      Sit on last seat in which case last person will surely not sit on his seat.
    //      Sit on some seat from k+1 to n-1.
    // The last option will expose the same choices for the next person with occupied seat.

    public double LastPersonGetsOwnSeat(int n)
    {
        return n == 1 ? 1 : 0.5;
    }
}
