using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingProblemsTests.Utility
{
    public static class PairsParser
    {
        private static readonly Regex _regex = new Regex(@"\[(?<i1>\d+),\s?(?<i2>\d+)\]");

        public static int[][] ToArrays(this string stringedArr)
        {
            return ToPairs(stringedArr, (i1, i2) => new int[] { i1, i2 }).ToArray();
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
                int i1 = Int32.Parse(match.Groups["i1"].Value);
                int i2 = Int32.Parse(match.Groups["i2"].Value);
                lists.Add(toPair(i1, i2));
            }

            return lists;
        }
    }
}
