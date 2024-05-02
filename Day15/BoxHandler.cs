namespace Day15;

class Lens
{
    public string? label { get; set; }
    public int focal { get; set; }
}

class BoxHandler
{
    public List<Lens>[] Boxes = new List<Lens>[256];
    public void RemoveLens(string label)
    {
        int boxIndex = GetHashForLabel(label);
        if (Boxes[boxIndex] == null)
        {
            return;
        }
        Boxes[boxIndex].RemoveAll(lens => lens.label == label);
    }
    public void AddLens(Tuple<string, string> tuple)
    {
        Lens newLens = new Lens
        {
            label = tuple.Item1,
            focal = int.Parse(new string(tuple.Item2.Last(), 1))
        };

        int boxIndex = GetHashForLabel(newLens.label);
        if (Boxes[boxIndex] == null)
        {
            Boxes[boxIndex] = [newLens];
            return;
        }

        int index = Boxes[boxIndex].FindIndex(lens => lens.label == newLens.label);
        if (index == -1) // the findindex function returns -1 if no item is found 
        {
            Boxes[boxIndex].Add(newLens);
        }
        else
        {
            Boxes[boxIndex][index] = newLens;
        }
    }
    private int GetHashForLabel(string task)
    {
        int value = 0;
        foreach (char ch in task)
        {
            value += ch;
            value = value * 17;
            value = value % 256;
        }
        return value;
    }
}