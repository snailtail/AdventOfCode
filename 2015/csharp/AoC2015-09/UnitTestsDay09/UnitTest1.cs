using day09;
using Shouldly;

namespace UnitTestsDay09
{
    public class UnitTest1
    {
        [Fact]
        public void Testinput()
        {
            var input = @"London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141".Split('\n');
            int expectedDistance = 605;

            Solver s = new Solver();
            s.Solve(input).ShouldBe(expectedDistance);
        }
    }
}