using System;
using Xunit;
using AdventOfCode.TwentyFifteen.Day01;
using Shouldly;
namespace AdventOfCode.TwentyFifteen.Day01tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("(())",0)]
        [InlineData("()()",0)]
        [InlineData("(()(()(",3)]
        [InlineData("(((",3)]
        [InlineData("))(((((",3)]
        [InlineData("())",-1)]
        [InlineData("))(",-1)]
        [InlineData(")))",-3)]
        [InlineData(")())())",-3)]
        public void TestStep1(string Instructions, int Expected)
        {
            var myElf = new Elf();
            myElf.ParseFloorInstructions(Instructions).ShouldBe(Expected);
        }

        [Theory]
        [InlineData(")",1)]
        [InlineData("()())",5)]
        public void TestStep2(string Instructions, int Expected)
        {
            var myElf = new Elf();
            var slask = myElf.ParseFloorInstructions(Instructions);
            myElf.EnteredBasementAt.ShouldBe(Expected);
        }
    }
}
