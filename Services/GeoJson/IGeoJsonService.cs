using EgretApi.JsonModels;
using EgretApi.Utilities;

namespace EgretApi.Services.GeoJson
{
    public interface IGeoJsonService
    {
        ServiceResult<int> CreateColdCallingControlledZone(ColdCallingControlledZoneJson json);
    }
}
