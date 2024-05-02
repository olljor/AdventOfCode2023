
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
}