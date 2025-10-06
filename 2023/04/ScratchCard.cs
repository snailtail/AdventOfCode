using System.Text.RegularExpressions;

public class ScratchCard
{
    public string cardData;
    public int CardNumber;
    public int[] WinningNumbers;
    public int[] LuckyNumbers;
    public int Copies;
    public bool Done = false;
    public int[] ElfsWinningNumbers 
    {
        get{
            return LuckyNumbers.Where(l=> WinningNumbers.Contains(l)).ToArray();
        }
    }
    public int Points  {
        get{
            if(ElfsWinningNumbers.Length > 0)
            {
                return (int)Math.Pow(2,(ElfsWinningNumbers.Count()-1));
            }
            else
            {
                return 0;
            }
        }
    }

    public ScratchCard(string CardData)
    {
        Copies=1;
        cardData=CardData;
        var chunks = CardData.Split(" | ");
        //0 = Card/ticket number and winning numbers - Split that on ": "
        //1 = Luckynumbers
        var cardInfo = chunks[0].Split(": ");
        string pattern;
        pattern = @"(\d+)";
        var cardInfoMatch = Regex.Match(cardInfo[0],pattern);
        CardNumber = int.Parse(cardInfoMatch.Groups[1].Value);
        // extract winning numbers
        WinningNumbers = cardInfo[1].Split(" ").Select(l=> l.Trim()).Where(l=> !string.IsNullOrEmpty(l)).Select(i=>int.Parse(i)).ToArray();

        //Extract Lucky Numbers (the ones that might result in winning)
        LuckyNumbers = chunks[1].Split(" ").Select(l=> l.Trim()).Where(l=> !string.IsNullOrEmpty(l)).Select(i=>int.Parse(i)).ToArray();
    }
    
}