using Day14;
/*
 * Ze Plan:
 * Platform handler which sets up the platform as a lists of strings
 * Where every string is the the column of the platform (input)
 *      We are only interested in the vertical lines because we are only tilting the platform north    
 * When platform set up, tilt platform by moving every O to the index+1 of previous # or O
 * Then calculate weight by taking the list.count - index+1 of every O 
 */

class Day14Main
{
    public static async Task Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day14\\Day14_input.txt");
        PlatformHandler platformHandler = new PlatformHandler();

        List<string> verticalPlatform = platformHandler.SetUpPlatform(inputs);
        List<string> tiltedVerticalPlatform = await platformHandler.TiltVerticalPlatform(verticalPlatform);

        int weight = 0;
        foreach (string verticalPattern in tiltedVerticalPlatform)
        {
            Console.WriteLine(verticalPattern);
            for (int i = 0; i < verticalPattern.Length; i++)
            {
                if (verticalPattern[i] == 'O')
                {
                    weight = weight + verticalPattern.Length - i;
                }
            }
        }
        Console.WriteLine(weight);
    }
}