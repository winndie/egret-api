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

        public GeoJsonService() { }

        /// <summary>
        /// Get a ColdCallingControlledZone from database
        /// </summary>
        /// <param name="Id">The Id of the entity</param>
        /// <returns>ServiceResult<ColdCallingControlledZoneDto></returns>
        public ServiceResult<ColdCallingControlledZoneDto> GetColdCallingControlledZone(int Id)
        {
            ServiceResult<ColdCallingControlledZoneDto> result = new ServiceResult<ColdCallingControlledZoneDto>();

            using (var uow = new UnitOfWork(dbContext))
            {
                var repo = uow.Repository<ColdCallingControlledZone>();
                var entity = repo.GetById(Id);

                if (entity == null)
                {
                    return result;
                }

                result = new ServiceResult<ColdCallingControlledZoneDto>(entity.Map());
            }

            return result;
        }

        /// <summary>
        /// Insert a row to ColdCallingControlledZone
        /// </summary>
        /// <param name="json">The json string</param>
        /// <returns>ServiceResult<int></returns>
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
