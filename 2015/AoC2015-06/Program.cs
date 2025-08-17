using System;

namespace AdventOfCode.TwentyFifteen.Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Advent Of Code 2015 ***");
            Console.WriteLine("--- Day 6: Probably a Fire Hazard ---");
            Console.WriteLine();

            var myGrid = new LightGrid();
            var Step1Result=myGrid.ComputeStep1();
            System.Console.WriteLine($"Step 1 Result: {Step1Result}");
            var Step2Result = myGrid.ComputeStep2();
            System.Console.WriteLine($"Step 2 Result: {Step2Result}");
        }
    }
}
