using System;
using Xunit;
using AoC2017_07;
using Shouldly;

namespace AoC2017_07Tests
{
    public class Tests
    {
        
        [Theory]
        [InlineData(new string[] { "pbga (66)", "xhth (57)", "ebii (61)", "havc (66)", "ktlj (57)", "fwft (72) -> ktlj, cntj, xhth", "qoyq (66)", "padx (45) -> pbga, havc, qoyq", "tknk (41) -> ugml, padx, fwft", "jptl (61)", "ugml (68) -> gyxo, ebii, jptl", "gyxo (61)", "cntj (57)" }, "tknk")]
        public void Step1(string[] input, string expected)
        {
            AoC201707 myProcessor = new AoC201707();
            var result = myProcessor.getBottomProgram(input);
            result.ShouldBe(expected);
        }
    }
}
