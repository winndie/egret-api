namespace EgretApi.Models.Geospatial.Properties
{
    public class ColdCallingControlledZonesProperties
    {
        public ColdCallingControlledZonesProperties() { }

        public ColdCallingControlledZonesProperties(int objectId, string zones, string ward)
        {
            ObjectId = objectId;
            Zones = zones;
            Ward = ward;
        }
        public int ObjectId { get; set; }
        public string Zones { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
    }
}
