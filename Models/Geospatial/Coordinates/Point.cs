namespace EgretApi.Models.Geospatial.Coordinates
{
    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Point(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Point(List<double> cocoordinates)
        {
            Latitude = cocoordinates[0];
            Longitude = cocoordinates[1];
        }
        public Point() { }
    }
}
