using Shouldly;
using AoC2015_11;
namespace UnitTests
{
    public class UnitTest1
    {


        [Theory]
        [InlineData("abcdefgh", "abcdffaa")]
        [InlineData("ghijklmn", "ghjaabcc")]
        public void SolveStep1(string password, string expectedResult)
        {
            Solver s = new Solver();
            var result = s.Solve(password);
            result.ShouldBe(expectedResult);
        }




        [Theory]
        [InlineData('c',new char[] {'b','c','d'})]
        [InlineData('a',null)]
        [InlineData('z',null)]
        [InlineData('y', new char[] { 'x', 'y', 'z' })]
        public void TestCharNeighbors(char input, char[]? expected)
        {
            Solver s = new();
            var result = s.findCharNeighbors(input);
            if(expected ==null)
            {
                result.ShouldBeNull();
            }
            else
            {
                result.ShouldBe(expected);
            }
        }


        [Theory]
        [InlineData("xx","xy")]
        [InlineData("xy","xz")]
        [InlineData("xz","ya")]
        [InlineData("ya","yb")]
        [InlineData("abcdefgh","abcdefgi")]
        [InlineData("abcdefzz","abcdegaa")]
        public void TestIncrement(string from, string to)
        {
            /*
             * 
             * Incrementing is just like counting with numbers: xx, xy, xz, ya, yb, and so on. 
             * Increase the rightmost letter one step; if it was z, it wraps around to a, 
             * and repeat with the next letter to the left until one doesn't wrap around.
             * 
             */
            Solver s = new Solver();
            var result = s.IncrementPassword(from);
            result.ShouldBe(to);
            


        }
        [Theory]
        [InlineData("hijklmmn",false)]
        [InlineData("abbceffg", false)]
        [InlineData("abbcegjk", false)]
        [InlineData("abcdffaa", true)]
        [InlineData("ghjaabcc", true)]
        [InlineData("ghjaaabb", false)]
        [InlineData("ghjaabaa", false)]
        [InlineData("ghjaabba", false)]
        public void CheckIfValidPassword(string password, bool expectedResult)
        {
            Solver s = new();
            var result = s.CheckIfValidPassword(password);
            result.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData("hijklmmn",true)]
        [InlineData("abbceffg", false)]
        public void CheckIfHasIncreasingThree(string password, bool expectedResult)
        {
            Solver s = new Solver();
            bool result = s.HasIncreasingThree(password);
            result.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData("abbceffg", true)]
        [InlineData("abbcegjk", false)]
        [InlineData("ghjaabaa", false)]
        public void CheckIfHasOverlappingPairs(string password, bool expectedResult)
        {
            Solver s = new Solver();
            bool result = s.HasNonOverlappingPairs(password);
            result.ShouldBe(expectedResult);
        }
    }
}