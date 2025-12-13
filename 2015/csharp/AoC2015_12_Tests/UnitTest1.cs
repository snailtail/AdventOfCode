using Shouldly;
using AoC2015_12;

namespace AoC2015_12_Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("[1,2,3]", 6)]
        [InlineData("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
        
        public void ParseJson(string json, int expectedsum)
        {
            Solver s = new Solver();
            s.Solve(json).ShouldBe(expectedsum);
        }
    }
}