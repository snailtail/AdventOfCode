using Shouldly;


public class Day21Tests
{
    private const string testFilePath = "../../../../../data/21test.dat";
    
    [Fact]
    public void TestParsingOfMapInput_Width_and_Length()
    {
        var mapData = File.ReadAllLines(testFilePath);
        Map m = new(mapData);
        m.Width.ShouldBe(11);
        m.Height.ShouldBe(11);
    }

    [Fact]
    public void TestSCoordinatePosition()
    {
        var mapData = File.ReadAllLines(testFilePath);
        Map m = new(mapData);
        Coordinate expected = new Coordinate(5,5);
        m.sPosition.Y.ShouldBe(expected.Y);
        m.sPosition.X.ShouldBe(expected.X);
    }

    [Fact]
    public void TestPart1Score()
    {
        var mapData = File.ReadAllLines(testFilePath);
        Map m = new(mapData);
        
        m.Part1(6).ShouldBe(16);
    }
}