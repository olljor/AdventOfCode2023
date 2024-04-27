using System.Linq;

namespace Day13;

class Pattern
{
    public List<string> horizontal = new List<string>();
    public List<string> vertical = new List<string>();
}

internal class PatternHandler
{
    public List<Pattern> SetPatterns(IEnumerable<string> inputs)
    {
        List<Pattern> patterns = new List<Pattern>();
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
        return patterns;
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

    public async Task<int> FindPatternsAsync(List<Pattern> patterns)
    {
        List<Task<int>> tasks = new List<Task<int>>();
        foreach (var pattern in patterns)
        {
            tasks.Add(Task.Run(() => CheckForSimilar(pattern)));
        }
        await Task.WhenAll(tasks);

        int total = 0;
        tasks.ForEach(task => total += task.Result);
        return total;
    }

    private int CheckForSimilar(Pattern pattern)
    {
        for (int i = 1; i < pattern.vertical.Count; i++)
        {
            if (pattern.vertical[i - 1] == pattern.vertical[i])
            {
                if (VerifyPattern(i, pattern.vertical))
                {
                    return i;
                }
            }
        }
        for (int i = 1; i < pattern.horizontal.Count; i++)
        {
            if (pattern.horizontal[i - 1] == pattern.horizontal[i])
            {
                if (VerifyPattern(i, pattern.horizontal))
                {
                    return i * 100;
                }
            }
        }
        return 0;
    }

    private bool VerifyPattern(int index, List<string> pattern)
    {
        int modifier = 1;
        while (index - modifier - 1 >= 0 && index + modifier < pattern.Count)
        {
            if (pattern[index - modifier - 1] != pattern[index + modifier])
            {
                return false;
            }
            modifier++;
        }
        return true;
    }
}