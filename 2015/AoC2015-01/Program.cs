using System;
using System.IO;

namespace AdventOfCode.TwentyFifteen.Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = File.ReadAllText("input.txt");
            var myElf = new Elf();
            System.Console.WriteLine("*** AdventOfCode 2015 ***");
            System.Console.WriteLine("--- Day 1: Not Quite Lisp ---");

            System.Console.WriteLine($"Step 1 result: {myElf.ParseFloorInstructions(inputString)}");
            System.Console.WriteLine($"Step 2 result: {myElf.EnteredBasementAt}");
        }
    }
}
