using System;
using Xunit;
using AoC2017_03;
using Shouldly;

namespace AoC2017_03Tests
{
    public class Tests
    {
        /*
            Data from square 1 is carried 0 steps, since it's at the access port.
            Data from square 12 is carried 3 steps, such as: down, left, left.
            Data from square 23 is carried only 2 steps: up twice.
            Data from square 1024 must be carried 31 steps
        */
        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void Test1(int input, int output)
        {
            // Prepare
            AoC201703 processor = new AoC201703();
            int result;
            result = processor.Process(input);
            result.ShouldBe(output);
        }
    }
}
