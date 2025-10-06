using Shouldly;

namespace _06_test;

public class Day06Tests
{
    string testFilePath = "../../../../../data/06test.dat";

    [Fact]
    public void Parse_Input_Should_Contain_Three_Races()
    {
        string[] input = File.ReadAllLines(testFilePath);
        BoatRaceHandler brh = new(input);
        brh.Races.Count().ShouldBe(3);
    }

    [Theory]
    [InlineData(7,9,4)]
    [InlineData(15,40,8)]
    [InlineData(30,200,9)]
    public void Test_Races_Won(int time, int distance, int expectedWays)
    {
        string[] input = File.ReadAllLines(testFilePath);
        BoatRaceHandler brh = new(input);
        BoatRace br = new(time,distance);
        brh.WaysToWinRace(br).ShouldBe(expectedWays);
        
    }
    [Fact]
    private void Test_Step2_RaceTimeAndDistance()
    {
        string[] input = File.ReadAllLines(testFilePath);
        BoatRaceHandler brh = new(input);
        brh.Step2Race.Time.ShouldBe(71530);
        brh.Step2Race.Distance.ShouldBe(940200);
    }
}
