namespace EgretApi.Models.Geospatial.Coordinates
{
    public class LineString : List<Point>
    {
        public LineString() { }
        public LineString(List<Point> coordinates)
            :base(coordinates) { }
        public LineString(List<List<double>> coordinates)
            : base(coordinates.Select(x => new Point(x)).ToList()) { }
    }
}
