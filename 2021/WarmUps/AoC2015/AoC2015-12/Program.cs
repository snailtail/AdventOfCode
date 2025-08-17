using System.Text.RegularExpressions;
using AdventOfCode.Helpers;

namespace AoC2015
{
    public class Day12
    {

        public static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            string cleaned = WashUp(input);
            var someNumbers = cleaned.Split(',').Where(c => (!string.IsNullOrWhiteSpace(c) && !string.IsNullOrEmpty(c))).ToArray();
            int sum = 0;
            foreach (var n in someNumbers)
            {
                sum += StringToNumber.parseNegativeString(n);
                System.Console.WriteLine($"Sträng: {n} -> summa: {sum}");
            }
        }

        private static string WashUp(string input)
        {
            string rPattern = @"[^\-,\d]*";

            var result = Regex.Replace(input, rPattern, "");
            return result;
        }
    }
}



/*
[1,2,3] and {"a":2,"b":4} both have a sum of 6.
[[[3]]] and {"a":{"b":4},"c":-1} both have a sum of 3.
{"a":[-1,1]} and [-1,{"a":1}] both have a sum of 0.
[] and {} both have a sum of 0.
*/