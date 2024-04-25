using Day10;
class Day10Main
{
    public static char[,] traversedMap = new char[0, 0];

    public static void Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day10\\Day10_input.txt");
        new PipeSystem(inputs);
        traversedMap = new char[PipeSystem.pipeSystem.Count, PipeSystem.pipeSystem.First().Count];

        Console.WriteLine(Traverse.TraversePipeSystem() / 2);
        Console.WriteLine(GetNests());
    }

    private static int GetNests()
    {
        DfsEscape de = new DfsEscape();
        int counter = 0;
        for (int i = 0; i < PipeSystem.pipeSystem.Count; i++)
        {
            for (int j = 0; j < PipeSystem.pipeSystem.First().Count; j++)
            {
                if (traversedMap[i, j] == '\0')
                {
                    if (de.TryToEscape(i, j))
                    {
                        traversedMap[i, j] = '.';
                        counter++;
                    }
                }

                if (traversedMap[i, j] != '\0')
                    Console.Write(traversedMap[i, j]);
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
        return counter;
    }
}