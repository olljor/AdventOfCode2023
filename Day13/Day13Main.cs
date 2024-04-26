using Day13;

class Day13Main
{
    public static void Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day13\\Day13_input.txt");
        new PatternHandler(inputs);

        int total = 0;
        foreach (var pattern in PatternHandler.patterns)
        {
            total += CheckForSimilar(pattern);
        }
        Console.WriteLine(total);
    }

    private static int CheckForSimilar(Pattern pattern)
    {
        /*
         * I am asuming that the if pattern[0] == pattern[1] is not valid because a reflection more than those cant be checked
         * I am also asuming that a pattern cant have both vertical and horizontal patterns, 
         * and therefore it does not matter which wone i check first 
         * 
         * It turns out that the first assumption was wrong :)
         */

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

    private static bool VerifyPattern(int index, List<string> pattern)
    {
        /* verify patterns (we are only here if pattern[index - 1] == pattern[index]):
         * therefore we want to verify that pattern[index - 2] == pattern[index + 1]
         * then also that [index - 3] == pattern[index + 2]
         * and so on ...
         * until the a edge is hit aka index - n - 1 < 0 || index + n > (Length of patterns)
         * start by iterating through the pattern 
         * while (index - n - 1 < 0 || index + n > (Length of patterns))
         *      if (pattern[index - n - 1] != pattern[index + n]) 
         *          return false;
         *        
         *      n++;
         *      
         * return true;
         */

        int modifier = 1;
        Console.WriteLine(pattern.Count);
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