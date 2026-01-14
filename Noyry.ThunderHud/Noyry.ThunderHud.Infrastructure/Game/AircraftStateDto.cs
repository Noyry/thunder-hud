using System.Text.Json.Serialization;

namespace Noyry.ThunderHud.Infrastructure.Game
{
    namespace YourNamespace.Dtos
    {
        [JsonSerializable(typeof(AircraftStateDto))]
        public class AircraftStateDto
        {
            [JsonPropertyName("valid")]
            public bool Valid { get; set; }

            [JsonPropertyName("aileron, %")]
            public int AileronPercent { get; set; }

            [JsonPropertyName("elevator, %")]
            public int ElevatorPercent { get; set; }

            [JsonPropertyName("rudder, %")]
            public int RudderPercent { get; set; }

            [JsonPropertyName("flaps, %")]
            public int FlapsPercent { get; set; }

            [JsonPropertyName("gear, %")]
            public int GearPercent { get; set; }

            [JsonPropertyName("airbrake, %")]
            public int AirbrakePercent { get; set; }

            [JsonPropertyName("H, m")]
            public int HeightMeters { get; set; }

            [JsonPropertyName("TAS, km/h")]
            public int TrueAirspeedKmPerHour { get; set; }

            [JsonPropertyName("IAS, km/h")]
            public int IndicatedAirspeedKmPerHour { get; set; }

            [JsonPropertyName("M")]
            public float Mach { get; set; }

            [JsonPropertyName("AoA, deg")]
            public float AngleOfAttackDegrees { get; set; }

            [JsonPropertyName("AoS, deg")]
            public float AngleOfSideslipDegrees { get; set; }

            [JsonPropertyName("Ny")]
            public float NormalLoadFactor { get; set; }

            [JsonPropertyName("Vy, m/s")]
            public float VerticalVelocityMetersPerSecond { get; set; }

            //todo: check if it's float or int
            [JsonPropertyName("Wx, deg/s")]
            public float RollRateDegreesPerSecond { get; set; }

            [JsonPropertyName("Mfuel, kg")]
            public int FuelMassKg { get; set; }

            //todo: is it full tank capacity?
            [JsonPropertyName("Mfuel0, kg")]
            public int InitialFuelMassKg { get; set; }

            [JsonPropertyName("throttle 1, %")]
            public int Throttle1Percent { get; set; }

            [JsonPropertyName("power 1, hp")]
            public float Power1Horsepower { get; set; }

            [JsonPropertyName("RPM 1")]
            public int Rpm1 { get; set; }

            [JsonPropertyName("manifold pressure 1, atm")]
            public float ManifoldPressure1Atm { get; set; }

            [JsonPropertyName("oil temp 1, C")]
            public int OilTemperature1Celsius { get; set; }

            [JsonPropertyName("thrust 1, kgs")]
            public int Thrust1Kilograms { get; set; }

            [JsonPropertyName("efficiency 1, %")]
            public int Efficiency1Percent { get; set; }

            [JsonPropertyName("throttle 2, %")]
            public int Throttle2Percent { get; set; }

            [JsonPropertyName("power 2, hp")]
            public float Power2Horsepower { get; set; }

            [JsonPropertyName("RPM 2")]
            public int Rpm2 { get; set; }

            [JsonPropertyName("manifold pressure 2, atm")]
            public float ManifoldPressure2Atm { get; set; }

            [JsonPropertyName("oil temp 2, C")]
            public int OilTemperature2Celsius { get; set; }

            [JsonPropertyName("thrust 2, kgs")]
            public int Thrust2Kilograms { get; set; }

            [JsonPropertyName("efficiency 2, %")]
            public int Efficiency2Percent { get; set; }
        }
    }
}
