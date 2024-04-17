namespace Day5;

class AlmanacMapRow 
{
    public long destination { get; set; }
    public long source { get; set; }
    public long range { get; set; }
}

class Almanaca
{
    public IEnumerable<long> seeds;
    public IEnumerable<AlmanacMapRow> seedToSoil = new List<AlmanacMapRow>();
    public IEnumerable<AlmanacMapRow> soilToFertilizer = new List<AlmanacMapRow>();
    public IEnumerable<AlmanacMapRow> fertilizerToWater = new List<AlmanacMapRow>();
    public IEnumerable<AlmanacMapRow> waterToLight = new List<AlmanacMapRow>();
    public IEnumerable<AlmanacMapRow> lightToTemperature = new List<AlmanacMapRow>();
    public IEnumerable<AlmanacMapRow> temperatureToHumidity = new List<AlmanacMapRow>();
    public IEnumerable<AlmanacMapRow> humidityToLocation = new List<AlmanacMapRow>();
}