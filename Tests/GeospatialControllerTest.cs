using EgretApi.Controllers;
using EgretApi.JsonModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;

namespace EgretApi.Tests
{
    public class GeospatialControllerTest : GeospatialServiceTest
    {
        internal readonly GeospatialController controller;

        public GeospatialControllerTest() : base()
        {
            controller = new GeospatialController(this.geoJsonService);
        }

        [Theory]
        [InlineData(StatusCodes.Status200OK, "Feature", "Polygon")]
        [InlineData(StatusCodes.Status400BadRequest, "Not Feature", "Not Polygon")]
        public void CreateColdCallingControlledZone_Controller(int returnType, string featureType, string geometryType)
        {
            // Arrange
            var json = JsonConvert.DeserializeObject<CreateColdCallingControlledZoneRequest>(
                "{ \"type\": \""+ featureType + "\", \"properties\": { \"OBJECTID\": 113, \"ZONES\": \"Mendip Close\", \"WARD\": \"Huntington and New Earswick\" }, \"geometry\": { \"type\": \"" + geometryType + "\", \"coordinates\": [ [ [0,0],[0,0],[0,0] ] ] } }");

            // Act
            var result = json != null? controller.CreateColdCallingControlledZone(json):null;

            // Assert
            Assert.NotNull(result);            
            var objResult = CheckReturnType(result, returnType);

            if (returnType == 200)
            {
                Assert.NotNull(objResult);
                Assert.Equal(0, objResult.Value);
            }
        }

        private OkObjectResult? CheckReturnType(IActionResult result ,int returnType)
        {
            switch (returnType)
            {
                case 200:
                    Assert.IsType<OkObjectResult>(result);
                    return result as OkObjectResult;
                case 400:
                    Assert.IsType<BadRequestResult>(result);
                    return null;
                default:
                    Assert.Fail();
                    return null;
            }
        }
    }
}
