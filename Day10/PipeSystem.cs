namespace Day10;

class Pipe
{
    public bool connectionNorth { get; set; } = false;
    public bool connectionEast { get; set; } = false;
    public bool connectionSouth { get; set; } = false;
    public bool connectionWest { get; set; } = false;
}

internal class PipeSystem
{
    public static int[] pipeStartIndex = new int[2]; 
    public static List<List<Pipe>> pipeSystem = new List<List<Pipe>>();
    public PipeSystem(IEnumerable<string> input)
    {
        foreach (var line in input)
        {
            pipeSystem.Add(pipeLine(line));
        }
    }

    private static List<Pipe> pipeLine(string line)
    {
        List<Pipe> pipes = new List<Pipe>();
        foreach (char pipeCaracter in line)
        {
            switch (pipeCaracter)
            {
                case '|':
                    pipes.Add(new Pipe
                    {
                        connectionNorth = true,
                        connectionSouth = true
                    });
                    break;

                case '-':
                    pipes.Add(new Pipe
                    {
                        connectionWest = true,
                        connectionEast = true
                    });
                    break;

                case 'L':
                    pipes.Add(new Pipe
                    {
                        connectionNorth = true,
                        connectionEast = true
                    });
                    break;

                case 'J':
                    pipes.Add(new Pipe
                    {
                        connectionNorth = true,
                        connectionWest = true
                    });
                    break;
                    
                case '7':
                    pipes.Add(new Pipe
                    {
                        connectionSouth = true,
                        connectionWest = true
                    });
                    break;

                case 'F':
                    pipes.Add(new Pipe
                    {
                        connectionEast = true,
                        connectionSouth = true
                    });
                    break;

                case 'S':
                    pipeStartIndex[0] = pipeSystem.Count;
                    pipeStartIndex[1] = pipes.Count;
                    pipes.Add(new Pipe
                    {
                        connectionNorth = true,
                        connectionWest = true,
                        connectionEast = true,
                        connectionSouth = true
                    });
                    break;

                default:
                    pipes.Add(new Pipe { });
                    break;
            }
        }
        return pipes;
    }
}