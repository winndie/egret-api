using EgretApi.DataAccessLayer;
using EgretApi.DataAccessLayer.Mappers;
using EgretApi.DataAccessLayer.Models;
using EgretApi.JsonModels;
using EgretApi.Models.GeoJson;
using EgretApi.Utilities;

namespace EgretApi.Services.GeoJson
{
    public class GeoJsonService : IGeoJsonService
    {
        private readonly GeospatialContext dbContext;
        public GeoJsonService(GeospatialContext context)
        {
            dbContext = context;
        }

        /// <summary>
        /// Insert a row to ColdCallingControlledZone
        /// </summary>
        /// <param name="json">The json string</param>
        /// <returns>ServiceResult<GeoJsonFeature></returns>
        public ServiceResult<int> CreateColdCallingControlledZone(ColdCallingControlledZoneJson json)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            var dto = 
                new ColdCallingControlledZoneDto(json.Type,json.Geometry.Type,json.Geometry.Coordinates,json.Properties);

            if(!dto.IsValid)
                return result;

            var entity = dto.Map();

            using (var uow = new UnitOfWork(dbContext))
            {
                var repo = uow.Repository<ColdCallingControlledZone>();
                repo.Add(entity);
                uow.Commit();
            }

            result = new ServiceResult<int>(entity.Id);

            return result;
        }
    }
}
