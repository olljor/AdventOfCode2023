using System.Diagnostics.CodeAnalysis;
using System.Text;
using Day4;

class Day4Part1
{
    private static void ValidateCards()
    {
        foreach (var card in Day4Part2.Cards)
        {
            foreach (var refrenceNumber in card.refrenceNumbers)
            {
                if (card.winningNumbers.Contains(refrenceNumber))
                {
                    card.score = card.score * 2;
                    if (card.score == 0)
                        card.score++;
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day4\\Day4_input.txt");
        Day4Part2.setCards(input);
        ValidateCards();

        // Part 1
        int sum = 0;
        foreach (Card card in Day4Part2.Cards)
            sum = sum + card.score;
        Console.WriteLine(sum);

        // Part 2

    }
}