using Xunit;
using EgretApi.Services.GeoJson;
using Newtonsoft.Json;
using EgretApi.JsonModels;
using EgretApi.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Moq;
using EgretApi.DataAccessLayer.Models;

namespace EgretApi.Tests
{
    public class GeoJsonServiceTest
    {
        internal readonly Mock<GeospatialContext> dbContext;
        internal readonly Mock<DbSet<ColdCallingControlledZone>> coldCallRepo;
        internal readonly Mock<DbSet<ColdCallingControlledZoneGeometry>> geometryRepo;
        internal readonly GeoJsonService geoJsonService;

        public GeoJsonServiceTest()
        {
            dbContext = new Mock<GeospatialContext>();
            coldCallRepo = new Mock<DbSet<ColdCallingControlledZone>>();
            geometryRepo = new Mock<DbSet<ColdCallingControlledZoneGeometry>>();

            dbContext.Setup(x => x.Set<ColdCallingControlledZone>()).Returns(coldCallRepo.Object);
            dbContext.Setup(x => x.Set<ColdCallingControlledZoneGeometry>()).Returns(geometryRepo.Object);

            geoJsonService = new GeoJsonService(dbContext.Object);
        }

        [Theory]
        [InlineData(true,"Feature", "Polygon")]
        [InlineData(false,"Not Feature", "Polygon")]
        public void CreateColdCallingControlledZone(bool isSuccess, string featureType, string geometryType)
        {
            // Arrange
            var json = JsonConvert.DeserializeObject<ColdCallingControlledZoneJson>(
                "{ \"type\": \"" + featureType + "\", \"properties\": { \"OBJECTID\": 113, \"ZONES\": \"Mendip Close\", \"WARD\": \"Huntington and New Earswick\" }, \"geometry\": { \"type\": \"" + geometryType + "\", \"coordinates\": [ [ [0,0],[0,0],[0,0] ] ] } }");

            // Act
            var result = json != null? geoJsonService.CreateColdCallingControlledZone(json):null;

            // Assert
            Assert.NotNull(result);

            if (isSuccess)
            {
                Assert.True(result.IsSuccess, "CreateColdCallingControlledZone Success");
                Assert.Equal(0, result.Data);
            }
        }
    }
}
