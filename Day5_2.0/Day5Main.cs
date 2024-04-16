using Day5;

class Day5Main
{
    public static void Main(string[] args)
    {
        IEnumerable<string> input = File.ReadLines("C:\\Users\\olljo\\source\\repos\\AdventOfCode2023\\Day5_2.0\\Day5_input.txt");
        new AlmanacHandler(input);

        Console.WriteLine("seedtosoil");
        foreach (var line in AlmanacHandler.Almanaca.seedToSoil)
        {
            Console.WriteLine(line.destination + ", " + line.source + ", " + line.range);
        }
        Console.WriteLine("soiltofert");
        foreach (var line in AlmanacHandler.Almanaca.soilToFertilizer)
        {
            Console.WriteLine(line.destination + ", " + line.source + ", " + line.range);
        }
        Console.WriteLine("ferttowayt");
        foreach (var line in AlmanacHandler.Almanaca.fertilizerToWater)
        {
            Console.WriteLine(line.destination + ", " + line.source + ", " + line.range);
        }
        Console.WriteLine("wayttoligt");
        foreach (var line in AlmanacHandler.Almanaca.waterToLight)
        {
            Console.WriteLine(line.destination + ", " + line.source + ", " + line.range);
        }
        Console.WriteLine("lighttotemp");
        foreach (var line in AlmanacHandler.Almanaca.lightToTemperature)
        {
            Console.WriteLine(line.destination + ", " + line.source + ", " + line.range);
        }
        Console.WriteLine("temptohumid");
        foreach (var line in AlmanacHandler.Almanaca.temperatureToHumidity)
        {
            Console.WriteLine(line.destination + ", " + line.source + ", " + line.range);
        }
        Console.WriteLine("humidtoloc");
        foreach (var line in AlmanacHandler.Almanaca.humidityToLocation)
        {
            Console.WriteLine(line.destination + ", " + line.source + ", " + line.range);
        }
    }
}