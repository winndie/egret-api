using EgretApi.Types;

namespace EgretApi.Models.Geospatial
{
    public class Geometry<T> where T : new()
    {
        public Geometry() { }
        public int Id { get; set; }
        public GeometryType Type { get; set; }
        public T Coordinates { get; set; } = new T();

    }
}
