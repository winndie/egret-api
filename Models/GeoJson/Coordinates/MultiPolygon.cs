namespace EgretApi.Models.GeoJson.Coordinates
{
    public class MultiPolygon
    {
        public List<Polygon> Coordinates { get; set; } = new List<Polygon>();

        public MultiPolygon(List<Polygon> coordinates)
        {
            Coordinates = coordinates;
        }
        public MultiPolygon(List<List<List<List<double>>>> coordinates)
        {
            Coordinates = coordinates.Select(x => new Polygon(x)).ToList();
        }

        public MultiPolygon() { }
    }
}
