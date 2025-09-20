namespace CodingProblems.MathProblems;

// 1515. Best Position for a Service Centre
// A delivery company wants to build a new service center in a new city.
// The company knows the positions of all the customers in this city on a 2D-Map and wants to build
//      the new center in a position such that the sum of the euclidean distances to all customers is minimum.
// Given an array positions where positions[i] = [xi, yi] is the position of the ith customer on the map,
//      return the minimum sum of the euclidean distances to all customers.
// In other words, you need to choose the position of the service center [xcentre, ycentre] such that the sum of all distances is minimum.
// Answers within 10-5 of the actual value will be accepted.
// https://leetcode.com/problems/best-position-for-a-service-centre/

public class ServiceCenterPlacer
{
    public double GetMinDistSum(int[][] positions)
    {
        if (positions.Length <= 1)
            return 0;

        double top = 0, bottom = 100, left = 100, right = 0;

        foreach (int[] pt in positions)
        {
            left = Math.Min(left, pt[0]);
            bottom = Math.Min(bottom, pt[1]);

            right = Math.Max(right, pt[0]);
            top = Math.Max(top, pt[1]);
        }

        // Do not put it in the loop, since it may not be updated every time, which will affect bbox adjustment
        (double x, double y) closest = (0, 0);
        double minDistanceSum = Double.MaxValue;

        for (double delta = 10; delta >= 1e-5; delta /= 10)
        {
            for (double x = left; x <= right; x += delta)
            {
                for (double y = bottom; y <= top; y += delta)
                {
                    double distanceSum = positions.Sum(p => Math.Sqrt((p[0] - x) * (p[0] - x) + (p[1] - y) * (p[1] - y)));

                    if (distanceSum < minDistanceSum)
                    {
                        minDistanceSum = distanceSum;
                        closest = (x, y);
                    }
                }
            }

            // The performance can be optimized if we will not extend bbox more than initial one
            left = closest.x - delta;
            right = closest.x + delta;

            bottom = closest.y - delta;
            top = closest.y + delta;
        }

        return minDistanceSum;
    }
}
