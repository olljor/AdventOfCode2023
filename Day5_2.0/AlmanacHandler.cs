using Day5;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;

internal class AlmanacHandler
{
    public static Almanaca Almanaca = new Almanaca();
    public AlmanacHandler(IEnumerable<string> inputs)
    {
        string[] seedSplits = inputs.First().Split(':');
        Almanaca.seeds = StringToDict(seedSplits[1]);

        string relation = string.Empty;
        int counter = 0;
        List<AlmanacMapRow> items = new List<AlmanacMapRow>();
        foreach (string input in inputs)
        {
            counter++;
            if (input.EndsWith(':'))
            {
                // Set the items list to the correct almanac attribute
                if (relation != string.Empty)
                {
                    SetAlmenacRelation(items, relation);
                }

                relation = input;
                items = new List<AlmanacMapRow>();
            }
            else if (!string.IsNullOrEmpty(input) && !input.Contains("seeds"))
            {
                AlmanacMapRow item = new AlmanacMapRow();
                string[] splits = input.Split(' ');
                item.destination = long.Parse(splits[0]);
                item.source = long.Parse(splits[1]);
                item.range = long.Parse(splits[2]);
                items.Add(item);
                if (inputs.Count() == counter)
                {
                    SetAlmenacRelation(items, relation);
                }
            }
        }

    }

    private static void SetAlmenacRelation(IEnumerable<AlmanacMapRow> items, string relation)
    {
        switch (relation)
        {
            case "seed-to-soil map:":
                Almanaca.seedToSoil = items;
                break;

            case "soil-to-fertilizer map:":
                Almanaca.soilToFertilizer = items;
                break;

            case "fertilizer-to-water map:":
                Almanaca.fertilizerToWater = items;
                break;

            case "water-to-light map:":
                Almanaca.waterToLight = items;
                break;

            case "light-to-temperature map:":
                Almanaca.lightToTemperature = items;
                break;

            case "temperature-to-humidity map:":
                Almanaca.temperatureToHumidity = items;
                break;

            case "humidity-to-location map:":
                Almanaca.humidityToLocation = items;
                break;
        }
    }

    private static IDictionary<long, long> StringToDict(string line)
    {
        Dictionary<long, long> digits = new Dictionary<long, long>();

        bool digitFound = false;
        var digit = new StringBuilder();
        int counter = 0;
        long key = 0;

        foreach (char c in line)
        {
            counter++;
            if (char.IsDigit(c))
            {
                digitFound = true;
                digit.Append(c);
            }

            if ((digitFound && !char.IsDigit(c))
                || (digitFound && counter == line.Length))
            {
                if (key == 0)
                {
                    key = long.Parse(digit.ToString());
                }
                else
                {
                    digits.Add(key, long.Parse(digit.ToString()));
                    key = 0;
                }
                digitFound = false;
                digit = new StringBuilder();
            }
        }
        return digits;
    }
}