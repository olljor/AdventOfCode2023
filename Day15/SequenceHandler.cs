


namespace Day15;

internal class SequenceHandler
{
    internal List<string> SetUpSequence(IEnumerable<string> inputs)
    {
        List<string> sequence = new List<string>();
        foreach (var input in inputs)
        {
            sequence.AddRange(input.Split(','));
        }
        return sequence;
    }

    internal async Task<List<int>> HashSequence(List<string> sequence)
    {
        List<Task<int>> tasks = new List<Task<int>>();
        foreach (var task in sequence)
        {
            tasks.Add(Task.Run(() => GetHashForString(task)));
        }
        await Task.WhenAll(tasks);
        List<int> result = new List<int>();
        tasks.ForEach(task => result.Add(task.Result));

        return result;
    }

    private int GetHashForString(string task)
    {
        int value = 0;
        foreach (char ch in task)
        {
            value += (int)ch;
            value = value * 17;
            value = value % 256;
        }
        return value;
    }
}