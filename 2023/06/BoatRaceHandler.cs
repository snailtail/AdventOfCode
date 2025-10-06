// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

public class BoatRaceHandler
{
    private List<BoatRace> races = new();
    private BoatRace step2Race;

    public BoatRaceHandler(string[] input)
    {
        string pattern = @"(\d+)";
        var TimeMatches = Regex.Matches(input[0], pattern);
        var DistanceMatches = Regex.Matches(input[1], pattern);
        string Step2RaceTime = "";
        string Step2RaceDistance = "";
        for (int i = 0; i < TimeMatches.Count; i++)
        {
            int time = int.Parse(TimeMatches[i].Groups[1].Value);
            Step2RaceTime += TimeMatches[i].Groups[1].Value;
            int distance = int.Parse(DistanceMatches[i].Groups[1].Value);
            Step2RaceDistance += DistanceMatches[i].Groups[1].Value;
            races.Add(new BoatRace(time, distance));
        }
        step2Race = new(long.Parse(Step2RaceTime), long.Parse(Step2RaceDistance));
    }

    public BoatRace Step2Race { get => step2Race;}
    public List<BoatRace> Races { get => races;}

    public int WaysToWinRace(BoatRace race)
    {
        long time = race.Time;
        long distance = race.Distance;
        int testTime = 0;
        int wins = 0;
        while (testTime <= time)
        {
            var testDistance = testTime * (time - testTime);
            if (testDistance > distance)
            {
                wins++;
            }
            testTime++;
        }
        return wins;
    }

}