var lines = File.ReadLines("../data/02.dat");
int sumOfGameIDs = 0;
long sumOfCubePowers = 0;
int red = 12;
int green = 13;
int blue = 14;
foreach (var l in lines)
{
    CubeConumdrumGame ccg = new();
    ccg.TestGame(l, red, green, blue);
    sumOfGameIDs += ccg.ValidGame == true ? ccg.GameID : 0;
    sumOfCubePowers+=ccg.CubePower;
}
Console.WriteLine("Advent of Code 2023 Day 2:");
Console.WriteLine($"Step 1: {sumOfGameIDs}");
Console.WriteLine($"Step 2: {sumOfCubePowers}");