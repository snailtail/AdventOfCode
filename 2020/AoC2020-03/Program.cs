using System;
using System.IO;

namespace AdventOfCode.TwentyTwenty.Day03
{
    class Program
    {
        private const string Path = "input.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Day 3 Step 1 result: {0}", Step1());
            Console.WriteLine("Day 3 Step 2 result: {0}", Step2());
        }

        public static int Step1()
        {
            var arrDay3Data = File.ReadAllLines(Path);
            return SlopeChecker(arrDay3Data, 3, 1);
        }

        public static long Step2()
        {
            var arrDay3Data = File.ReadAllLines(Path);
            /**
                Check multiple slopes, and multiply their outputs together for the answer:
                Right 1, down 1.
                Right 3, down 1. (This is the slope you already checked.)
                Right 5, down 1.
                Right 7, down 1.
                Right 1, down 2.
            **/

            // int will not do, the output will (might) overflow and create an invisible cap on the result
            // use long, since the int's will easily convert to the "bigger" long.
            long slope1 = SlopeChecker(arrDay3Data, 1, 1);
            long slope2 = SlopeChecker(arrDay3Data, 3, 1);
            long slope3 = SlopeChecker(arrDay3Data, 5, 1);
            long slope4 = SlopeChecker(arrDay3Data, 7, 1);
            long slope5 = SlopeChecker(arrDay3Data, 1, 2);

            return (slope1 * slope2 * slope3 * slope4 * slope5);
        }


        private static int SlopeChecker(string[] arrStringData, int rightStep, int downStep)
        {
            int columnPos = rightStep;
            //char clear = '.';
            char tree = '#';
            int treeCount = 0;
            for (int row = 0; row < arrStringData.Length - downStep; row += downStep)
            {
                //Console.WriteLine($"Row {row+1}: {arrStringData[row + 1]}");
                //Console.WriteLine($"Column pos: {columnPos}, char: {arrStringData[row + 1][columnPos]}");
                if (arrStringData[row + downStep][columnPos] == tree)
                {
                    treeCount++;
                }
                columnPos += rightStep;
                if (columnPos > arrStringData[row + downStep].Length - 1)
                {
                    columnPos -= (arrStringData[row + downStep].Length);
                }
            }

            return treeCount;
        }
    }
}
