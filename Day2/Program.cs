using System.Text;

class Day2
{
    private static IDictionary<int, IEnumerable<string>> ValidGames(IDictionary<string, int> rules, IDictionary<int, IEnumerable<string>> games) 
    {
        foreach (var game in games)
        {
            foreach (string set in game.Value)
            {
                if (set.Contains("red"))
                {
                    int index = set.IndexOf("red");
                    var digit = new StringBuilder();
                    digit.Append(set[index - 3]);
                    digit.Append(set[index - 2]);
                    string numberOfGreen = digit.ToString();

                    if (Int32.Parse(digit.ToString()) > rules["red"])
                    {
                        Console.WriteLine("Removed index " + game.Key);
                        games.Remove(game.Key);
                        break;
                    }
                }

                if (set.Contains("green"))
                {
                    int index = set.IndexOf("green");
                    var digit = new StringBuilder();
                    digit.Append(set[index - 3]);
                    digit.Append(set[index - 2]);
                    string numberOfGreen = digit.ToString();

                    if (Int32.Parse(digit.ToString()) > rules["green"])
                    {
                        Console.WriteLine("Removed index " + game.Key);
                        games.Remove(game.Key);
                        break;
                    }
                }

                if (set.Contains("blue"))
                {
                    int index = set.IndexOf("blue");
                    var digit = new StringBuilder();
                    digit.Append(set[index - 3]);
                    digit.Append(set[index - 2]);
                    string numberOfGreen = digit.ToString();

                    if (Int32.Parse(digit.ToString()) > rules["blue"])
                    {
                        Console.WriteLine("Removed index " + game.Key);
                        games.Remove(game.Key);
                        break;
                    }
                }
            }
        }
        return games;
    }

    private static IDictionary<int, IEnumerable<string>> SplitGames(IEnumerable<string> inputs) 
    {
        IDictionary<int, IEnumerable<string>> games = new Dictionary<int, IEnumerable<string>>();
        foreach (string input in inputs)
        {
            string[] gameSplit = input.Split(":");
            var digit = new StringBuilder();
            foreach (char c in gameSplit[0])
                if (Char.IsDigit(c))
                    digit.Append(c);
            
            int id = Int32.Parse(digit.ToString());
            string[] setSplit = gameSplit[1].Split(";");
            games.Add(id, setSplit);
        }
        return games;
    }

    public static void Main(string[] args)
    {
        IDictionary<string, int> rules = new Dictionary<string, int>();
        rules.Add("red", 12);
        rules.Add("green", 13);
        rules.Add("blue", 14);

        IDictionary<int, IEnumerable<string>> games = SplitGames(File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day2\\Day2_inputs.txt"));
        games = ValidGames(rules, games);

        Console.WriteLine("Answer: " + games.Keys.Sum());
    }
}