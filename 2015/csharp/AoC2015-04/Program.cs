using System;

namespace AdventOfCode.TwentyFifteen.Day04
{
    class Program
{   
        private const string SecretKey = "yzbqklnj";
        static void Main(string[] args)
        {
            // input: 
            Console.WriteLine("*** Advent Of Code 2015 ***");
            Console.WriteLine("--- Day 4: The Ideal Stocking Stuffer ---");
            Console.WriteLine();

            var myHashFinder = new MD5HashFinder();
            var SecretNumber = myHashFinder.FindNumberForKey(SecretKey);
            Console.WriteLine($"Step 1 Result: {SecretNumber}");
            var SecretNumberStep2 = myHashFinder.FindNumberForKeyStep2(SecretKey);
            Console.WriteLine($"Step 2 Result: {SecretNumberStep2}");

        }
    }
}
