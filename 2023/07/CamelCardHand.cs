
using System.Text.RegularExpressions;

public class CamelCardHand
{
    public enum HandType
    {
        FiveOfAKind = 7,
        FourOfAKind = 6,
        FullHouse = 5,
        ThreeOfAKind = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1,
    }

    private int _bidAmount;
    private char hexValueForCard(char card, bool UseJokerCard = false)
    {
        switch (card)
        {
            case '2':
                return '2';

            case '3':
                return '3';

            case '4':
                return '4';

            case '5':
                return '5';

            case '6':
                return '6';

            case '7':
                return '7';

            case '8':
                return '8';

            case '9':
                return '9';

            case 'T':
                return 'A';

            case 'J':
                return UseJokerCard ? '1' : 'B';

            case 'Q':
                return 'C';

            case 'K':
                return 'D';

            case 'A':
                return 'E';

            default:
                return '0';
        }
    }
    public long Weight
    {
        get
        {
            string x = "";
            foreach (char c in Cards)
            {
                x += hexValueForCard(c);
            }

            long weight = Convert.ToInt64(x, 16); ;
            return weight;
        }
    }
    public long WeightWithJoker
    {
        get
        {
            string x = "";
            foreach (char c in Cards)
            {
                x += hexValueForCard(c, true);
            }

            long weight = Convert.ToInt64(x, 16); ;
            return weight;
        }
    }
    private string _sortedCards;

    private long[] _cardValues = new long[5];
    private long _handTypeWeight = 0;
    private HandType _handType;
    public HandType handType { get => _handType; }
    public string Cards;
    public long[] CardValues { get => _cardValues; }
    public string SortedCards { get => _sortedCards; }
    public int BidAmount { get => _bidAmount; set => _bidAmount = value; }
    public long HandTypeWeight { get => _handTypeWeight; }


    public CamelCardHand(string cards, int bidAmount = 0)
    {
        Cards = cards;
        for (int c = 0; c < cards.Length; c++)
        {
            _cardValues[c] = CamelCards.CardValues[cards[c]];
        }
        _sortedCards = SortCards(cards);
        _handType = CalculateHandType(_sortedCards);
        _bidAmount = bidAmount;
        _handTypeWeight = (long)_handType;
    }

    private HandType CalculateHandType(string sortedCardData, bool UseJokerCard = false)
    {
        Match match;

        string pattern = @"(\w)\1{4}"; // Five of a kind
        match = Regex.Match(sortedCardData, pattern);
        if (match.Success)
        {
            if(UseJokerCard)
            {
                // five of a kind with J - wow, let's use all A's -> should be five of a kind but with Aces.
                char newChar = 'A';
                string temp = SortCards(_sortedCards.Replace('J', newChar));
                return CalculateHandType(temp, false);
            }
            return HandType.FiveOfAKind;
        }

        pattern = @"(\w)\1{3}.*"; // Four of a kind
        match = Regex.Match(sortedCardData, pattern);
        if (match.Success)
        {
            if(UseJokerCard)
            {
                // four of a kind four or one J, J emulates the same as the other number -> should be five of a kind.
                char newChar = _sortedCards.Where(c => c != 'J').MaxBy(c => CamelCards.CardValues[c]);
                string temp = SortCards(_sortedCards.Replace('J', newChar));
                return CalculateHandType(temp, false);
            }
            return HandType.FourOfAKind;
        }

        pattern = @"((\w)\2\2(\w)\3|(\w)\4(\w)\5\5)"; // Full house
        match = Regex.Match(sortedCardData, pattern);
        if (match.Success)
        {
            if(UseJokerCard)
            {
                // full house -> no matter if three or two J, J emulates the same as the other number -> should be five of a kind.
                char newChar = _sortedCards.Where(c => c != 'J').MaxBy(c => CamelCards.CardValues[c]);
                string temp = SortCards(_sortedCards.Replace('J', newChar));
                return CalculateHandType(temp, false);
            }
            return HandType.FullHouse;
        }

        pattern = @"(\w)\1\1.*"; // Three of a kind
        match = Regex.Match(sortedCardData, pattern);
        if (match.Success)
        {
            if(UseJokerCard)
            {
                // three of a kind -> if three j, j emulates the highest card that is not J, else J emulates the same as the three cards -> Four of a kind
                char newChar;
                char triplesChar=match.Groups[1].Value[0];
                if(triplesChar=='J')
                {
                    newChar = _sortedCards.Where(c => c != 'J').MaxBy(c => CamelCards.CardValues[c]);
                }
                else
                {
                    newChar = triplesChar;
                }
                string temp = SortCards(_sortedCards.Replace('J', newChar));
                return CalculateHandType(temp, false);
            }
            return HandType.ThreeOfAKind;
        }

        pattern = @"(\w)\1.*(\w)\2.*"; // Two pair
        match = Regex.Match(sortedCardData, pattern);
        if (match.Success)
        {
            if(UseJokerCard)
            {
                // two pair -> if there are two J in this - make them the same as the other pair = 4 of a kind, else if 1 J make that one the same as the highest in one of the pairs. = full house
                char newChar;
                char pair1Char=match.Groups[1].Value[0];
                char pair2Char=match.Groups[2].Value[0];
                if(pair1Char=='J')
                {
                    newChar = pair2Char;
                }
                else if(pair2Char=='J')
                {
                    newChar = pair1Char;
                }
                else
                {
                    newChar = _sortedCards.Where(c => c != 'J').MaxBy(c => CamelCards.CardValues[c]);
                }
                string temp = SortCards(_sortedCards.Replace('J', newChar));
                return CalculateHandType(temp, false);
            }
            return HandType.TwoPair;
        }

        pattern = @"(\w)\1.*"; // One pair
        match = Regex.Match(sortedCardData, pattern);
        if (match.Success)
        {
            if (UseJokerCard)
            {
                char newchar;
                // one pair -> if j is the pair j emulates the highest card (if that is J choose the second highest). else J emulates the same card as in the pair -> should be three of a kind
                var pairChar = match.Groups[1].Value;
                if (pairChar[0] == 'J')
                {
                    newchar = _sortedCards.Where(c => c != 'J').MaxBy(c => CamelCards.CardValues[c]);

                }
                else
                {
                    newchar = pairChar[0];
                }
                string temp = SortCards(_sortedCards.Replace('J', newchar));
                return CalculateHandType(temp, false);
            }
            return HandType.OnePair;
        }

        // no mathces == high card
        if (UseJokerCard)
        {
            // highcard -> J emulates the highest card -> should become one pair
            char highest = _sortedCards.Where(c => c != 'J').MaxBy(c => CamelCards.CardValues[c]);
            // if this is J (it should not be)
            string temp = SortCards(_sortedCards.Replace('J', highest));
            return CalculateHandType(temp, false);
        }

        return HandType.HighCard;

    }

    private string SortCards(string cardsToSort)
    {
        var tempCards = cardsToSort.Select(c => c).ToArray();
        Array.Sort(tempCards);
        return new string(tempCards);
    }
    public void ApplyJokerCard()
    {
        // recalculate the type of hand, and the typeweight - but not the actual weight itself. 
        // and only if the hand actually contains a J
        if (Cards.Contains('J'))
        {
            _handType = CalculateHandType(_sortedCards, true);
            _handTypeWeight = (long)_handType;
        }
    }
}