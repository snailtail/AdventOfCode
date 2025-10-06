using Shouldly;

namespace _11_test;

public class Day11tests
{
    public const string testFilePath = "../../../../../data/11test.dat";

    [Fact]
    public void TestRowCount()
    {
        CosmicMap cm = new(testFilePath);
        cm.RowCount.ShouldBe(10);
    }

    [Fact]
    public void TestMapWidth()
    {
        CosmicMap cm = new(testFilePath);
        cm.MapWidth.ShouldBe(10);
    }

    [Fact]
    public void TestMapOutput()
    {
        string expectedMapData ="...#......\n.......#..\n#.........\n..........\n......#...\n.#........\n.........#\n..........\n.......#..\n#...#.....\n";
        CosmicMap cm = new(testFilePath);
        cm.GetPrintableMap().ShouldBe(expectedMapData);
    }

    [Theory]
    [InlineData(0,0,3)]
    [InlineData(1,1,7)]
    [InlineData(2,2,0)]
    [InlineData(3,4,6)]
    [InlineData(4,5,1)]
    [InlineData(5,6,9)]
    [InlineData(6,8,7)]
    [InlineData(7,9,0)]
    [InlineData(8,9,4)]
    private void CheckScannedGalaxieCoordinates(int GalaxyIndex, int Y, int X)
    {
        CosmicMap cm = new(testFilePath);
        
        cm.Galaxies[GalaxyIndex].Y.ShouldBe(Y);
        cm.Galaxies[GalaxyIndex].X.ShouldBe(X);
    }

    [Theory]
    [InlineData(0,6,15)]
    [InlineData(2,6,17)]
    [InlineData(7,8,5)]
    private void CheckManhattanDistances(int FromGalaxyIndex, int ToGalaxyIndex, long ExpectedDistance)
    {
        CosmicMap cm = new(testFilePath);
        var result = cm.CalculateManhattanDistance(cm.Galaxies[FromGalaxyIndex].Coordinate,cm.Galaxies[ToGalaxyIndex].Coordinate);
        result.ShouldBe(ExpectedDistance);
    }

    [Fact]
    private void TestSumBetweenGalaxyPairsPart1()
    {
        CosmicMap cm = new(testFilePath);
        cm.SumOfShortestPathsBetweenPairs().ShouldBe(374);
    }

    [Theory]
    [InlineData(10,1030)]
    [InlineData(100,8410)]
    private void TestSumBetweenGalaxyPairspart2(long multiplicator, long expectedResult)
    {
        CosmicMap cm = new(testFilePath,multiplicator);
        cm.SumOfShortestPathsBetweenPairs().ShouldBe(expectedResult);
    }
}