using System;
using Xunit;
using Shouldly;
using AoC2017_04;

namespace AoC2017_04Tests
{
    public class Tests
    {
        [Theory]
        [InlineData("aa bb cc dd ee",true)]
        [InlineData("aa bb cc dd aa",false)]
        [InlineData("aa bb cc dd aaa",true)]
        public void Step1(string passPhrase, bool isValid)
        {
            AoC201704 myProcessor = new AoC201704();
            myProcessor.isPassPhraseValid(passPhrase).ShouldBe(isValid);

        }

        [Theory]
        [InlineData("FEDCBA","ABCDEF")]
        [InlineData("FdCBA","ABCFd")]
        [InlineData("iooii","iiioo")]
        public void Step2SortString(string before, string after)
        {
            AoC201704 myProcessor = new AoC201704();
            myProcessor.sortedString(before).ShouldBe(after);
        }

    }
}
