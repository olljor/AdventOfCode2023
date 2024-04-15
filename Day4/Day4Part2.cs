using System.Text;

namespace Day4;
public class Card
{
    public int id { get; set; }
    public IEnumerable<int> refrenceNumbers { get; set; } = Enumerable.Empty<int>();
    public IEnumerable<int> winningNumbers { get; set; } = Enumerable.Empty<int>();
    public int copies { get; set; } = 1;
    public int score { get; set; } = 0;
    public int TotalWins { get; set; } = 0;
    public void TallyScores() 
    {
        for (int i = 0; i < TotalWins / copies; i++)
        {
            score = score * 2;
            if (score == 0)
                score++;
        }
    }

}

internal class Day4Part2
{
    public static List<Card> Cards = new List<Card>();
    public static void setCards(IEnumerable<string> input)
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
