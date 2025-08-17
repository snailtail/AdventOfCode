using System;
using Xunit;
using AdventOfCode.TwentyFifteen.Day02;
using Shouldly;

namespace AdventOfCode.TwentyFifteen.Day02tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("2x3x4", new int[]{2,3,4})]
        public void Test_DimensionParser(string PackageDimensions, int[] ExpectedResult)
        {
            var myElf = new Elf();
            myElf.ParsePackageDimensions(PackageDimensions).ShouldBe(ExpectedResult);
        }
    
        [Theory]
        [InlineData("2x3x4", 58)]
        [InlineData("1x1x10", 43)]
        public void Test_WrappingCalculator(string Dimensions, int ExpectedValue)
        {
            var myElf = new Elf();
            int[] intDim = myElf.ParsePackageDimensions(Dimensions);
            myElf.CalculateWrapping(intDim).ShouldBe(ExpectedValue);
        }

        [Theory]
        [InlineData("1x1x10",14)]
        [InlineData("2x3x4",34)]
        public void Test_RibbonLength(string Dimensions, int ExpectedValue)
        {
                var myElf = new Elf();
                int[] intDim=myElf.ParsePackageDimensions(Dimensions);
                myElf.Calculate_Bow_And_Ribbon(intDim).ShouldBe(ExpectedValue);
        }
    }
}
