namespace _03_test;
using Shouldly;

public class UnitTest1
{
    string testFilePath = "../../../../../data/03test.dat";

    [Fact]
    public void TestAllNumbersImportedFromRealData()
    {
        var schematicData = File.ReadAllLines(testFilePath);
        EngineSchematicResolver esr = new(schematicData);
        esr.allNumbers[0].Value.ShouldBe(467);
        esr.allNumbers[1].Value.ShouldBe(114);
        esr.allNumbers[2].Value.ShouldBe(35);
        esr.allNumbers[3].Value.ShouldBe(633);
        esr.allNumbers[4].Value.ShouldBe(617);
        esr.allNumbers[5].Value.ShouldBe(58);
        esr.allNumbers[6].Value.ShouldBe(592);
        esr.allNumbers[7].Value.ShouldBe(755);
        esr.allNumbers[8].Value.ShouldBe(664);
        esr.allNumbers[9].Value.ShouldBe(598);
    }
    [Fact]
    public void Step1TestAdjacency()
    {
        var schematicData = File.ReadAllLines(testFilePath);
        EngineSchematicResolver esr = new(schematicData);
        esr.hasAdjacentSymbols(esr.allNumbers[0]).ShouldBe(true);
        esr.hasAdjacentSymbols(esr.allNumbers[1]).ShouldBe(false);
        esr.hasAdjacentSymbols(esr.allNumbers[2]).ShouldBe(true);
        esr.hasAdjacentSymbols(esr.allNumbers[3]).ShouldBe(true);
        esr.hasAdjacentSymbols(esr.allNumbers[4]).ShouldBe(true);
        esr.hasAdjacentSymbols(esr.allNumbers[5]).ShouldBe(false);
        esr.hasAdjacentSymbols(esr.allNumbers[6]).ShouldBe(true);

    }

    [Fact]
    public void Step1TestSumOfParts()
    {
        int expectedResult = 4361;
        var schematicData = File.ReadAllLines(testFilePath);
        EngineSchematicResolver esr = new(schematicData);
        esr.PartNumberSum.ShouldBe(expectedResult);
    }

    [Fact]
    public void Step2TestGearRatio()
    {
        int expectedResult = 467835;
        var schematicData = File.ReadAllLines(testFilePath);
        EngineSchematicResolver esr = new(schematicData);
        esr.GearRatioSum.ShouldBe(expectedResult);
    }
}