namespace EgretApi.JsonModels
{
    public class ColdCallingControlledZoneJson : FeatureJson<List<List<List<double>>>>
    {
        public Property Properties { get; set; } = new Property();
        public class Property
        {
            public int ObjectId { get; set; }
            public string Zones { get; set; } = string.Empty;
            public string Ward { get; set; } = string.Empty;
        }
    }
}
