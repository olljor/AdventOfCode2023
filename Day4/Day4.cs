using Day4;

class Day4Main
{
    public static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day4\\Day4_input.txt");
        new CardHandler(input);

        // Part 1
        Console.WriteLine("Part 1 answer: " + CardHandler.Cards.Sum(x => x.score));

        // Part 2
        Console.WriteLine("Part 2 answer: " + CardHandler.Cards.Sum(x => x.copies));
    }
}