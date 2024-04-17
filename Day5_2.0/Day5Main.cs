using Day5;
using System.Runtime.InteropServices;

class Day5Main
{
    private static long FindBestPath()
    {
        long lowestLocation = 99999999999;

        foreach (var seedDict in AlmanacHandler.Almanaca.seeds)
        {
            long initialSeed = seedDict.Key;
            long rangeSeed = seedDict.Value;
            Console.WriteLine("Seed pair " + initialSeed + ", " +  rangeSeed);
            for (long seed = initialSeed; seed < initialSeed + rangeSeed; seed++)
            {
                long nextDestination = seed;
                nextDestination = FindNextMapRow(nextDestination, AlmanacHandler.Almanaca.seedToSoil);
                nextDestination = FindNextMapRow(nextDestination, AlmanacHandler.Almanaca.soilToFertilizer);
                nextDestination = FindNextMapRow(nextDestination, AlmanacHandler.Almanaca.fertilizerToWater);
                nextDestination = FindNextMapRow(nextDestination, AlmanacHandler.Almanaca.waterToLight);
                nextDestination = FindNextMapRow(nextDestination, AlmanacHandler.Almanaca.lightToTemperature);
                nextDestination = FindNextMapRow(nextDestination, AlmanacHandler.Almanaca.temperatureToHumidity);
                long location = FindNextMapRow(nextDestination, AlmanacHandler.Almanaca.humidityToLocation);
                if (lowestLocation > location)
                {
                    lowestLocation = location;
                }
            }
        }
        return lowestLocation;
    }

    private static long FindNextMapRow(long destination, IEnumerable<AlmanacMapRow> map)
    {
        foreach (var row in map)
        {
            if (destination >= row.source &&
                destination < row.source + row.range)
            {
                return row.destination + destination - row.source;
            }
        }
        return destination;
    }

    public static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day5_2.0\\Day5_input.txt");
        new AlmanacHandler(input);

        Console.WriteLine("lowest location: " + FindBestPath());
    }
}