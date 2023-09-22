namespace EgretApi.Models.Geospatial.Coordinates
{
    public class MultiPoint
    {
        public List<Point> Coordinates { get; set; } = new List<Point>();

        public MultiPoint(List<Point> coordinates)
        {
            Coordinates = coordinates;
        }
        public MultiPoint(List<List<double>> coordinates)
        {
            Coordinates = coordinates.Select(x => new Point(x)).ToList();
        }
        public MultiPoint() { }
    }
}
