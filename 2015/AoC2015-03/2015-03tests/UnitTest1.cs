using System;
using Xunit;
using Shouldly;
using AdventOfCode.TwentyFifteen.Day03;

namespace AdventOfCode.TwentyFifteen.Day03tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData('>',"1:0")]
        [InlineData('<',"-1:0")]
        [InlineData('^',"0:1")]
        [InlineData('v',"0:-1")]
        public void TestParseChar(char Move, string ExpectedCoordinate)
        {
            var myParser = new DirectionParser();
            myParser.Move(Move).ShouldBe(ExpectedCoordinate);
        }

        [Theory]
        [InlineData(">>","2:0")]
        [InlineData("><><","0:0")]
        [InlineData("^>v<","0:0")]
        [InlineData(">>v","2:-1")]
        public void TestManyMoves(string Moves, string ExpectedCoordinate)
        {
            var myParser = new DirectionParser();
            string Coord = String.Empty;
            foreach(char x in Moves)
            {
                Coord = myParser.Move(x);
            }
            Coord.ShouldBe(ExpectedCoordinate);
            
        }

        [Theory]
        [InlineData(">>",2)]
        [InlineData("><><",2)]
        [InlineData("^>v<",4)]
        [InlineData(">>v",3)]
        [InlineData("^v^v^v^v^v",2)]
        public void TestNumberOfHousesVisited(string Moves, int NumberofHouses)
        {
            var myParser = new DirectionParser();
            string Coord = String.Empty;
            foreach(char x in Moves)
            {
                Coord = myParser.Move(x);
            }
            myParser.CoordinateVisits.Count.ShouldBe(NumberofHouses);
            
        }

        [Theory]
        [InlineData("^v^v^v^v^v",11)]
        public void TestNextYear(string Moves, int NumberOfHouses)
        {
            bool Robo = false;
            var NextYearParser = new DirectionParserNextYear();
            foreach (char x in Moves)
            {
                var debug = NextYearParser.Move(x, Robo);
                if (Robo == false)
                {
                    Robo = true;
                }
                else
                {
                    Robo = false;
                }
            }
            NextYearParser.CoordinateVisits.Count.ShouldBe(NumberOfHouses);
        }
    }
}
