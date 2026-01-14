using Noyry.ThunderHud.Infrastructure.Game;
using Noyry.ThunderHud.Infrastructure.Game.YourNamespace.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noyry.ThunderHud.UnitTests.Infrastructure
{
    [TestClass]
    public sealed class AircraftStateTests
    {
        private static string aircraftStateBody = string.Empty;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // This method is called once for the test class, before any tests of the class are run.
            string aircraftStateResourceName = "localhost-state-aircraft-valid-001.json";

            aircraftStateBody = TestResources.GetFileContents(aircraftStateResourceName);
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
        public void TestMethod1()
        {
            Assert.IsNotEmpty(aircraftStateBody);

            var dto = System.Text.Json.JsonSerializer.Deserialize<AircraftStateDto>(aircraftStateBody);
            Assert.IsNotNull(dto);
            Assert.AreEqual(383, dto.IndicatedAirspeedKmPerHour);
        }
    }
}
