using Day15;

class Day15main
{
    public static async Task Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day15\\Day15_input.txt");
        SequenceHandler sequenceHandler = new SequenceHandler();
        List<Tuple<string, string>> sequence = await sequenceHandler.SetUpSequence(inputs);
        BoxHandler boxHandler = new BoxHandler();

        foreach (var item in sequence)
        {
            if (item.Item2 == "-")
            {
                boxHandler.RemoveLens(item.Item1);
            }
            else if (item.Item2.First() == '=')
            {
                boxHandler.AddLens(item);
            }
        }

        int total = 0;
        for (int i = 0; i < boxHandler.Boxes.Length; i++)
        {
            if (boxHandler.Boxes[i] == null)
            {
                continue;
            }
            for (int j = 0; j < boxHandler.Boxes[i].Count; j++)
            {
                total += (i + 1) * (j + 1) * boxHandler.Boxes[i][j].focal;
            }
        }
        Console.WriteLine(total);
    }
}