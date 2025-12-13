using System;
using Xunit;
using Shouldly;
using AdventOfCode.TwentyFifteen.Day04;


namespace AdventOfCode.TwentyFifteen.Day04tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("abcdef",609043)]
        [InlineData("pqrstuv",1048970)]
        public void TestHashGenerator(string Key, long ExpectedNumber)
        {
            var myHashFinder = new MD5HashFinder();
            myHashFinder.FindNumberForKey(Key).ShouldBe(ExpectedNumber);
        }
    }
}
