using EgretApi.DataAccessLayer;
using EgretApi.DataAccessLayer.Mappers;
using EgretApi.DataAccessLayer.Models;
using EgretApi.JsonModels;
using EgretApi.Models.Geospatial;
using EgretApi.RequestModels;
using EgretApi.Utilities;

namespace EgretApi.Services.Geospatial
{
    public class GeospatialService : IGeospatialService
    {
        private readonly GeospatialContext dbContext;
        public GeospatialService(GeospatialContext context)
        {
            dbContext = context;
        }

        public GeospatialService() { }

        /// <summary>
        /// Get a ColdCallingControlledZone from database
        /// </summary>
        /// <param name="Id">Id of the entity</param>
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
        /// <param name="request">Request object</param>
        /// <returns>ServiceResult<int></returns>
        public ServiceResult<int> CreateColdCallingControlledZone(CreateColdCallingControlledZoneRequest request)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            var dto = 
                new ColdCallingControlledZoneDto(request.Type,request.Geometry.Type,request.Geometry.Coordinates,request.Properties);

            if(!dto.IsValid)
                return result;

            var entity = dto.Map();

            using (var uow = new UnitOfWork(dbContext))
            {
                var repo = uow.Repository<ColdCallingControlledZone>();
                repo.Add(entity);
                uow.Commit();
                result = new ServiceResult<int>(entity.Id);
            }

            return result;
        }

        /// <summary>
        /// Update a row in ColdCallingControlledZone
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>ServiceResult<int></returns>
        public ServiceResult<int> UpdateColdCallingControlledZone(UpdateColdCallingControlledZoneRequest request)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            using (var uow = new UnitOfWork(dbContext))
            {
                var repo = uow.Repository<ColdCallingControlledZone>();
                var entity = repo.GetById(request.Id);

                if (entity == null)
                {
                    return result;
                }
                entity = entity.Map(request);
                repo.Update(entity);
                uow.Commit();
                result = new ServiceResult<int>(entity.Id);
            }

            return result;
        }
        /// <summary>
        /// Delete a row of ColdCallingControlledZone from database
        /// </summary>
        /// <param name="Id">Id of the entity</param>
        /// <returns>ServiceResult<int></returns>
        public ServiceResult<int> DeleteColdCallingControlledZone(int Id)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            using (var uow = new UnitOfWork(dbContext))
            {
                var repo = uow.Repository<ColdCallingControlledZone>();
                var entity = repo.GetById(Id);

                if (entity == null)
                {
                    return result;
                }

                repo.Delete(entity);
                uow.Commit();
                result = new ServiceResult<int>(entity.Id);
            }

            return result;
        }
    }
}
