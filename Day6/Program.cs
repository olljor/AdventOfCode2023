
class Day6
{
    private static long FindNrOfTimes(long bestDistance, long time) 
    {
        long modifier = 0;
        for (long t = time; t >= 0; t--)
        {
            if (bestDistance < t * modifier)
            {
                return t - modifier + 1;
            }
            modifier++;
        }
        return 0;
    }

    public static void Main() 
    {
        Console.WriteLine(FindNrOfTimes(543102016641022, 59688274));     
    }
}