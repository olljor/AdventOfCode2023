using System.Text;

class Day9Main
{
    private static List<List<long>> innitalPatterns = new List<List<long>>();
    private static List<List<long>> modifiedPatterns = new List<List<long>>();
    public static async Task Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day9\\Day9_input.txt");

        foreach (string input in inputs)
        {
            innitalPatterns.Add(StringToListInt(input));
        }

        //await Task.Run(() => Parallel.ForEach(innitalPatterns, n => Worker(n)));

        foreach (var pattern in innitalPatterns) 
        {
            Worker(pattern);
        }

        List<long> extrapolatedValues = new List<long>();
        foreach (var item in modifiedPatterns)
        {
            extrapolatedValues.Add(item.Last());
        }
        Console.WriteLine(extrapolatedValues.Sum());
    }

    private static async Task Worker(List<long> pattern)
    {
        List<List<long>> diffrences = new List<List<long>>();
        diffrences.Add(pattern);
        while (diffrences.Last().Sum() != 0)
        {
            List<long> diffrence = new List<long>();
            for (int i = 1; i < diffrences.Last().Count(); i++)
            {
                diffrence.Add(diffrences.Last()[i] - diffrences.Last()[i - 1]);
            }
            diffrences.Add(diffrence);
        }

        for (int i = diffrences.Count - 2; i >= 0; i--)
        {
            diffrences[i].Add(diffrences[i].Last() + diffrences[i + 1].Last());
        }

        foreach (var i in diffrences)
        {
            foreach (int j in i)
                Console.Write(j + " ");
            Console.WriteLine();
        }

        modifiedPatterns.Add(diffrences.First());
    }

    private static List<long> StringToListInt(string line)
    {
        List<long> digits = new List<long>();

        bool digitFound = false;
        var digit = new StringBuilder();
        int counter = 0;
        foreach (char c in line)
        {
            counter++;
            if (char.IsDigit(c) || c == '-')
            {
                digitFound = true;
                digit.Append(c);
            }

            if ((digitFound && !(char.IsDigit(c) || c == '-'))
                || (digitFound && counter == line.Length))
            {
                digits.Add(long.Parse(digit.ToString()));
                digitFound = false;
                digit = new StringBuilder();
            }
        }
        return digits;
    }
}