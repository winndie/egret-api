using Xunit;
using EgretApi.Services.Geospatial;
using Newtonsoft.Json;
using EgretApi.JsonModels;
using EgretApi.DataAccessLayer;
using Moq;
using EgretApi.DataAccessLayer.Models;
using EgretApi.Tests.Mocks;
using EgretApi.RequestModels;

namespace EgretApi.Tests
{
    public class GeospatialServiceTest
    {
        internal readonly Mock<DatabaseContext> dbContext;
        internal readonly MockRepo<ColdCallingControlledZone> coldCallRepo;
        internal readonly MockRepo<ColdCallingControlledZoneGeometry> geometryRepo;
        internal readonly GeospatialService geoJsonService;

        public GeospatialServiceTest()
        {
            var geometryList = new List<ColdCallingControlledZoneGeometry> {
                new ColdCallingControlledZoneGeometry{ Id=1,ColdCallingControlledZoneID=1,GeometryType=3,
                    Coordinates="[[{\"Latitude\":-0.00,\"Longitude\":0.00},{\"Latitude\":-0.00,\"Longitude\":0.00},{\"Latitude\":-0.00,\"Longitude\":0.00}]]" } };
            var coldCallList = new List<ColdCallingControlledZone> {
                new ColdCallingControlledZone{ Id=1, Geometry = geometryList[0], ObjectId=1,Zones="Zone A",Ward="Ward A"},};

            geometryRepo = new MockRepo<ColdCallingControlledZoneGeometry>(geometryList);
            coldCallRepo = new MockRepo<ColdCallingControlledZone>(coldCallList) ;
            dbContext = new Mock<DatabaseContext>();

            dbContext.Setup(x => x.ColdCallingControlledZones).Returns(coldCallRepo.Object);
            dbContext.Setup(x => x.ColdCallingControlledZoneGeometries).Returns(geometryRepo.Object);
            dbContext.Setup(x => x.Set<ColdCallingControlledZone>()).Returns(coldCallRepo.Object);
            dbContext.Setup(x => x.Set<ColdCallingControlledZoneGeometry>()).Returns(geometryRepo.Object);

            geoJsonService = new GeospatialService(dbContext.Object);
        }

        [Theory]
        [InlineData(true,"Feature", "Polygon")]
        [InlineData(false,"Not Feature", "Polygon")]
        public void CreateColdCallingControlledZone(bool isSuccess, string featureType, string geometryType)
        {
            // Arrange
            var request = JsonConvert.DeserializeObject<CreateColdCallingControlledZoneRequest>(
                "{ \"type\": \"" + featureType + "\", \"properties\": { \"OBJECTID\": 113, \"ZONES\": \"Mendip Close\", \"WARD\": \"Huntington and New Earswick\" }, \"geometry\": { \"type\": \"" + geometryType + "\", \"coordinates\": [ [ [0,0],[0,0],[0,0] ] ] } }");

            // Act
            var result = request != null? geoJsonService.CreateColdCallingControlledZone(request) :null;

            // Assert
            Assert.NotNull(result);

            if (isSuccess)
            {
                Assert.True(result.IsSuccess, "CreateColdCallingControlledZone Success");
                coldCallRepo.Verify(x => x.Add(It.IsAny<ColdCallingControlledZone>()),Times.Once);
            }
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 2)]
        public void GetColdCallingControlledZone(bool isSuccess, int Id)
        {
            // Act
            var result = geoJsonService.GetColdCallingControlledZone(Id);

            // Assert
            Assert.NotNull(result);

            if (isSuccess)
            {
                Assert.True(result.IsSuccess, "GetColdCallingControlledZone Success");
                Assert.NotNull(result.Data);
            }
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 2)]
        public void UpdateColdCallingControlledZone(bool isSuccess, int Id)
        {
            // Arrange
            var request = new UpdateColdCallingControlledZoneRequest 
            {
                Id = Id,
                Ward = "New Ward",
                Zones = "New Zones",
            };

            // Act
            var result = request != null ? geoJsonService.UpdateColdCallingControlledZone(request) : null;

            // Assert
            Assert.NotNull(result);

            if (isSuccess)
            {
                Assert.True(result.IsSuccess, "UpdateColdCallingControlledZone Success");
                Assert.Equal(1, result.Data);
            }
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 2)]
        public void DeleteColdCallingControlledZone(bool isSuccess, int Id)
        {
            // Act
            var result = geoJsonService.DeleteColdCallingControlledZone(Id);

            // Assert
            Assert.NotNull(result);

            if (isSuccess)
            {
                Assert.True(result.IsSuccess, "DeleteColdCallingControlledZone Success");
                coldCallRepo.Verify(x => x.Remove(It.IsAny<ColdCallingControlledZone>()), Times.Once);
            }
        }
    }
}
