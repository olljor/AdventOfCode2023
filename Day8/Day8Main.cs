
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
        string[] startNodes = GetStartNodes('A');
        foreach (string node in startNodes)
        {
            Console.WriteLine(node);
        }
        Console.WriteLine(TraverseMaps(startNodes, 'Z', 0));
    }

    private static string[] GetStartNodes(char startNodeChar)
    {
        List<string> nodes = new List<string>();
        foreach (var item in maps)
        {
            if (item.Key.Last() == startNodeChar)
            {
                nodes.Add(item.Key);
            }
        }
        return nodes.ToArray();
    }

    private static long TraverseMaps(string[] currentNode, char end, long steps)
    {
        while (true)
        {
            for (int i = 0; i < currentNode.Length; i++)
            {
                foreach (char c in directions)
                {
                    bool allEnd = true;
                    foreach (string node in currentNode)
                    {
                        if (node.Last() != end)
                        {
                            allEnd = false;
                            break;
                        }
                    }
                    if (allEnd)
                        return steps;

                    int direction = 0;
                    if (c == 'L')
                        direction = 0;
                    else if (c == 'R')
                        direction = 1;

                    var temp = from map in maps
                               where map.Key == currentNode[i]
                               select map.Value[direction];

                    currentNode[i] = temp.First();
                    steps++;
                }
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
            if (char.IsLetter(c) || char.IsDigit(c))
            {
                cleanNode.Append(c);
            }
        }
        return cleanNode.ToString();
    }
}