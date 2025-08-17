using System;

namespace AdventOfCode.Helpers
{
    public class StringHelper
    {
        /// <summary>
        /// Takes a string, sorts the chars within the string as chars, returns them as a string.
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <returns>A string containing the characters from the input, sorted in order as characters.</returns>
        public string sortedString(string inputString)
        {
            char[] charArray = inputString.ToCharArray();
            Array.Sort<char>(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Takes two strings, compares them and calculates how many characters would need to be changed to make them identical
        /// This is returned as an integer.
        /// </summary>
        /// <param name="source">The first string in the comparison</param>
        /// <param name="target">The second string in the comparison</param>
        /// <returns>An integer containing the number of characters you would need to change in one of the strings to make them identical.</returns>
        public int LevenshteinDistance(string source, string target)
        {
            if (String.IsNullOrEmpty(source))
            {
                if (String.IsNullOrEmpty(target)) return 0;
                return target.Length;
            }
            if (String.IsNullOrEmpty(target)) return source.Length;

            if (source.Length > target.Length)
            {
                var temp = target;
                target = source;
                source = temp;
            }

            var m = target.Length;
            var n = source.Length;
            var distance = new int[2, m + 1];
            // Initialize the distance 'matrix'
            for (var j = 1; j <= m; j++) distance[0, j] = j;

            var currentRow = 0;
            for (var i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                distance[currentRow, 0] = i;
                var previousRow = currentRow ^ 1;
                for (var j = 1; j <= m; j++)
                {
                    var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
                    distance[currentRow, j] = Math.Min(Math.Min(
                        distance[previousRow, j] + 1,
                        distance[currentRow, j - 1] + 1),
                        distance[previousRow, j - 1] + cost);
                }
            }
            return distance[currentRow, m];
        }
    }
}