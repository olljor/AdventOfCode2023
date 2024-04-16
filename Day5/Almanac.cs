namespace Day5;

class AlmanacItem 
{
    public int source { get; set; }
    public int destination { get; set; }
    public int range { get; set; }
}

class Almanaca
{
    public IEnumerable<int> seeds;
    public IEnumerable<AlmanacItem> seedToSoil = new List<AlmanacItem>();
    public IEnumerable<AlmanacItem> soilToFertilizer = new List<AlmanacItem>();
    public IEnumerable<AlmanacItem> fertilizerToWater = new List<AlmanacItem>();
    public IEnumerable<AlmanacItem> waterToLight = new List<AlmanacItem>();
    public IEnumerable<AlmanacItem> lightToTemperature = new List<AlmanacItem>();
    public IEnumerable<AlmanacItem> temperatureToHumidity = new List<AlmanacItem>();
    public IEnumerable<AlmanacItem> humidityToLocation = new List<AlmanacItem>();
}