// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using System.Xml.Schema;

public class CubeConumdrumGame
{
    public int GameID;
    public int MaxRed;
    public int MaxGreen;
    public int MaxBlue;

    public bool ValidGame;

    public int CubePower => MaxRed * MaxGreen * MaxBlue;


    public void TestGame(string input, int red, int green, int blue)
    {
        var gameData = parseInput(input);
        this.ValidGame = true;
        foreach (var g in gameData)
        {
            var cc = new CubeCollection(g);

            // Store the max amount of cubes for each color.
            MaxRed = Math.Max(cc.Red, MaxRed);
            MaxGreen = Math.Max(cc.Green, MaxGreen);
            MaxBlue = Math.Max(cc.Blue, MaxBlue);

            //check if this collection breaks the rules for step 1
            if (cc.Red > red || cc.Blue > blue || cc.Green > green)
                this.ValidGame = false;
        }

    }

    string[] parseInput(string inputstring)
    {
        var x = inputstring.Split(":");
        //Extract Game ID:
        string pattern = @"Game\s(\d+)";
        var Match = Regex.Match(x[0], pattern);
        if (Match.Success)
        {
            this.GameID = int.Parse(Match.Groups[1].Value);
        }

        //Extract and return the "hands" of cubes for this game.
        var y = x[1].Split(";");
        return y;
    }
}

public class CubeCollection
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    private string GameData;

    public CubeCollection(string gamedata)
    {
        this.GameData = gamedata;
        string pattern = @"(\d+)\s(blue|red|green)";
        var Matches = Regex.Matches(this.GameData, pattern);
        foreach (Match m in Matches)
        {
            string amount = m.Groups[1].Value;
            string color = m.Groups[2].Value;
            switch (color)
            {
                case "red":
                    this.Red = int.Parse(amount);
                    break;
                case "green":
                    this.Green = int.Parse(amount);
                    break;
                case "blue":
                    this.Blue = int.Parse(amount);
                    break;
                default:
                    break;
            }
        }
    }




}