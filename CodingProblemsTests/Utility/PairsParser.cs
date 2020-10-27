using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CodingProblemsTests.Utility
{
    public static class PairsParser
    {
        private static readonly Regex _regex = new Regex(@"\[(?<i1>\d+),\s?(?<i2>\d+)\]");

        public static int[][] ToArrays(this string stringedArr)
        {
            return ToPairs(stringedArr, (i1, i2) => new[] { i1, i2 }).ToArray();
        }

        public static List<IList<int>> ToILists(this string stringedArr)
        {
            return ToPairs(stringedArr, (i1, i2) => new List<int> { i1, i2 } as IList<int>);
        }

        public static List<T> ToPairs<T>(string stringedArr, Func<int, int, T> toPair)
        {
            var lists = new List<T>();

            foreach (Match match in _regex.Matches(stringedArr))
            {
                int i1 = Int32.Parse(match.Groups["i1"].Value, CultureInfo.InvariantCulture);
                int i2 = Int32.Parse(match.Groups["i2"].Value, CultureInfo.InvariantCulture);
                lists.Add(toPair(i1, i2));
            }

            return lists;
        }
    }
}
