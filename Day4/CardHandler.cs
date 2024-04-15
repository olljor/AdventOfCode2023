using System.Text;

namespace Day4;

internal class CardHandler
{
    public static List<Card> Cards = new List<Card>();
    public CardHandler(IEnumerable<string> input)
    {
        foreach (var item in input)
        {
            var card = new Card();
            string[] splits = item.Split(':');
            string[] numbersAsString = splits[1].Split('|');

            card.id = ExtractDigits(splits[0]);
            card.refrenceNumbers = StringToListInt(numbersAsString[0]);
            card.winningNumbers = StringToListInt(numbersAsString[1]);
            Cards.Add(card);
        }
        ValidateCards();
    }

    private static void ValidateCards()
    {
        foreach (Card card in Cards)
        {
            for (int i = 0; i < card.copies; i++)
            {
                int wins = 0;
                foreach (var refrenceNumber in card.refrenceNumbers)
                    if (card.winningNumbers.Contains(refrenceNumber))
                        wins++;

                if (wins > 0)
                    GenerateCopies(card, wins);

                card.TotalWins += wins;
            }
        }
    }

    private static void GenerateCopies(Card card, int wins)
    {
        int indexLow = card.id;
        int indexHigh = card.id + wins - 1;
        if (indexHigh >= Cards.Count())
            indexHigh = Cards.Count() - 1;

        for (int i = indexLow; i <= indexHigh; i++)
            Cards[i].copies++;
    }

    private static List<int> StringToListInt(string line)
    {
        List<int> digits = new List<int>();

        bool digitFound = false;
        var digit = new StringBuilder();
        int counter = 0;
        foreach (char c in line)
        {
            counter++;
            if (Char.IsDigit(c))
            {
                digitFound = true;
                digit.Append(c);
            }

            if ((digitFound && !Char.IsDigit(c))
                || (digitFound && counter == line.Length))
            {
                digits.Add(Int32.Parse(digit.ToString()));
                digitFound = false;
                digit = new StringBuilder();
            }
        }
        return digits;
    }

    private static int ExtractDigits(string line)
    {
        var digit = new StringBuilder();
        foreach (char c in line)
            if (Char.IsDigit(c))
                digit.Append(c);

        return int.Parse(digit.ToString());
    }
}
