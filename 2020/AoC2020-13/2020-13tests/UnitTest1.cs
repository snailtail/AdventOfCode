using System;
using Xunit;
using NUnit.Framework;
using Shouldly;
using AdventOfCode.TwentyTwenty.Day13;

namespace AdventOfCode.TwentyTwenty.Day13tests
{





    public class TestDay13Steps
    {
        [Theory]
        [InlineData(939, "7,13,x,x,59,x,31,19", 295)]
        [InlineData(1001612,"19,x,x,x,x,x,x,x,x,41,x,x,x,37,x,x,x,x,x,821,x,x,x,x,x,x,x,x,x,x,x,x,13,x,x,x,17,x,x,x,x,x,x,x,x,x,x,x,29,x,463,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,23", 6568)]
        public void TestAgainstStringInput(ulong earliestTimestamp, string inputData, ulong timeStamp)
        {
            var myTester = new Day13.BusLineParser(inputData);
            myTester.earliestDepartureTime=earliestTimestamp;
            myTester.Step1ClosestDeparture().ShouldBe(timeStamp);
        }

        [Theory]
        [InlineData("17,x,13,19",3417)]
        [InlineData("7,13,x,x,59,x,31,19",1068781)]
        [InlineData("1789,37,47,1889",1202161486)]
        public void Step2(string input, long expectedresult)
        {
            var myTester = new Day13Step2();
            myTester.Compute(input).ShouldBe(expectedresult);
        }
    }
}
