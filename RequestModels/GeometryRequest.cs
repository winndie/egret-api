namespace EgretApi.JsonModels
{
    public class GeometryRequest<T> where T : new()
    {
        public string Type { get; set; } = string.Empty;
        public T Coordinates { get; set; } = new T();
    }
}
