namespace weatherappsim;
public class City
{
    public string Name { get; set; }
    public weatherdata? Weather { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public City(string name, double lat, double lon)
    {
        Name = name;
        Latitude = lat;
        Longitude = lon;
    }
}