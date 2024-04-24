using Day10;
class Day10Main
{
    public static char[,] traversedMap = new char[0, 0];

    public static void Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day10\\Day10_input.txt");
        new PipeSystem(inputs);

        traversedMap = new char[PipeSystem.pipeSystem.Count, PipeSystem.pipeSystem.First().Count];
        int steps = Traverse.TraversePipeSystem();
        Console.WriteLine(steps / 2);


        Console.WriteLine(PipeSystem.pipeSystem.Count + " "+ PipeSystem.pipeSystem.First().Count);

        int nrNests = GetNests();
    }

    private static int GetNests()
    {
        int counter = 0;
        for (int i = 0; i < PipeSystem.pipeSystem.Count; i++)
        {
            for (int j = 0; j < PipeSystem.pipeSystem.First().Count; j++)
            {
                if (traversedMap[i, j] == '\0')
                {
                    try
                    {
                        if (GetEscape(i, j))
                        {
                            traversedMap[i, j] = '.';
                            counter++;
                        }
                    }
                    catch (Exception) { }
                }

                if (traversedMap[i, j] != '\0')
                {
                    Console.Write(traversedMap[i, j]);
                }
                else
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine();
        }
        return counter;
    }

    private static bool GetEscape(int index, int jndex)
    {
        bool valid = false;

        for (int i = index; i < PipeSystem.pipeSystem.Count; i++)
        {
            if (traversedMap[i, jndex] != '\0')
            {
                valid = true;
                break;
            }
        }
        if (!valid) return false;

        valid = false;
        for (int i = index; i != 0; i--)
        {
            if (traversedMap[i, jndex] != '\0')
            {
                valid = true;
                break;
            }
        }
        if (!valid) return false;

        valid = false;
        for (int j = jndex; j < PipeSystem.pipeSystem.Count; j++)
        {
            if (traversedMap[index, j] != '\0')
            {
                valid = true;
                break;
            }
        }
        if (!valid) return false;

        valid = false;
        for (int j = jndex; j != 0; j--)
        {
            if (traversedMap[index, j] != '\0')
            {
                valid = true;
                break;
            }
        }
        if (!valid) return false;
        
        return true;
    }
}