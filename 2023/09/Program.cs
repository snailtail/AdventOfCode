var Lines = File.ReadLines("../data/09.dat").Where(l => !string.IsNullOrEmpty(l)).ToArray();
OASIS o = new(Lines);
Console.WriteLine(o.SumOfExtrapolatedValuesPart1);
Console.WriteLine(o.SumOfExtrapolatedValuesPart2);