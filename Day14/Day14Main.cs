using Day14;
class Day14Main
{
    public static async Task Main()
    {
        IEnumerable<string> inputs = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day14\\Day14_input.txt");
        PlatformHandler platformHandler = new PlatformHandler();
        List<string> platform = inputs.ToList();

        for (long i = 0; i < 1000000000; i++)
        {
            if (i%100000 == 0)
                Console.WriteLine(1000000000 - i);    

            platform = await platformHandler.TiltPlatformNorthAsync(platform);
            platform = await platformHandler.TiltPlatformWestAsync(platform);
            platform = await platformHandler.TiltPlatformSouthAsync(platform);
            platform = await platformHandler.TiltPlatformEastAsync(platform);
        }

        int weight = 0;
        foreach (string plat in platform)
        {
            Console.WriteLine(plat);
            for (int i = 0; i < plat.Length; i++)
            {
                if (plat[i] == 'O')
                {
                    weight = weight + plat.Length - i;
                }
            }
        }
        Console.WriteLine(weight);
    }
}