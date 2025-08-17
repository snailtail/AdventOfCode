using Xunit;
using Shouldly;
using AdventOfCode.Y2021;
using AdventOfCode.Helpers;

namespace day01tests;


public class Day01Tests
{
    [Fact]
    public void Test1()
    {

        Day01.Step1().ShouldBe(-1);

    }
}