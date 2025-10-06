public static class CamelCards
{
    public static Dictionary<char, int> CardValues = new(){
        {'1',1},
        {'2',2},
        {'3',3},
        {'4',4},
        {'5',5},
        {'6',6},
        {'7',7},
        {'8',8},
        {'9',9},
        {'T',10},
        {'J',11},
        {'Q',12},
        {'K',13},
        {'A',14},
        };


    public static int GetCardStackTotalWinnings(string inputFilePath, bool UseJokerCard = false)
    {
        int totalWinnings = 0;
        var fileData = File.ReadAllLines(inputFilePath);

        List<CamelCardHand> handsList = new();
        foreach (string line in fileData)
        {
            var parts = line.Split(" ");
            CamelCardHand cch = new(parts[0], int.Parse(parts[1]));
            handsList.Add(cch);
        }
        if (UseJokerCard)
        {
            foreach (CamelCardHand cch in handsList)
            {
                cch.ApplyJokerCard();
            }
        }

        List<CamelCardHand> theCards = new();
        theCards = handsList.Where(h => h.handType == CamelCardHand.HandType.HighCard).OrderBy(h => h.Weight).ToList();
        theCards.AddRange(handsList.Where(h => h.handType == CamelCardHand.HandType.OnePair).OrderBy(h => UseJokerCard ? h.WeightWithJoker : h.Weight).ToArray());
        theCards.AddRange(handsList.Where(h => h.handType == CamelCardHand.HandType.TwoPair).OrderBy(h => UseJokerCard ? h.WeightWithJoker : h.Weight).ToArray());
        theCards.AddRange(handsList.Where(h => h.handType == CamelCardHand.HandType.ThreeOfAKind).OrderBy(h => UseJokerCard ? h.WeightWithJoker : h.Weight).ToArray());
        theCards.AddRange(handsList.Where(h => h.handType == CamelCardHand.HandType.FullHouse).OrderBy(h => UseJokerCard ? h.WeightWithJoker : h.Weight).ToArray());
        theCards.AddRange(handsList.Where(h => h.handType == CamelCardHand.HandType.FourOfAKind).OrderBy(h => UseJokerCard ? h.WeightWithJoker : h.Weight).ToArray());
        theCards.AddRange(handsList.Where(h => h.handType == CamelCardHand.HandType.FiveOfAKind).OrderBy(h => UseJokerCard ? h.WeightWithJoker : h.Weight).ToArray());


        for (int i = 0; i < theCards.Count; i++)
        {
            int index = i + 1;
            int bid = theCards[i].BidAmount;
            int sum = index * bid;
            totalWinnings += sum;
        }

        return totalWinnings;
    }
}
