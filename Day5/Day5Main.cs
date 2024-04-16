using Day5;

class Day5Main
{
    public static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day5\\Day5_input.txt");
        new AlmenacHandler(input);
    }
}