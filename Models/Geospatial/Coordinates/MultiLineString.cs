namespace EgretApi.Models.Geospatial.Coordinates
{
    public class MultiLineString
    {
        public List<LineString> Coordinates { get; set; } = new List<LineString>();

        public MultiLineString(List<LineString> coordinates)
        {
            Coordinates = coordinates;
        }
        public MultiLineString(List<List<List<double>>> coordinates)
        {
            Coordinates = coordinates.Select(x => new LineString(x)).ToList();
        }
        public MultiLineString() { }
    }
}
