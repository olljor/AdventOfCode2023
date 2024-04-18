using System.Text;

namespace Day7;

class Hand
{
    public string cards { get; set; }
    public int[] cardValues { get; set; }
    public int type { get; set; }
    public int bid { get; set; }
}

internal class CardHandler
{
    public static List<Hand> hands = new List<Hand>();

    public CardHandler(IEnumerable<string> input)
    {
        foreach (string inputItem in input)
        {
            Hand hand = new Hand();
            string[] splits = inputItem.Split(' ');
            hand.cards = splits[0];
            hand.bid = ExtractDigits(splits[1]);
            hand.type = GetType(hand.cards);
            hand.cardValues = GetCardValues(hand.cards);
            hands.Add(hand);
        }
        hands = SortHands();
    }

    private List<Hand> SortHands()
    {
        var sortedHands = hands.OrderBy(hand => hand.type)
            .ThenBy(hand => string.Join(",", hand.cardValues)); // I need to thank chat-gpt for this row

        return sortedHands.ToList();
    }

    private static int GetType(string cards)
    {
        var sortedCharCount = from c in CountCharacters(cards)
                              orderby c.Value
                              descending
                              select c;

        switch (sortedCharCount.First().Value)
        {
            case 5:
                return 1; // Five of a kind

            case 4:
                return 2; // Four of a kind

            case 3:
                if (sortedCharCount.Last().Value == 2)
                    return 3; // Full house
                else
                    return 4; // Three of a kind

            case 2:
                if (sortedCharCount.Count() == 3)
                    return 5; // Two pair
                else
                    return 6; // One pair

            default:
                return 7; // High card
        }
    }

    private static Dictionary<char, int> CountCharacters(string inputString)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        foreach (char c in inputString)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }
        return charCount;
    }

    private int[] GetCardValues(string cards)
    {
        string[] cardRankings = { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };
        List<int> values = new List<int>();
        foreach (char card in cards)
        {
            int cardValues = Array.IndexOf(cardRankings, card.ToString());
            values.Add(cardValues);
        }
        return values.ToArray();
    }

    private static int ExtractDigits(string s)
    {
        var digit = new StringBuilder();
        foreach (char c in s)
        {
            if (Char.IsDigit(c))
            {
                digit.Append(c);
            }
        }
        return int.Parse(digit.ToString());
    }
}
