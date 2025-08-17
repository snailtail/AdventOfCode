using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day06
{
    class Program
    {
        private const string Path = "input.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Day 6 Step 1 result: {0}", Step1());
            Console.WriteLine("Day 6 Step 2 result: {0}", Step2());
        }

        public static int Step1()
        {

            var answerData = File.ReadAllText(Path);


            var answerGroups = GetAnswerGroups(answerData);
            var sum = 0;
            foreach (var group in answerGroups)
            {
                //Console.WriteLine(group);
                var myGroup = new Group();
                myGroup.ProcessGroupString(group);
                sum += myGroup.UniqueAnswersStep1;
            }

            return sum;

        }

        public static int Step2()
        {
            var answerData = File.ReadAllText(Path);


            var answerGroups = GetAnswerGroups(answerData);
            var sum = 0;
            foreach (var group in answerGroups)
            {
                //Console.WriteLine(group);
                var myGroup = new Group();
                myGroup.ProcessGroupString(group);
                sum += myGroup.UnanimousAnswersStep2;
            }

            return sum;
        }

        private static IEnumerable<string> GetAnswerGroups(string _answerData)
        {
            _answerData = _answerData.Replace(Environment.NewLine, "|").Replace("||", Environment.NewLine);
            char[] nline = new[] { '\r', '\n' };
            var _answerGroups = _answerData.Split(nline).Where(g => !string.IsNullOrEmpty(g));
            return _answerGroups;
        }
    }
}
