using Shouldly;

namespace _16_test;

public class Day16Tests
{
    private const string testFilePath = "../../../../../data/16test.dat";

    [Fact]
    public void TestGridSizeAfterParsing()
    {
        var mapdata = File.ReadAllLines(testFilePath);
        Map m = new(mapdata);
        m.MapWidth.ShouldBe(10);
        m.MapHeight.ShouldBe(10);
    }

    [Fact]
    public void TestPart1Loop()
    {
        var mapdata = File.ReadAllLines(testFilePath);
        Map m = new(mapdata);
        m.Run().ShouldBe(46);
    }
}