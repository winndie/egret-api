using EgretApi.JsonModels;
using EgretApi.Models.Geospatial;
using EgretApi.RequestModels;
using EgretApi.Utilities;

namespace EgretApi.Services.Geospatial
{
    public interface IGeospatialService
    {
        ServiceResult<ColdCallingControlledZoneDto> GetColdCallingControlledZone(int Id);
        ServiceResult<int> CreateColdCallingControlledZone(CreateColdCallingControlledZoneRequest request);
        ServiceResult<int> UpdateColdCallingControlledZone(UpdateColdCallingControlledZoneRequest request);
        ServiceResult<int> DeleteColdCallingControlledZone(int Id);
    }
}
