using Shouldly;

namespace _09_test;

public class Day09Tests
{
    const string testFilePath = "../../../../../data/09test.dat";
    [Fact]
    private void TestCreateOASIS()
    {
        var Lines = File.ReadLines(testFilePath).Where(l=> !string.IsNullOrEmpty(l)).ToArray();
        OASIS o = new(Lines);
        o.ShouldNotBeNull();
        o.HistoryReadings.Count().ShouldBe(3);
    }

    [Theory]
    [InlineData(0,new int[]{3,3,3,3,3})]
    [InlineData(1,new int[]{2,3,4,5,6})]
    [InlineData(2,new int[]{3,3,5,9,15})]
    private void TestExtrapolateNextRow(int historyIndex, int[] expectedNextRow)
    {
        var Lines = File.ReadLines(testFilePath).Where(l=> !string.IsNullOrEmpty(l)).ToArray();
        OASIS o = new(Lines);
        o.ShouldNotBeNull();
        int[] nextRow = o.extrapolateNextRow(o.HistoryReadings[historyIndex]);
        for(int i=0;i<nextRow.Length;i++)
        {
            nextRow[i].ShouldBe(expectedNextRow[i]);
        }
    }

    [Theory]
    [InlineData(new string[]{"0 3 6 9 12 15"},18)]
    [InlineData(new string[]{"1 3 6 10 15 21"},28)]
    [InlineData(new string[]{"10 13 16 21 30 45"},68)]
    private void TestExtrapolateNextValue(string[] input, int expectedNextValue)
    {
        OASIS o = new(input);
        o.extrapolateNextValue(o.HistoryReadings[0]).ShouldBe(expectedNextValue);
    }

    [Fact]
    private void TestSumOfExtrapolatedValuesPart1()
    {
        var Lines = File.ReadLines(testFilePath).Where(l=> !string.IsNullOrEmpty(l)).ToArray();
        OASIS o = new(Lines);
        o.SumOfExtrapolatedValuesPart1.ShouldBe(114);
    }

    [Fact]
    private void TestSumOfExtrapolatedValuesPart2()
    {
        var Lines = File.ReadLines(testFilePath).Where(l=> !string.IsNullOrEmpty(l)).ToArray();
        OASIS o = new(Lines);
        o.SumOfExtrapolatedValuesPart2.ShouldBe(2);
    }
}