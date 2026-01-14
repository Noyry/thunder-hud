using Noyry.ThunderHud.Infrastructure.Game;

namespace Noyry.ThunderHud.UnitTests.Infrastructure
{
    [TestClass]
    public sealed class AircraftIndicatorsTests
    {
        private static string aircraftIndicatorsBody = string.Empty;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // This method is called once for the test class, before any tests of the class are run.
            string aircraftIndicatorsResourceName = "localhost-indicators-aircraft-valid-001.json";

            aircraftIndicatorsBody = TestResources.GetFileContents(aircraftIndicatorsResourceName);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // This method is called once for the test class, after all tests of the class are run.
        }

        [TestInitialize]
        public void TestInit()
        {
            // This method is called before each test method.
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // This method is called after each test method.
        }

        [TestMethod]
        public void TestAicraftIndicatorsValid()
        {
            Assert.IsNotEmpty(aircraftIndicatorsBody);

            var dto = System.Text.Json.JsonSerializer.Deserialize<AircraftIndicatorsDto>(aircraftIndicatorsBody);
            Assert.IsNotNull(dto);
            Assert.AreEqual(123.339272f, dto.Speed, 0.000001f);
        }
    }
}
