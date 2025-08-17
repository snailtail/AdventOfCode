using System.Text.RegularExpressions;

public class Botinstruction
{
    private readonly string _instruction;
    public int InstructionTarget; //which bot (index) is supposed to apply these rules?
    public int HighIndex;
    public int LowIndex;
    public bool HighRecipientIsBot; // set to true if the recipient is a bot, else it will be an output bin
    public bool LowRecipientIsBot; // set to true if the recipient is a bot, else it will be an output bin


    public Botinstruction(string Instruction)
    {
        _instruction = Instruction;
        ParseInstruction();

    }

    private void ParseInstruction()
    {
        string lowpattern = @" gives low to (\w+)\s([0-9]+)";
        string highpattern = @"and high to (\w+)\s([0-9]+)";
        string botIDpattern = @"^bot\s([0-9]+)";
        Match lowMatch = Regex.Match(_instruction,lowpattern);
        Match highMatch = Regex.Match(_instruction,highpattern);
        Match botID = Regex.Match(_instruction,botIDpattern);

        if(lowMatch.Groups[1].Value=="bot")
        {
            LowRecipientIsBot=true;
        }
        else
        {
            LowRecipientIsBot=false;
        }
        LowIndex = int.Parse(lowMatch.Groups[2].Value);

        if(highMatch.Groups[1].Value=="bot")
        {
            HighRecipientIsBot=true;
        }
        else
        {
            HighRecipientIsBot=false;
        }
        HighIndex = int.Parse(highMatch.Groups[2].Value);

        InstructionTarget = int.Parse(botID.Groups[1].Value);


    }

}