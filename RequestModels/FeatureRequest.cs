namespace EgretApi.JsonModels
{
    public class FeatureRequest<T> where T : new()
    {
        public string Type { get; set; } = string.Empty;
        public GeometryRequest<T> Geometry { get; set; } = new GeometryRequest<T>();
    }
}
