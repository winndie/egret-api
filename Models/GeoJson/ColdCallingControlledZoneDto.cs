using EgretApi.JsonModels;
using EgretApi.Models.GeoJson.Coordinates;
using EgretApi.Models.GeoJson.Properties;
using EgretApi.Types;

namespace EgretApi.Models.GeoJson
{
    public class ColdCallingControlledZoneDto : Feature<Polygon>
    {
        public ColdCallingControlledZoneDto() {}
        public ColdCallingControlledZoneDto(
            string featureType, 
            string geometryType,
            List<List<List<double>>> coordinates,
            ColdCallingControlledZoneJson.Property properties) 
        {

            if (!String.IsNullOrEmpty(featureType) &&
                Enum.GetName(FeatureType.Feature) == featureType &&
                !String.IsNullOrEmpty(geometryType) &&
                Enum.GetName(GeometryType.Polygon) == geometryType &&
                coordinates.Count() == 1 &&
                coordinates[0].Count() > 2 &&
                !String.IsNullOrEmpty(properties.Zones) &&
                !String.IsNullOrEmpty(properties.Ward))
            {
                this.Type = Enum.Parse<FeatureType>(featureType);
                this.Geometry.Type = Enum.Parse<GeometryType>(geometryType);
                this.Geometry.Coordinates = new Polygon(coordinates); 
                this.Properties.ObjectId = properties.ObjectId;
                this.Properties.Ward = properties.Ward;
                this.Properties.Zones = properties.Zones;
                this.IsValid = true;
            }

        }
        public ColdCallingControlledZonesProperties Properties { get; set; } = new ColdCallingControlledZonesProperties();
        public bool IsValid { get; private set; } = false;

    }
}
