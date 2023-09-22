namespace EgretApi.Models.GeoJson.Coordinates
{
    public class LineString
    {
        public List<Point> Coordinates { get; set; } = new List<Point>();

        public LineString(List<Point> coordinates)
        {
            Coordinates = coordinates;
        }

        public LineString(List<List<double>> coordinates)
        {
            Coordinates = coordinates.Select(x=>new Point(x)).ToList();
        }
        public LineString() { }
    }
}
