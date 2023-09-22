using Xunit;
using EgretApi.Services.GeoJson;
using Newtonsoft.Json;
using EgretApi.JsonModels;
using EgretApi.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace EgretApi.Tests
{
    public class GeoJsonServiceTest
    {

        [Theory]
        [InlineData(true,"Feature", "Polygon")]
        [InlineData(false,"Not Feature", "Polygon")]
        public void CreateColdCallingControlledZone(bool isSuccess, string featureType, string geometryType)
        {
            // Arrange
            var json = JsonConvert.DeserializeObject<ColdCallingControlledZoneJson>(
                "{ \"type\": \"" + featureType + "\", \"properties\": { \"OBJECTID\": 113, \"ZONES\": \"Mendip Close\", \"WARD\": \"Huntington and New Earswick\" }, \"geometry\": { \"type\": \"" + geometryType + "\", \"coordinates\": [ [ [0,0],[0,0],[0,0] ] ] } }");

            var service = new GeoJsonService(new GeospatialContext(new DbContextOptions<GeospatialContext>()));

            // Act
            var result = json != null? service.CreateColdCallingControlledZone(json):null;

            // Assert
            Assert.NotNull(result);

            if (isSuccess)
            {
                Assert.True(result.IsSuccess, "CreateColdCallingControlledZone Success");
                Assert.Equal(113, result.Data);
            }
        }
    }
}
