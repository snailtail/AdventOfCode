using System;
using Xunit;
using Shouldly;
using AdventOfCode.TwentyTwenty.Day14;
namespace AdventOfCode.TwentyTwenty.Day14tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X")]
        public void TestMask(string MaskString)
        {
            var x = new Mask(MaskString);
            x.Data.Length.ShouldBe(36);
            x.Data.ShouldBe(MaskString.ToCharArray());
        }
    }
}
