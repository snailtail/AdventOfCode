
var input = File.ReadAllLines("../data/06.dat");
BoatRaceHandler brh = new(input);
int step1Wins = 1;
foreach(var r in brh.Races)
{
    step1Wins *= brh.WaysToWinRace(r);
}
int step2Wins = brh.WaysToWinRace(brh.Step2Race);
Console.WriteLine($"Step 1: {step1Wins}");
Console.WriteLine($"Step 1: {step2Wins}");