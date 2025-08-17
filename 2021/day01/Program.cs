using AdventOfCode.Helpers;

namespace AdventOfCode.Y2021
{
    public static class Day01
    {        
        public static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            var myMeasurementizer = new Measurementizer(lines);
            Console.WriteLine(myMeasurementizer.SinglesIncreases);
            Console.WriteLine(myMeasurementizer.GroupIncreases);
        }
    }
}

