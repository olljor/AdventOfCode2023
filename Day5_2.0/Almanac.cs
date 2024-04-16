namespace Day5;

class AlmanacMap 
{
    public long destination { get; set; }
    public long source { get; set; }
    public long range { get; set; }
}

class Almanaca
{
    public IEnumerable<long> seeds;
    public IEnumerable<AlmanacMap> seedToSoil = new List<AlmanacMap>();
    public IEnumerable<AlmanacMap> soilToFertilizer = new List<AlmanacMap>();
    public IEnumerable<AlmanacMap> fertilizerToWater = new List<AlmanacMap>();
    public IEnumerable<AlmanacMap> waterToLight = new List<AlmanacMap>();
    public IEnumerable<AlmanacMap> lightToTemperature = new List<AlmanacMap>();
    public IEnumerable<AlmanacMap> temperatureToHumidity = new List<AlmanacMap>();
    public IEnumerable<AlmanacMap> humidityToLocation = new List<AlmanacMap>();
}