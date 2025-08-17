using System;
using Xunit;
using AoC2017_06;
using Shouldly;

namespace AoC2017_06Tests
{
    public class Tests
    {
        [Theory]
        [InlineData("0	2	7	0", 5)]
        public void Step1(string banks, int expected)
        {
            AoC201706 myProcessor = new AoC201706();
            myProcessor.balanceBlocks(banks, false).ShouldBe(expected);
        }

        [Theory]
        [InlineData("0	2	7	0", 4)]
        public void Step2(string banks, int expected)
        {
            AoC201706 myProcessor = new AoC201706();
            myProcessor.balanceBlocks(banks, true).ShouldBe(expected);
        }
    }
}
