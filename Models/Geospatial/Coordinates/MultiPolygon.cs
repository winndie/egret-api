namespace EgretApi.Models.Geospatial.Coordinates
{
    public class MultiPolygon: List<Polygon>
    {
        public MultiPolygon() { }
        public MultiPolygon(List<Polygon> coordinates)
            :base(coordinates) { }
        public MultiPolygon(List<List<List<List<double>>>> coordinates)
            :base(coordinates.Select(x => new Polygon(x)).ToList()) { }
    }
}
