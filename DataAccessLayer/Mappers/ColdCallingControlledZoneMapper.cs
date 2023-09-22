using EgretApi.DataAccessLayer.Models;
using Newtonsoft.Json;
using EgretApi.Models.Geospatial.Properties;
using EgretApi.Models.Geospatial.Coordinates;
using EgretApi.Types;
using EgretApi.Models.Geospatial;
using EgretApi.RequestModels;

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
            UpdateColdCallingControlledZoneRequest request)
        {
            entity.Zones = request.Zones;
            entity.Ward = request.Ward;

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
