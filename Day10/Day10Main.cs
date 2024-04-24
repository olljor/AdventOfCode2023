

using Day10;

class PipeCordinate
{
    public int row { get; set; }
    public int col { get; set; }
}
class Day10Main
{
    private static int TraversePipeSystem()
    {
        Pipe previousPipe = new Pipe();
        PipeCordinate currentPipeCordinate = new PipeCordinate
        {
            row = PipeSystem.pipeStartIndex[0],
            col = PipeSystem.pipeStartIndex[1]
        };
        Tuple<PipeCordinate, Pipe> info = new Tuple<PipeCordinate, Pipe>(currentPipeCordinate, previousPipe);

        int counter = 0;
        while (true)
        {
            counter++;
            //Console.WriteLine(info.Item1.row + ", " + info.Item1.col);
            info = GetNextPipe(info.Item1, info.Item2);

            if (PipeSystem.pipeStartIndex[0] == info.Item1.row
            && PipeSystem.pipeStartIndex[1] == info.Item1.col)
            {
                return counter;
            }
        }
    }

    private static Tuple<PipeCordinate, Pipe> GetNextPipe(PipeCordinate currentPipeCordinate, Pipe previousPipeDirection)
    {
        Pipe currentPipe = PipeSystem.pipeSystem[currentPipeCordinate.row][currentPipeCordinate.col];
        try
        {
            if (currentPipe.connectionSouth
                && !previousPipeDirection.connectionNorth
                && PipeSystem.pipeSystem[currentPipeCordinate.row + 1][currentPipeCordinate.col].connectionNorth)
            {
                return new Tuple<PipeCordinate, Pipe>(
                    new PipeCordinate
                    {
                        row = currentPipeCordinate.row + 1,
                        col = currentPipeCordinate.col
                    },
                    new Pipe { connectionSouth = true }
                    );
            }

        }
        catch (Exception) { }

        try
        {
            if (currentPipe.connectionNorth
                && !previousPipeDirection.connectionSouth
                && PipeSystem.pipeSystem[currentPipeCordinate.row - 1][currentPipeCordinate.col].connectionSouth)
            {
                return new Tuple<PipeCordinate, Pipe>(
                    new PipeCordinate
                    {
                        row = currentPipeCordinate.row - 1,
                        col = currentPipeCordinate.col
                    },
                    new Pipe { connectionNorth = true }
                    );
            }
        }
        catch (Exception) { }

        try
        {
            if (currentPipe.connectionEast
                && !previousPipeDirection.connectionWest
                && PipeSystem.pipeSystem[currentPipeCordinate.row][currentPipeCordinate.col + 1].connectionWest)
            {
                return new Tuple<PipeCordinate, Pipe>(
                    new PipeCordinate
                    {
                        row = currentPipeCordinate.row,
                        col = currentPipeCordinate.col + 1
                    },
                    new Pipe { connectionEast = true }
                    );
            }
        }
        catch (Exception) { }

        try
        {
            if (currentPipe.connectionWest
                && !previousPipeDirection.connectionEast
                && PipeSystem.pipeSystem[currentPipeCordinate.row][currentPipeCordinate.col - 1].connectionEast)
            {
                return new Tuple<PipeCordinate, Pipe>(
                    new PipeCordinate
                    {
                        row = currentPipeCordinate.row,
                        col = currentPipeCordinate.col - 1
                    },
                    new Pipe { connectionWest = true }
                    );
            }
        }
        catch (Exception) { }

        Console.WriteLine("Something went wrong");
        return new Tuple<PipeCordinate, Pipe>(new PipeCordinate(), currentPipe);
    }

    public static void Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day10\\Day10_input.txt");
        new PipeSystem(inputs);

        int steps = TraversePipeSystem();
        Console.WriteLine(steps/2);
    }
}