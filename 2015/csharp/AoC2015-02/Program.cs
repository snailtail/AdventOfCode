using System;
using System.IO;

namespace AdventOfCode.TwentyFifteen.Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = File.ReadAllLines("input.txt");
            var myElf = new Elf();
            System.Console.WriteLine("*** Advent Of Code 2015 ***");
            System.Console.WriteLine("--- Day 2: I Was Told There Would Be No Math ---");
            System.Console.WriteLine();
            System.Console.WriteLine($"Step 1 result: {myElf.PackageListToSquareFeet(inputData)}");
            System.Console.WriteLine($"Step 2 result: {myElf.PackageListToRibbonLength(inputData)}");

        }
    }
}
