using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodingProblems
{
    public static class Program
    {
        public static void Main()
        {
            List<long> measures = new List<long>();

            for (int j = 0; j < 10; j++)
            {
                Stopwatch sw = Stopwatch.StartNew();

                for (int i = 0; i < 1000000; i++)
                {
                    // Primitive performance test here...
                }

                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                measures.Add(sw.ElapsedMilliseconds);
            }

            Console.WriteLine($"Mean: {measures.Sum() / measures.Count}");

            Console.ReadLine();
        }
    }
}
