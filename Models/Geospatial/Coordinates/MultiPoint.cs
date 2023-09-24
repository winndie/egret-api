namespace EgretApi.Models.Geospatial.Coordinates
{
    public class MultiPoint: List<Point>
    {
        public MultiPoint() { }
        public MultiPoint(List<Point> coordinates)
            :base(coordinates) { }
        public MultiPoint(List<List<double>> coordinates)
            : base(coordinates.Select(x => new Point(x)).ToList()) { }
    }
}
