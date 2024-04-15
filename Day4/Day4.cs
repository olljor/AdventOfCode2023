using System.Text;
using Day4;

class Day4Part1
{
    private static List<int> ValidateCards()
    {
        List<int> scores = new List<int>();
        foreach (var card in Day4Part2.Cards)
        {
            int score = 0;
            foreach (var winningNumber in card.refrenceNumbers)
            {
                if (card.winningNumbers.Contains(winningNumber))
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
        Day4Part2.setCards(input);

        Console.WriteLine(ValidateCards().Sum());

        // Part 2
    }
}