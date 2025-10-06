namespace _02_test;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;
public class UnitTest1
{
    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
    public void TestRGBInputs(string input, bool expectedResult)
    {
        int red = 12;
        int green = 13;
        int blue = 14;
        CubeConumdrumGame ccg = new();
        ccg.TestGame(input, red, green, blue);
        ccg.ValidGame.ShouldBe(expectedResult);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 3)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 4)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5)]
    public void TestGameIDs(string input, int expectedGameID)
    {
        CubeConumdrumGame ccg = new();
        ccg.TestGame(input, 0, 0, 0);
        ccg.GameID.ShouldBe(expectedGameID);
    }

    [Fact]
    public void Step1WithTestInput()
    {
        int sumOfGameIDs = 0;
        int expectedSum = 8;
        int red = 12;
        int green = 13;
        int blue = 14;
        var lines = File.ReadAllLines("../../../../../data/02test.dat");
        foreach (var l in lines)
        {
            CubeConumdrumGame ccg = new();
            ccg.TestGame(l, red, green, blue);
            sumOfGameIDs += ccg.ValidGame == true ? ccg.GameID : 0;
        }
        sumOfGameIDs.ShouldBe(expectedSum);

    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
    public void TestStep2MinAmountOfCubes(string input, int expectedPowerSum)
    {
        CubeConumdrumGame ccg = new();
        ccg.TestGame(input, 0, 0, 0);
        ccg.CubePower.ShouldBe(expectedPowerSum);
    }

    [Fact]
    public void Step2WithTestInput()
    {
        long sumOfCubePowers = 0;
        long expectedSum = 2286;
        int red = 12;
        int green = 13;
        int blue = 14;
        var lines = File.ReadAllLines("../../../../../data/02test.dat");
        foreach (var l in lines)
        {
            CubeConumdrumGame ccg = new();
            ccg.TestGame(l, red, green, blue);
            sumOfCubePowers += ccg.CubePower;
        }
        sumOfCubePowers.ShouldBe(expectedSum);

    }

}