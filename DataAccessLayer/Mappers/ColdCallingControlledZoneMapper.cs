using EgretApi.DataAccessLayer.Models;
using Newtonsoft.Json;
using EgretApi.Models.GeoJson.Properties;
using EgretApi.Models.GeoJson.Coordinates;
using EgretApi.Types;
using EgretApi.Models.GeoJson;

namespace EgretApi.DataAccessLayer.Mappers
{
    public static class ColdCallingControlledZoneMapper
    {
        public static ColdCallingControlledZone Map(
            this ColdCallingControlledZoneDto dto)
        {
            return new ColdCallingControlledZone
            {
                ObjectId = dto.Properties.ObjectId,
                Zones = dto.Properties.Zones,
                Ward = dto.Properties.Ward,
                Geometry = new ColdCallingControlledZoneGeometry
                {
                    GeometryType = (int)dto.Geometry.Type,
                    Coordinates = JsonConvert.SerializeObject(dto.Geometry.Coordinates),
                },
            };
        }
        public static ColdCallingControlledZone Map(
            this ColdCallingControlledZone entity,
            ColdCallingControlledZoneDto dto)
        {
            entity.ObjectId = dto.Properties.ObjectId;
            entity.Zones = dto.Properties.Zones;
            entity.Ward = dto.Properties.Ward;
            entity.Geometry.ColdCallingControlledZoneID = entity.Id;
            entity.Geometry.GeometryType = (int)dto.Geometry.Type;
            entity.Geometry.Coordinates = JsonConvert.SerializeObject(dto.Geometry.Coordinates);

            return entity;
        }


        public static ColdCallingControlledZoneDto Map(
            this ColdCallingControlledZone entity)
        {
            return new ColdCallingControlledZoneDto
            {
                Id = entity.Id,
                Type = FeatureType.Feature,
                Properties = new ColdCallingControlledZonesProperties
                {
                    ObjectId = entity.ObjectId,
                    Zones = entity.Zones,
                    Ward = entity.Ward,
                },
                //Geometry = new Geometry<Polygon> 
                //{
                //    Id = entity.Geometry.Id,
                //    Type = (GeometryType)entity.Geometry.GeometryType,
                //    Coordinates = new Polygon(
                //        JsonConvert.DeserializeObject<List<List<List<double>>>>(entity.Geometry.Coordinates))
                //},
            };
        }
    }
}
