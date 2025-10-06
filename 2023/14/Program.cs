
var pData = File.ReadAllLines("../data/14.dat");
Platform p = new(pData);
int part1=p.Part1();
Console.WriteLine($"Part 1 : {part1}");
