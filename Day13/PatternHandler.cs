namespace Day13;

class Pattern
{
    public List<string> horizontal = new List<string>();
    public List<string> vertical = new List<string>();
}

internal class PatternHandler
{
    public static List<Pattern> patterns = new List<Pattern>();
    public PatternHandler(IEnumerable<string> inputs)
    {
        List<string> tempPattern = new List<string>();
        foreach (var input in inputs)
        {
            if (string.IsNullOrEmpty(input))
            {
                patterns.Add(SetRealPattern(tempPattern));
                tempPattern = new List<string>();
            }
            else
            {
                tempPattern.Add(input);
            }
        }
        patterns.Add(SetRealPattern(tempPattern));
    }

    private Pattern SetRealPattern(List<string> tempPattern)
    {
        List<string> localHori = new List<string>();
        List<string> localVert = new List<string>();

        for (int i = 0; i < tempPattern.Count; i++)
        {
            localHori.Add(tempPattern[i]);

        }

        for (int j = 0; j < tempPattern.First().Length; j++)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < tempPattern.Count; i++)
            {
                chars.Add(tempPattern[i][j]);
            }
            localVert.Add(new string(chars.ToArray()));
        }

        return new Pattern
        {
            horizontal = localHori,
            vertical = localVert
        };
    }
}