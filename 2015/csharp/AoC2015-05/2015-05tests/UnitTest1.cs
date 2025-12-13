using System;
using Xunit;
using Shouldly;
using AdventOfCode.TwentyFifteen.Day05;


namespace AdventOfCode.TwentyFifteen.Day05tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void TestVowelCount(string Thestring, bool ExpectedResult)
        {
            var myParser = new NaughtyNiceParser();
            myParser.CheckForVowels(Thestring,3).ShouldBe(ExpectedResult);
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("dvszwmarrgswjxmb", true)]
        [InlineData("jchzalrnumimnmhp", false)]
        public void TestDoubleLetters(string Thestring, bool ExpectedResult)
        {
            var myParser = new NaughtyNiceParser();
            myParser.CheckForDoubleLetters(Thestring).ShouldBe(ExpectedResult);
        }

        [Theory]
        [InlineData("haegwjzuvuyypxyu", true)]
        [InlineData("ugknbfddgicxrmoypn", false)]
        public void TestForIllegalStrings(string Thestring, bool ExpectedResult)
        {
            var myParser = new NaughtyNiceParser();
            myParser.ContainsIllegalStrings(Thestring).ShouldBe(ExpectedResult);
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("aaa",true)]
        [InlineData("jchzalrnumimnmhp", false)]
        [InlineData("haegwjzuvuyypxyu", false)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void TestIfNice(string Data, bool ExpectedResult)
        {
            var myParser = new NaughtyNiceParser();
            myParser.IsNice(Data).ShouldBe(ExpectedResult);
        }

        [Theory]
        [InlineData("qjhvhtzxzqqjkmpb",true)]
        [InlineData("xxyxx",true)]
        [InlineData("uurcxstgmygtbstg",false)]
        public void TestStep2(string TestData, bool Expected)
        {
            var myParser = new NaughtyNiceParser();
            myParser.IsNice2(TestData).ShouldBe(Expected);
        }
    }
}
