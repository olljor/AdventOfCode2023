using Day5;
using System.Text;

internal class AlmenacHandler
{
    public static Almanaca almanaca = new Almanaca();
    public AlmenacHandler(IEnumerable<string> inputs)
    {
        string[] seedSplits = inputs.First().Split(':');
        almanaca.seeds = StringToListInt(seedSplits[1]);

        string relation;

        List<AlmanacItem> items = new List<AlmanacItem>();
        foreach (string input in inputs) 
        {
            if (input[input.Length-1] == ':')
            {
                Console.WriteLine(input);
                items = new List<AlmanacItem>();
            }
            else 
            {
                AlmanacItem item = new AlmanacItem();
                string[] splits = input.Split(' ');
                item.destination = int.Parse(splits[0]);
                item.source = int.Parse(splits[0]);
                item.destination = int.Parse(splits[0]);
                items.Add(item);
            } 
        }
    }

    private static List<int> StringToListInt(string line)
    {
        List<int> digits = new List<int>();

        bool digitFound = false;
        var digit = new StringBuilder();
        int counter = 0;
        foreach (char c in line)
        {
            counter++;
            if (Char.IsDigit(c))
            {
                digitFound = true;
                digit.Append(c);
            }

            if ((digitFound && !Char.IsDigit(c))
                || (digitFound && counter == line.Length))
            {
                digits.Add(int.Parse(digit.ToString()));
                digitFound = false;
                digit = new StringBuilder();
            }
        }
        return digits;
    }
}