
using System.Text;

class Day4
{

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

    private static List<int> ValidateCards(Dictionary<IEnumerable<int>, IEnumerable<int>> cards)
    {
        List<int> scores = new List<int>();
        foreach (var card in cards)
        {
            int score = 0;
            foreach (var winningNumber in card.Key)
            {
                if (card.Value.Contains(winningNumber))
                {
                    score = score * 2;
                    if (score == 0)
                        score++;
                }
            }
            scores.Add(score);
        }
        return scores;
    }

    public static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day4\\Day4_input.txt");
        Dictionary<IEnumerable<int>, IEnumerable<int>> cards = new Dictionary<IEnumerable<int>, IEnumerable<int>>();

        foreach (var item in input)
        {
            string[] splits = item.Split(':');
            string[] numbersAsString = splits[1].Split('|');
            cards.Add(StringToListInt(numbersAsString[0]), StringToListInt(numbersAsString[1]));
        }
        
        IEnumerable<int> scores = ValidateCards(cards);
        Console.WriteLine(scores.Sum());
    }
}