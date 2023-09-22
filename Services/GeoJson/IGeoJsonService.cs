using EgretApi.JsonModels;
using EgretApi.Models.GeoJson;
using EgretApi.Utilities;

namespace EgretApi.Services.GeoJson
{
    public interface IGeoJsonService
    {
        ServiceResult<int> CreateColdCallingControlledZone(ColdCallingControlledZoneJson json);
        ServiceResult<ColdCallingControlledZoneDto> GetColdCallingControlledZone(int Id);
    }
}
