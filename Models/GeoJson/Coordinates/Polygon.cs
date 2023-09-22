namespace EgretApi.Models.GeoJson.Coordinates
{
    public class Polygon
    {
        public List<LineString> Coordinates { get; set; } = new List<LineString>();

        public Polygon(List<LineString> coordinates)
        {
            Coordinates = coordinates;
        }
        public Polygon(List<List<List<double>>> coordinates)
        {
            Coordinates = coordinates.Select(x => new LineString(x)).ToList();
        }
        public Polygon() { }
    }
}
