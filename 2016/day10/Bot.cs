using System.Diagnostics;

public class Bot
{
    public int HighIndex;
    public int LowIndex;
    public bool HighRecipientIsBot; // set to true if the recipient is a bot, else it will be an output bin
    public bool LowRecipientIsBot; // set to true if the recipient is a bot, else it will be an output bin

    public Bot[] BotList;
    public OutputBin[] OutputBins;

    private readonly int _id;
    Queue<int> Values = new();
    public Bot(int highindex, int lowindex, bool highrecipientisbot, bool lowrecipientisbot, int ID, Bot[] botlist, OutputBin[] bins)
    {
        BotList = botlist;
        OutputBins=bins;
        HighIndex=highindex;
        LowIndex=lowindex;
        HighRecipientIsBot=highrecipientisbot;
        LowRecipientIsBot=lowrecipientisbot;
        _id = ID;
    }

    public void AddValue(int value)
    {
        if (Values.Count > 1)
        {
            throw new System.ArgumentException("Can't add value to bot {_id}, it already has 2 for some reason...");
        }
        Values.Enqueue(value);
        if (Values.Count == 2)
        {
            ProcessInstruction();
        }
    }

    private bool ProcessInstruction()
    {
        int v1 = Values.Dequeue();
        int v2 = Values.Dequeue();
        int high = Math.Max(v1,v2);
        int low = Math.Min(v1,v2);
        if(HighRecipientIsBot)
        {
            BotList[HighIndex].AddValue(high);
        }
        else
        {
            OutputBins[HighIndex].AddValue(high);
        }

        if(LowRecipientIsBot)
        {
            BotList[LowIndex].AddValue(low);
        }
        else
        {
            OutputBins[LowIndex].AddValue(low);
        }

        return true;
    }
}