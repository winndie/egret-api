namespace EgretApi.RequestModels
{
    public class UpdateColdCallingControlledZoneRequest
    {
        public int Id { get; set; }
        public string Zones { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
    }
}
