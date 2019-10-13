using System;
using System.Diagnostics;

namespace CodingProblems
{
    public static class Program
    {
        public static void Main(string[] _)
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
            {
                // Primitive performance test here...
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
