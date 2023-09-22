﻿using EgretApi.DataAccessLayer;
using EgretApi.JsonModels;
using EgretApi.Services.GeoJson;
using EgretApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EgretApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoJsonController : ControllerBase
    {
        private readonly IGeoJsonService geoJsonReaderService;

        public GeoJsonController(IGeoJsonService service)
        {
            geoJsonReaderService = service;
        }

        [HttpPost("ColdCallingControlledZone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateColdCallingControlledZone([FromBody] ColdCallingControlledZoneJson json)
        {
            ServiceResult<int> result = geoJsonReaderService.CreateColdCallingControlledZone(json);
            return result.IsSuccess ? Ok(result.Data) : BadRequest();
        }

    }
}
