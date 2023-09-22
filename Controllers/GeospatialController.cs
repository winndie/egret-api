using EgretApi.JsonModels;
using EgretApi.Models.Geospatial;
using EgretApi.RequestModels;
using EgretApi.Services.Geospatial;
using EgretApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EgretApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeospatialController : ControllerBase
    {
        private readonly IGeospatialService geoJsonReaderService;

        public GeospatialController(IGeospatialService service)
        {
            geoJsonReaderService = service;
        }

        [HttpGet("ColdCallingControlledZone/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ColdCallingControlledZoneDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetColdCallingControlledZone(int Id)
        {
            ServiceResult<ColdCallingControlledZoneDto> result = geoJsonReaderService.GetColdCallingControlledZone(Id);
            return result.IsSuccess ? Ok(result.Data) : NotFound();
        }

        [HttpPost("ColdCallingControlledZone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateColdCallingControlledZone([FromBody] CreateColdCallingControlledZoneRequest request)
        {
            ServiceResult<int> result = geoJsonReaderService.CreateColdCallingControlledZone(request);
            return result.IsSuccess ? Ok(result.Data) : BadRequest();
        }

        [HttpPut("ColdCallingControlledZone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateColdCallingControlledZone([FromBody] UpdateColdCallingControlledZoneRequest request)
        {
            ServiceResult<int> result = geoJsonReaderService.UpdateColdCallingControlledZone(request);
            return result.IsSuccess ? Ok(result.Data) : BadRequest();
        }

        [HttpDelete("ColdCallingControlledZone/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteColdCallingControlledZone(int Id)
        {
            ServiceResult<int> result = geoJsonReaderService.DeleteColdCallingControlledZone(Id);
            return result.IsSuccess ? Ok(result.Data) : NotFound();
        }

    }
}
