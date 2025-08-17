using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.TwentyTwenty.Day05
{
    class Program
    {
        private const string Path = "input.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Day 5 Step 1 result: {0}", Step1());
            Console.WriteLine("Day 5 Step 2 result: {0}", Step2());
        }

        public static long Step1()
        {
            var arrDay5Data = File.ReadAllLines(Path);
            var highestValue = long.MinValue;
            foreach (var line in arrDay5Data)
            {
                var rowNum = GetRowFromCode(line.Substring(0, 7));
                //Console.WriteLine($"Row: {rowNum}");
                var colNum = GetColumnFromCode(line.Substring(7, 3));
                //Console.WriteLine($"Col: {colNum}");
                var seatNum = (rowNum * 8) + colNum;
                if (seatNum > highestValue)
                    highestValue = seatNum;
            }

            return highestValue;
        }

        public static long Step2()
        {
            var arrDay5Data = File.ReadAllLines(Path);
            var SeatList = new List<long>();
            foreach (var line in arrDay5Data)
            {
                var rowNum = GetRowFromCode(line.Substring(0, 7));
                //Console.WriteLine($"Row: {rowNum}");
                var colNum = GetColumnFromCode(line.Substring(7, 3));
                //Console.WriteLine($"Col: {colNum}");
                var seatNum = (rowNum * 8) + colNum;
                SeatList.Add(seatNum);
            }
            SeatList.Sort();
            for (var n = 0; n < SeatList.Count; n++)
            {
                if (SeatList[n + 1] == SeatList[n] + 2)
                {
                    return SeatList[n] + 1;
                }
            }
            return -1;
        }


        private static long GetRowFromCode(string RowCode)
        {
            return BinaryToLong(RowCode.Replace('B', '1').Replace('F', '0'));
        }

        private static long GetColumnFromCode(string ColumnCode)
        {
            return BinaryToLong(ColumnCode.Replace('R', '1').Replace('L', '0'));
        }

        private static long BinaryToLong(string strBinary)
        {
            // default return
            long lReturn = 0;


            // avoid empty strings
            // you may want to do other checks (only 0's and 1's, or
            //  longer than 64 bits)
            // you could also remove all front padding 0's because they
            //  could make you think the string is too long, but extra
            //  0's don't mean anything, really (e.g., "00001110" is 8 bits,
            //    but it fits in a 4 bit number because the "0000" is useless info)
            if (string.IsNullOrEmpty(strBinary))
                return 0;


            // take the binary string and convert it to its integer form
            for (int i = strBinary.Length - 1; i > -1; --i)
            {
                // if it's already a 0, then it's already there
                if (strBinary[i] == '1')
                    lReturn |= (1L << (strBinary.Length - i - 1)); // starts at 0
            }


            // return the value
            return lReturn;
        }
    }
}
