using Day4;

class Day4Part1
{
    private static void ValidateCards()
    {
        foreach (Card card in CardHandler.Cards)
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
        if (indexHigh >= CardHandler.Cards.Count())
            indexHigh = CardHandler.Cards.Count() - 1;

        for (int i = indexLow; i <= indexHigh; i++)
            CardHandler.Cards[i].copies++;
    }

    public static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day4\\Day4_input.txt");
        CardHandler.SetCards(input);
        ValidateCards();

        // Part 1
        Console.WriteLine("Part 1 answer: " + CardHandler.Cards.Sum(x => x.score));

        // Part 2
        Console.WriteLine("Part 2 answer: " + CardHandler.Cards.Sum(x => x.copies));
    }
}