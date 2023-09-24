namespace EgretApi.Models.Geospatial.Coordinates
{
    public class Polygon: List<LineString>
    {
        public Polygon() { }

        public Polygon(List<LineString> coordinates) 
            : base(coordinates) { }
        public Polygon(List<List<List<double>>> coordinates) 
            : base(coordinates.Select(x => new LineString(x)).ToList()) { }
    }
}
