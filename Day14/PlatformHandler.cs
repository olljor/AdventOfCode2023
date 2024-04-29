using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14;
class PlatformHandler
{
    public List<string> SetUpPlatform(IEnumerable<string> inputs)
    {
        List<string> verticalPatterns = new List<string>();
        List<string> inputList = inputs.ToList();
        for (int i = 0; i < inputList.First().Length; i++)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < inputList.Count; j++)
            {
                sb.Append(inputList[j][i]);
            }
            verticalPatterns.Add(sb.ToString());
        }
        return verticalPatterns;
    }

    public async Task<List<string>> TiltVerticalPlatform(List<string> verticalPlatform)
    {
        List<Task<string>> tasks = new List<Task<string>>();

        foreach (string pattern in verticalPlatform)
        {
            tasks.Add(Task.Run(() => RollBoulders(pattern)));
        }
        await Task.WhenAll(tasks);

        List<string> tiltedVerticalPatterns = new List<string>();
        tasks.ForEach(task => tiltedVerticalPatterns.Add(task.Result));

        return tiltedVerticalPatterns;
    }

    private string RollBoulders(string pattern)
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
}
