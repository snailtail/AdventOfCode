using System;

namespace AdventOfCode.TwentyFifteen.Day05
{
    class Program
    {
        private const string Path="input.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("*** Advent Of Code 2015 ***");
            Console.WriteLine("--- Day 5: Doesn't He Have Intern-Elves For This? ---");
            Console.WriteLine();
            var myParser = new NaughtyNiceParser();
            var Step1Result  = myParser.CountNiceStringsInFile(Path);
            Console.WriteLine($"Step 1 Result: {Step1Result}");
            var Step2Result  = myParser.CountNiceStringsInFile2(Path);
            Console.WriteLine($"Step 2 Result: {Step2Result}");

        }
    }
}
