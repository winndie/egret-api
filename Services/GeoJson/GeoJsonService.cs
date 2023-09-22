using EgretApi.DataAccessLayer;
using EgretApi.DataAccessLayer.Mappers;
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

            var entity = 
                new ColdCallingControlledZone(json.Type,json.Geometry.Type,json.Geometry.Coordinates,json.Properties);

            if(!entity.IsValid)
                return result;

            var uow = new UnitOfWork(dbContext);
            var repo = uow.Repository<DataAccessLayer.Models.ColdCallingControlledZone>();
            repo.Add(entity.Map());
            uow.Commit();

            result = new ServiceResult<int>(entity.Properties.ObjectId);

            return result;
        }
    }
}
