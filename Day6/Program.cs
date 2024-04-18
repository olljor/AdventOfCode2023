
class Day6
{
    private static int FindNrOfTimes(int bestDistance, int time) 
    {
        int modifier = 0;
        for (int t = time; t >= 0; t--)
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
        IDictionary<int, int> races = new Dictionary<int, int>() 
        {
            {543, 59},
            {1020, 68},
            {1664, 82},
            {1022, 74},
        };

        List<int> times = new List<int>();
        foreach (var race in races) 
        {
            times.Add(FindNrOfTimes(race.Key, race.Value));
        }
        int multi = times.Aggregate((a, x) => a * x);
        Console.WriteLine(multi);
    }
}