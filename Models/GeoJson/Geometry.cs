using EgretApi.Types;

namespace EgretApi.Models.GeoJson
{
    public class Geometry<T> where T : new()
    {
        public Geometry() { }
        public GeometryType Type { get; set; }
        public T Coordinates { get; set; } = new T();

    }
}
