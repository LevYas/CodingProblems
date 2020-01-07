namespace CodingProblems.Numbers
{
    public static class PrimeNumbersCounter
    {
        // Count Primes
        // Count the number of prime numbers less than a non-negative number, n.
        // Runtime: 72 ms, faster than 70.35% of C# online submissions
        // https://leetcode.com/problems/count-primes/
        public static int CountPrimes(int n)
        {
            if (n <= 2)
                return 0;

            bool[] isPrimeFlags = new bool[n];

            for (int i = 2; i < n; i++)
                isPrimeFlags[i] = true;

            // The Sieve of Eratosthenes
            for (int i = 2; i * i < n; i++)
            {
                if (!isPrimeFlags[i])
                    continue;

                for (int j = i * i; j < n; j += i)
                    isPrimeFlags[j] = false;
            }

            int primesCount = 1;

            for (int i = 3; i < n; i += 2)
            {
                if (isPrimeFlags[i])
                    ++primesCount;
            }

            return primesCount;
        }
    }
}
