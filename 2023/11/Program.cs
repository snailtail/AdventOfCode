CosmicMap cm = new("../data/11.dat");
Console.WriteLine($"Part 1: {cm.SumOfShortestPathsBetweenPairs()}");
cm = new("../data/11.dat",1_000_000);
Console.WriteLine($"Part 2: {cm.SumOfShortestPathsBetweenPairs()}");