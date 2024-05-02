

using Day15;

class Day15main
{
    public static void Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day15\\Day15_input.txt");

        Console.WriteLine(inputs.First());
        SequenceHandler sequenceHandler = new SequenceHandler();
        List<string> sequence = sequenceHandler.SetUpSequence(inputs);

        Console.WriteLine(sequence.Count);
    }
}