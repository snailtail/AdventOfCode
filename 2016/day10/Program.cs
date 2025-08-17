using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

string filename = "testinput.txt";
string[] AllLines = File.ReadAllLines(filename);
string[] botvalues = AllLines.Where(l=> l.ToLower().StartsWith("value ")).ToArray();
string[] botinstructions = AllLines.Where(l=> l.ToLower().StartsWith("bot ")).ToArray();

// check all the output-strings and determine the amount of output bins we need to set up.
string[] outputlines = AllLines.Where(l=> l.Contains("output")).ToArray();
int highest=0;
foreach(string outputline in outputlines)
{
    MatchCollection matches = Regex.Matches(outputline,@"output\s([0-9]+)\s*");
    foreach(Match m in matches)
    {
        
        
        //Find highest value to use in Output bins.
        highest = Math.Max(highest,int.Parse(m.Groups[1].Value)+1);
        
        
    }

}

// Set up some bots and bins.
OutputBin[] OutputBins = new OutputBin[highest];
for(int n = 0; n< highest; n++)
{
    OutputBins[n]=new OutputBin();
}
Bot[] Bots = new Bot[botinstructions.Length];
// Parse the beginning of the Botinstruction to find the recipient.
foreach(string instruction in botinstructions)
{
    var instr = new Botinstruction(instruction);
    if(Bots[instr.InstructionTarget]==null)
    {
        Bots[instr.InstructionTarget] = new Bot(instr.HighIndex,instr.LowIndex,instr.HighRecipientIsBot, instr.LowRecipientIsBot,instr.InstructionTarget, Bots, OutputBins);
    }
    else
    {
        Bots[instr.InstructionTarget].HighIndex=instr.HighIndex;
        Bots[instr.InstructionTarget].LowIndex = instr.LowIndex;
        Bots[instr.InstructionTarget].HighRecipientIsBot=instr.HighRecipientIsBot;
        Bots[instr.InstructionTarget].LowRecipientIsBot = instr.LowRecipientIsBot;
        Bots[instr.InstructionTarget].BotList=Bots;
        Bots[instr.InstructionTarget].OutputBins=OutputBins;
    }
}


// Set up the bot with initial values
foreach(string botvalue in botvalues)
{
    Match botmatch = Regex.Match(botvalue,@"value ([0-9]+) goes to bot ([0-9]+)");
    int value = int.Parse(botmatch.Groups[1].Value);
    int recipientindex = int.Parse(botmatch.Groups[2].Value);
    Bots[recipientindex].AddValue(value);

}
Console.ReadLine();