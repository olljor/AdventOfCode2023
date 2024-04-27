using Day13;

class Day13Main
{
    public static async Task Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day13\\Day13_input.txt");
        PatternHandler patternHandler = new PatternHandler();
        List<Pattern> patterns = patternHandler.SetPatterns(inputs);
        Console.WriteLine(await patternHandler.FindPatternsAsync(patterns));
    }
}