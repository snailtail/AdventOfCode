namespace _14_test;
using Shouldly;

public class Day14Tests
{
    private const string testFilePath = "../../../../../data/14test.dat";
    [Theory]
    [InlineData(0,0,'O')]
    [InlineData(1,4,'#')]
    [InlineData(9,9,'.')]
    public void TestCoordinatesAfterInitialPlatformLoad(int Y, int X, char expectedChar)
    {
        var pData = File.ReadAllLines(testFilePath);
        Platform p = new(pData);
        p.Coordinates[Y,X].ShouldBe(expectedChar);
    }


    [Theory]
    [InlineData(0,0,'O')]
    [InlineData(0,1,'O')]
    [InlineData(0,2,'O')]
    [InlineData(0,3,'O')]
    public void TestCoordinatesAfterTiltNorth(int Y, int X, char expectedChar)
    {
        var pData = File.ReadAllLines(testFilePath);
        Platform p = new(pData);
        p.TiltNorth();
        p.Coordinates[Y,X].ShouldBe(expectedChar);
    }

[Fact]
    public void TestNorthSupportBeamLoadPart1()
    {
        var pData = File.ReadAllLines(testFilePath);
        Platform p = new(pData);
        p.TiltNorth();
        p.GetNorthSupportBeamsLoad().ShouldBe(136);
    }
}