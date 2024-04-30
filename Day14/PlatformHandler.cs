using System.Text;

namespace Day14;
class PlatformHandler
{
    internal List<string> FlipPattern(List<string> platform)
    {
        List<string> verticalPatterns = new List<string>();
        for (int i = 0; i < platform.First().Length; i++)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < platform.Count; j++)
            {
                sb.Append(platform[j][i]);
            }
            verticalPatterns.Add(sb.ToString());
        }
        return verticalPatterns;
    }

    internal async Task<List<string>> TiltPlatformNorthAsync(List<string> platform)
    {
        List<string> verticalPlatform = FlipPattern(platform);

        List<Task<string>> tasks = new List<Task<string>>();
        foreach (string pattern in verticalPlatform)
        {
            tasks.Add(Task.Run(() => RollBouldersNorthWest(pattern)));
        }
        await Task.WhenAll(tasks);

        List<string> tiltedPlatform = new List<string>();
        tasks.ForEach(task => tiltedPlatform.Add(task.Result));
        return FlipPattern(tiltedPlatform);
    }
    internal async Task<List<string>> TiltPlatformWestAsync(List<string> platform)
    {
        List<Task<string>> tasks = new List<Task<string>>();
        foreach (string pattern in platform)
        {
            tasks.Add(Task.Run(() => RollBouldersNorthWest(pattern)));
        }
        await Task.WhenAll(tasks);

        List<string> tiltedPlatform = new List<string>();
        tasks.ForEach(task => tiltedPlatform.Add(task.Result));
        return tiltedPlatform;
    }
    internal async Task<List<string>> TiltPlatformSouthAsync(List<string> platform)
    {
        List<string> verticalPlatform = FlipPattern(platform);

        List<Task<string>> tasks = new List<Task<string>>();
        foreach (string pattern in verticalPlatform)
        {
            tasks.Add(Task.Run(() => RollBouldersSouthEst(pattern)));
        }
        await Task.WhenAll(tasks);

        List<string> tiltedPlatform = new List<string>();
        tasks.ForEach(task => tiltedPlatform.Add(task.Result));
        return FlipPattern(tiltedPlatform);
    }
    internal async Task<List<string>> TiltPlatformEastAsync(List<string> platform)
    {
        List<Task<string>> tasks = new List<Task<string>>();
        foreach (string pattern in platform)
        {
            tasks.Add(Task.Run(() => RollBouldersSouthEst(pattern)));
        }
        await Task.WhenAll(tasks);

        List<string> tiltedPlatform = new List<string>();
        tasks.ForEach(task => tiltedPlatform.Add(task.Result));
        return tiltedPlatform;
    }
    private string RollBouldersNorthWest(string pattern)
    {
        char[] chars = pattern.ToCharArray();
        int freeSpot = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '#')
            {
                freeSpot = i + 1;
            }
            if (chars[i] == 'O')
            {
                chars[i] = '.';
                chars[freeSpot] = 'O';
                freeSpot++;
            }
        }
        return new string(chars);
    }
    private string RollBouldersSouthEst(string pattern)
    {
        char[] chars = pattern.ToCharArray();
        int freeSpot = chars.Length - 1;
        for (int i = chars.Length - 1; i >= 0; i--)
        {
            if (chars[i] == '#')
            {
                freeSpot = i - 1;
            }
            if (chars[i] == 'O')
            {
                chars[i] = '.';
                chars[freeSpot] = 'O';
                freeSpot--;
            }
        }
        return new string(chars);
    }
}