using System;
using Xunit;
using Shouldly;
using AdventOfCode.TwentyTwenty.Day15;

namespace AdventOfCode.TwentyTwenty.Day15tests
{
    public class Day15Test
    {
        [Theory]
        [InlineData("1,3,2","1")]
        [InlineData("2,1,3","10")]
        [InlineData("1,2,3","27")]
        [InlineData("2,3,1","78")]
        [InlineData("3,2,1","438")]
        [InlineData("3,1,2","1836")]
        public void TestStep1(string TestData, string Result)
        {
            var testObj = new Day15.Step1();
            var testArr=TestData.Split(",");
            testObj.GoalIndex=2020;
            testObj.Compute(testArr).ShouldBe(Result);
        }

        [Theory]
        [InlineData("3,2,1",18)]
        [InlineData("3,1,2",362)]
        public void TestStep2(string TestData, int Result)
        {
            var secondStep=new Day15.Step2();
            
            var testArr=TestData.Split(",");

            var GoalIndex=30000000;
            
            secondStep.Compute(testArr,GoalIndex).ShouldBe(Result);
        }


        [Theory]
        [InlineData("1,3,2",1)]
        [InlineData("2,1,3",10)]
        [InlineData("1,2,3",27)]
        [InlineData("2,3,1",78)]
        [InlineData("3,2,1",438)]
        [InlineData("3,1,2",1836)]
        public void TestStep1DataInStep2(string TestData, int Result)
        {
            var testObj = new Day15.Step2();
            var testArr=TestData.Split(",");
            var GoalIndex=2020;
            testObj.Compute(testArr,GoalIndex).ShouldBe(Result);
        }
    }
}
