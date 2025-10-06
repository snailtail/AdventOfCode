var rawinput = File.ReadAllText("../data/05.dat");
SeedToLocationMapper stlm = new(rawinput);
long step1 = long.MaxValue;
if (stlm.Seeds != null)
{

    foreach (var s in stlm.Seeds)
    {
        step1 = Math.Min(step1, stlm.MapSeedToLocation(s));
    }
    Console.WriteLine($"Step 1: {step1}");


    //step 2
    List<MapperRange> Step2Ranges = new();
    for (int i = 0; i < stlm.Seeds.Length; i += 2)
    {
        var newRange = new MapperRange();
        newRange.DestinationStart = stlm.Seeds[i];
        newRange.RangeLength = stlm.Seeds[i + 1];
        Step2Ranges.Add(newRange);
    }


    bool step2Solved = false;
    long lowestLocation = 0;
    while (!step2Solved)
    {
        var testseed = stlm.MapLocationToSeed(lowestLocation);
        if (Step2Ranges.Any(sr => sr.IsWithinDefinedDestinationRange(testseed)))
        {
            step2Solved = true;
            Console.WriteLine($"Step 2: {lowestLocation}");
            break;
        }
        lowestLocation++;
    }


}


record Step2Range(long Start, long Count);