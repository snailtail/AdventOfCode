using System;
using Xunit;
using Shouldly;
using AoC2017_02;

namespace AoC2017_02Tests
{
    public record testresult(int step1, int step2);

    public class Tests
    {
        /* STEP 1
        For example, given the following spreadsheet:

        5 1 9 5
        7 5 3
        2 4 6 8

        In this example, the spreadsheet's checksum would be 8 + 4 + 6 = 18.
        */
        [Theory]
        [InlineData(new string[] { "5 1 9 5", "7 5 3", "2 4 6 8" }, 18)]
        public void Step1(string[] input, int expectedResult)
        {
            var expected = Tuple.Create<int, int>(expectedResult, 0);
            var actual = AoC201702.Process(input);
            actual.Item1.ShouldBe(expected.Item1);
        }

        /* STEP 2
            For example, given the following spreadsheet:

            5 9 2 8
            9 4 7 3
            3 8 6 5
            
            In this example, the sum of the results would be 4 + 3 + 2 = 9
        */
        [Theory]
        [InlineData(new string[] {"5 9 2 8", "9 4 7 3","3 8 6 5"}, 9)]
        public void Step2(string[] input, int expectedResult)
        {
            var expected = Tuple.Create<int, int>(0, expectedResult);
            var actual = AoC201702.Process(input);
            actual.Item2.ShouldBe(expected.Item2);
        }
    }
}
