namespace CodingProblems.Indices
{
    public static class ClimbingStairsSolver
    {
        // Climbing Stairs
        // You are climbing a stair case. It takes n steps to reach to the top.
        // Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        // Actually, it's about finding n-th Fibonacci number
        // https://leetcode.com/problems/climbing-stairs/
        public static int ClimbStairs(int height)
        {
            if (height <= 1)
                return 1;

            int first = 1;
            int second = 2;

            for (int i = 2; i < height; i++)
            {
                int initialSecond = second;

                second += first;
                first = initialSecond;
            }

            return second;
        }
    }
}
