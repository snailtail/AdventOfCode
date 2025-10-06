using Shouldly;

namespace _05_test;

public class Day05Tests
{
    [Fact]
    public void TestParsing_Seeds()
    {
        var rawinput = File.ReadAllText("../../../../../data/05test.dat");
        SeedToLocationMapper stlm = new(rawinput);
        long[] expectedSeeds = new long[]{79, 14, 55, 13};
        stlm.Seeds.ShouldBe(expectedSeeds);
    }

    [Theory]
    [InlineData(79,82)]
    [InlineData(14,43)]
    [InlineData(55,86)]
    [InlineData(13,35)]

    public void TestStep1_MapSeedToLocation(long seed, long expectedlocation)
    {
        var rawinput = File.ReadAllText("../../../../../data/05test.dat");
        SeedToLocationMapper stlm = new(rawinput);
        stlm.MapSeedToLocation(seed).ShouldBe(expectedlocation);
    }

    [Fact]
    public void TestStep1_LowestLocation()
    {
        var rawinput = File.ReadAllText("../../../../../data/05test.dat");
        SeedToLocationMapper stlm = new(rawinput);
        long expectedlocation=35;
        long minvalue = long.MaxValue;
        foreach(var s in stlm.Seeds)
        {
            minvalue = Math.Min(minvalue,stlm.MapSeedToLocation(s));
        }
        minvalue.ShouldBe(expectedlocation);
        
    }
}