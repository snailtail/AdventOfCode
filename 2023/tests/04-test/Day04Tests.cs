namespace _04_test;
using Shouldly;

public class Day04Tests
{
    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 1)]
    [InlineData("Card 204: 11  9 81 75 39 52 19 96 47 66 | 37 22 70 43 51 72  7 67 50 83 90 23 24 28 57 87 86 13 27 76 94 35 40 17 91", 204)]
    public void TestCardNumber(string input, int expectedCardNumber)
    {
        ScratchCard sc = new(input);
        sc.CardNumber.ShouldBe(expectedCardNumber);
    }

    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 41, 48, 83, 86, 17 })]
    private void TestWinningNumbers(string input, int[] expectedWinningNumbers)
    {
        ScratchCard sc = new(input);
        var result = sc.WinningNumbers;
        for (int i = 0; i < result.Length; i++)
        {
            result[i].ShouldBe(expectedWinningNumbers[i]);
        }
    }

    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 83, 86, 6, 31, 17, 9, 48, 53 })]
    [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", new int[] { 61, 30, 68, 82, 17, 32, 24, 19 })]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", new int[] { 69, 82, 63, 72, 16, 21, 14, 1 })]
    [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", new int[] { 59, 84, 76, 51, 58, 5, 54, 83 })]
    [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", new int[] { 88, 30, 70, 12, 93, 22, 82, 36 })]
    [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", new int[] { 74, 77, 10, 23, 35, 67, 36, 11 })]
    private void TestLuckyNumbers(string input, int[] expectedLuckyNumbers)
    {
        ScratchCard sc = new(input);
        var result = sc.LuckyNumbers;
        for (int i = 0; i < result.Length; i++)
        {
            result[i].ShouldBe(expectedLuckyNumbers[i]);
        }
    }

    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 83, 86, 17, 48 })]
    [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", new int[] { 61, 32 })]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", new int[] { 21, 1 })]
    [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", new int[] { 84 })]
    private void TestElfsWinningNumbers(string input, int[] expectedElfsWinningNumbers)
    {
        ScratchCard sc = new(input);
        var result = sc.ElfsWinningNumbers;
        for (int i = 0; i < result.Length; i++)
        {
            result[i].ShouldBe(expectedElfsWinningNumbers[i]);
        }
    }

    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
    [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
    [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
    [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
    [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
    private void TestCardPoints(string input, int expectedPoints)
    {
        ScratchCard sc = new(input);
        sc.Points.ShouldBe(expectedPoints);
    }

    

}