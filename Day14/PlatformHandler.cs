using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14;
class PlatformHandler
{
    private List<string> FlipPattern(List<string> platform)
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
        bool boulderMoved = false;
        while (!boulderMoved)
        {
            bool boulderFound = false;
            boulderMoved = true;
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                if ((chars[i] == '#' || chars[i] == 'O')
                    && boulderFound)
                {
                    chars[i + 1] = 'O';
                    boulderFound = false;
                }

                if (chars[i] == 'O' && !boulderFound)
                {
                    boulderFound = true;
                    chars[i] = '.';
                }
                else
                {
                    if (boulderFound)
                    {
                        boulderMoved = false;
                    }
                    chars[i] = chars[i];
                }
            }
            if (boulderFound)
            {
                chars[0] = 'O';
            }
        }
        return new string(chars);
    }
    private string RollBouldersSouthEst(string pattern)
    {
        char[] chars = pattern.ToCharArray();
        bool boulderMoved = false;
        while (!boulderMoved)
        {
            bool boulderFound = false;
            boulderMoved = true;
            for (int i = 0; i < chars.Length; i++)
            {
                if ((chars[i] == '#' || chars[i] == 'O')
                    && boulderFound)
                {
                    chars[i - 1] = 'O';
                    boulderFound = false;
                }

                if (chars[i] == 'O' && !boulderFound)
                {
                    boulderFound = true;
                    chars[i] = '.';
                }
                else
                {
                    if (boulderFound)
                    {
                        boulderMoved = false;
                    }
                    chars[i] = chars[i];
                }
            }
            if (boulderFound)
            {
                chars[chars.Length - 1] = 'O';
            }
        }
        return new string(chars);
    }
}