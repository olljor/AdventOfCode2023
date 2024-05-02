using System.Text;
namespace Day15;

internal class SequenceHandler
{
    internal async Task<List<Tuple<string, string>>> SetUpSequence(IEnumerable<string> inputs)
    {
        List<string> sequence = new List<string>();
        foreach (var input in inputs)
        {
            sequence.AddRange(input.Split(','));
        }

        List<Task<Tuple<string, string>>> tasks = new List<Task<Tuple<string, string>>>();
        foreach (var seq in sequence)
        {
            tasks.Add(Task.Run(() => new Tuple<string, string>(GetLabel(seq), GetInstruction(seq))));
        }
        await Task.WhenAll(tasks);

        List<Tuple<string, string>> result = new List<Tuple<string, string>>();
        tasks.ForEach(task => result.Add(task.Result));

        return result;
    }
    private string GetLabel(string seq)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char ch in seq)
        {
            if (char.IsLetter(ch))
            {
                sb.Append(ch);
            }
            else
            {
                return sb.ToString();
            }
        }
        return string.Empty;
    }
    private string GetInstruction(string seq)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char ch in seq)
        {
            if (char.IsLetter(ch))
            {
                continue;
            }
            else
            {
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }
}