using System;
using Xunit;
using AoC2017_05;
using Shouldly;
namespace AoC2017_05Tests
{

    /* Sample values are
        0
        3
        0
        1
        -3
    */
    public class Tests
    {
        [Theory]
        [InlineData(new string[] {"0","3","0","1","-3"},5)]
        public void Step1(string[] jumps, int expected)
        {
            AoC201705 myProcessor = new AoC201705();
            myProcessor.ProcessList(jumps,false).ShouldBe(expected);
        }

        [Theory]
        [InlineData(new string[] {"0","3","0","1","-3"},10)]
        public void Step2(string[] jumps, int expected)
        {
            AoC201705 myProcessor = new AoC201705();
            myProcessor.ProcessList(jumps,true).ShouldBe(expected);
        }
    }
}
