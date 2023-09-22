namespace EgretApi.JsonModels
{
    public class FeatureJson<T> where T : new()
    {
        public string Type { get; set; } = string.Empty;
        public GeometryJson<T> Geometry { get; set; } = new GeometryJson<T>();
    }
}
