
using Day7;

class Day7Main
{
    public static void Main()
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day7\\Day7_input.txt");
        new CardHandler(input);

        int total = 0;
        int counter = 1;
        foreach (var hand in CardHandler.hands)
        {
            Console.WriteLine(hand.cards);
            total = total + (hand.bid * counter);
            counter++;
        }
        Console.WriteLine("Total winning: " + total);
    }
}