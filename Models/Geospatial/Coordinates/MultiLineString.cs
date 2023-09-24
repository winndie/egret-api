namespace EgretApi.Models.Geospatial.Coordinates
{
    public class MultiLineString: List<LineString>
    {
        public MultiLineString() { }
        public MultiLineString(List<LineString> coordinates)
            :base(coordinates) { }
        public MultiLineString(List<List<List<double>>> coordinates)
            : base(coordinates.Select(x => new LineString(x)).ToList()) { }
    }
}
