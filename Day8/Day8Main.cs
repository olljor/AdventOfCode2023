
using System.Text;

class Day8Main
{
    private static Dictionary<string, string[]> maps = new Dictionary<string, string[]>();
    private static string directions = string.Empty;
    public static void Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day8\\Day8_input.txt");
        directions = inputs.First();
        setMaps(inputs);

        Console.WriteLine(TraverseMaps("AAA", "ZZZ", 0));
        var temp = from map in maps
                   where map.Key == "HJD"
                   select map;
        Console.WriteLine(temp.First().Value[0]);
    }

    private static int TraverseMaps(string currentNode, string endNode, int steps)
    {
        while (true)
        {
            foreach (char c in directions)
            {
                if (currentNode == endNode)
                {
                    return steps;
                }

                steps++;
                int direction = 0;
                if (c == 'L')
                    direction = 0;
                else if (c == 'R')
                    direction = 1;

                var temp = from map in maps
                           where map.Key == currentNode
                           select map.Value[direction];

                currentNode = temp.First();
            }
        }
    }

    private static void setMaps(IEnumerable<string> inputs)
    {
        foreach (string input in inputs)
        {
            if (string.IsNullOrEmpty(input) || input == directions)
            {
                continue;
            }

            string[] values = input.Split(' ');
            string[] strings = { getNodes(values[2]), getNodes(values[3]) };
            maps.Add(getNodes(values[0]), strings);
        }
    }
    private static string getNodes(string node)
    {
        var cleanNode = new StringBuilder();

        foreach (char c in node)
        {
            if (char.IsLetter(c))
            {
                cleanNode.Append(c);
            }
        }
        return cleanNode.ToString();
    }
}