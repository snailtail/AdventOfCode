using System;
using System.IO;

namespace AdventOfCode.TwentyTwenty.Day13
{
    class Program
    {
        //private const string Path = "smallinput.txt";
        private const string Path = "input.txt";
        static void Main(string[] args)
        {
            var arrInput = File.ReadAllLines(Path);
            Console.WriteLine($"Timestamp for my earliest departure: {arrInput[0]}");
            Console.WriteLine($"Bus IDs in service (ignore x:es): {arrInput[1]}");
            var myparser = new BusLineParser(arrInput[1]);
            myparser.earliestDepartureTime=ulong.Parse(arrInput[0]);
            Console.WriteLine($"Day 13 Step 1: {myparser.Step1ClosestDeparture()}");
            //Test
            var step2Computer=new Day13Step2();
            System.Console.WriteLine($"Day 13 Step 2: {step2Computer.Compute(arrInput[1])}");

        }
    }
}
