using EgretApi.DataAccessLayer.Models;
using Newtonsoft.Json;
using EgretApi.Models.GeoJson.Properties;
using EgretApi.Models.GeoJson.Coordinates;

namespace EgretApi.DataAccessLayer.Mappers
{
    public static class ColdCallingControlledZoneMapper
    {
        public static ColdCallingControlledZone Map(
            this EgretApi.Models.GeoJson.ColdCallingControlledZone dto)
        {
            return new ColdCallingControlledZone
            {
                ObjectId = dto.Properties.ObjectId,
                Zones = dto.Properties.Zones,
                Ward = dto.Properties.Ward,
                Geometry = new ColdCallingControlledZoneGeometry
                {
                    Coordinates = JsonConvert.SerializeObject(dto.Geometry.Coordinates),
                },
            };
        }
        public static ColdCallingControlledZone Map(
            this ColdCallingControlledZone entity,
            EgretApi.Models.GeoJson.ColdCallingControlledZone dto)
        {
            entity.ObjectId = dto.Properties.ObjectId;
            entity.Zones = dto.Properties.Zones;
            entity.Ward = dto.Properties.Ward;
            entity.Geometry.ColdCallingControlledZoneID = entity.Id;
            entity.Geometry.Coordinates = JsonConvert.SerializeObject(dto.Geometry.Coordinates);

            return entity;
        }


        public static EgretApi.Models.GeoJson.ColdCallingControlledZone Map(
            this ColdCallingControlledZone entity)
        {
            return new EgretApi.Models.GeoJson.ColdCallingControlledZone
            {
                Type = Types.FeatureType.Feature,
                Properties = new ColdCallingControlledZonesProperties
                {
                    ObjectId = entity.ObjectId,
                    Zones = entity.Zones,
                    Ward = entity.Ward,
                },
                Geometry = new EgretApi.Models.GeoJson.Geometry<Polygon> 
                {
                    Type = Types.GeometryType.Polygon,
                    Coordinates = new EgretApi.Models.GeoJson.Coordinates.Polygon(
                        JsonConvert.DeserializeObject<List<List<List<double>>>>(entity.Geometry.Coordinates))
                },
            };
        }
    }
}
