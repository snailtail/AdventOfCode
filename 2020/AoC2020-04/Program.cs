using System;
using System.IO;

namespace AdventOfCode.TwentyTwenty.Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 4 Step 2(prev 1) result: {0}", Step1());
            // Oops, I got lazy and just modified step1 code for step 2.. :)
        }

        public static int Step1()
        {

            var allDay4Data = File.ReadAllText("input.txt");
            var tempData = allDay4Data.Replace(' ', '|').Replace(Environment.NewLine, "|");
            int counter = 0;
            tempData = tempData.Replace("||", Environment.NewLine);
            char[] nline = new[] { '\r', '\n' };
            string[] arrDay4Data = tempData.Split(nline, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(tempData);
            //var myTest = new Passport { byr = 1010, cid = 1, ecl="test", eyr=1010, hcl="test", hgt="test", iyr=1010, pid="hej" };
            foreach (var passportLine in arrDay4Data)
            {
                var myPassport = new Passport();
                var result = myPassport.ParsePassPortString(passportLine);
                if (result)
                {
                    counter++;
                }

            }
            return counter;
        }
    }
}
