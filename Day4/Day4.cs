using Day4;

class Day4Part1
{
    private static void ValidateCards()
    {
        foreach (Card card in Day4Part2.Cards)
        {
            for (int i = 0; i < card.copies; i++)
            {
                int wins = 0;
                foreach (var refrenceNumber in card.refrenceNumbers)
                {
                    if (card.winningNumbers.Contains(refrenceNumber))
                        wins++;
                }
                if (wins > 0)
                    GenerateCopies(card, wins);
                card.TotalWins += wins;
            }
            card.TallyScores();
        }
    }

    private static void GenerateCopies(Card card, int wins)
    {
        int indexLow = card.id;
        int indexHigh = card.id + wins - 1;
        if (indexHigh >= Day4Part2.Cards.Count())
            indexHigh = Day4Part2.Cards.Count() - 1;

        for (int i = indexLow; i <= indexHigh; i++)
        {
            try
            {
                Day4Part2.Cards[i].copies++;
            }
            catch (Exception ex) { Console.WriteLine(ex); }
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
        Console.WriteLine("Part 1: " + sum);

        // Part 2
        int sdsds = 0;
        foreach (Card card in Day4Part2.Cards)
            sdsds = sdsds + card.copies;
        Console.WriteLine("Part 2: " + sdsds);
    }
}