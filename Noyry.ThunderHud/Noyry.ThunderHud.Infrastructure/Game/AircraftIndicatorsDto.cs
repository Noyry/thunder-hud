using System.Text.Json.Serialization;

namespace Noyry.ThunderHud.Infrastructure.Game
{
    [JsonSerializable(typeof(AircraftIndicatorsDto))]
    public class AircraftIndicatorsDto
    {
        [JsonPropertyName("valid")]
        public bool Valid { get; set; }

        [JsonPropertyName("army")]
        public string Army { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("pedals")]
        public float Pedals { get; set; }

        [JsonPropertyName("pedals1")]
        public float Pedals1 { get; set; }

        [JsonPropertyName("pedals2")]
        public float Pedals2 { get; set; }

        [JsonPropertyName("pedals3")]
        public float Pedals3 { get; set; }

        [JsonPropertyName("pedals4")]
        public float Pedals4 { get; set; }

        [JsonPropertyName("pedals5")]
        public float Pedals5 { get; set; }

        [JsonPropertyName("pedals6")]
        public float Pedals6 { get; set; }

        [JsonPropertyName("pedals7")]
        public float Pedals7 { get; set; }

        [JsonPropertyName("pedals8")]
        public float Pedals8 { get; set; }

        [JsonPropertyName("stick_elevator")]
        public float StickElevator { get; set; }

        [JsonPropertyName("stick_ailerons")]
        public float StickAilerons { get; set; }

        [JsonPropertyName("vario")]
        public float Vario { get; set; }

        [JsonPropertyName("altitude_hour")]
        public float AltitudeHour { get; set; }

        [JsonPropertyName("altitude_min")]
        public float AltitudeMin { get; set; }

        [JsonPropertyName("altitude_10k")]
        public float Altitude10k { get; set; }

        [JsonPropertyName("altitude1_hour")]
        public float Altitude1Hour { get; set; }

        [JsonPropertyName("altitude1_10k")]
        public float Altitude110k { get; set; }

        [JsonPropertyName("aviahorizon_roll")]
        public float AviahorizonRoll { get; set; }

        [JsonPropertyName("aviahorizon_pitch")]
        public float AviahorizonPitch { get; set; }

        [JsonPropertyName("bank")]
        public float Bank { get; set; }

        [JsonPropertyName("compass")]
        public float Compass { get; set; }

        [JsonPropertyName("compass1")]
        public float Compass1 { get; set; }

        [JsonPropertyName("clock_hour")]
        public float ClockHour { get; set; }

        [JsonPropertyName("clock_min")]
        public float ClockMin { get; set; }

        [JsonPropertyName("clock_sec")]
        public float ClockSec { get; set; }

        [JsonPropertyName("rpm")]
        public float Rpm { get; set; }

        [JsonPropertyName("rpm1")]
        public float Rpm1 { get; set; }

        [JsonPropertyName("water_temperature")]
        public float WaterTemperature { get; set; }

        [JsonPropertyName("water_temperature1")]
        public float WaterTemperature1 { get; set; }

        [JsonPropertyName("water_temperature_min")]
        public float WaterTemperatureMin { get; set; }

        [JsonPropertyName("water_temperature1_min")]
        public float WaterTemperature1Min { get; set; }

        [JsonPropertyName("fuel")]
        public float Fuel { get; set; }

        [JsonPropertyName("fuel1")]
        public float Fuel1 { get; set; }

        [JsonPropertyName("fuel2")]
        public float Fuel2 { get; set; }

        [JsonPropertyName("airbrake_lever")]
        public float AirbrakeLever { get; set; }

        [JsonPropertyName("airbrake_indicator")]
        public float AirbrakeIndicator { get; set; }

        [JsonPropertyName("gears")]
        public float Gears { get; set; }

        [JsonPropertyName("gear_lamp_down")]
        public float GearLampDown { get; set; }

        [JsonPropertyName("gear_lamp_up")]
        public float GearLampUp { get; set; }

        [JsonPropertyName("gear_lamp_off")]
        public float GearLampOff { get; set; }

        [JsonPropertyName("flaps")]
        public float Flaps { get; set; }

        [JsonPropertyName("flaps1")]
        public float Flaps1 { get; set; }

        [JsonPropertyName("throttle")]
        public float Throttle { get; set; }

        [JsonPropertyName("throttle1")]
        public float Throttle1 { get; set; }

        [JsonPropertyName("weapon2")]
        public float Weapon2 { get; set; }

        [JsonPropertyName("weapon4")]
        public float Weapon4 { get; set; }

        [JsonPropertyName("flaps_indicator")]
        public float FlapsIndicator { get; set; }

        [JsonPropertyName("flaps_indicator1")]
        public float FlapsIndicator1 { get; set; }

        [JsonPropertyName("mach")]
        public float Mach { get; set; }

        [JsonPropertyName("g_meter")]
        public float GMeter { get; set; }

        [JsonPropertyName("g_meter_max")]
        public float GMeterMax { get; set; }

        [JsonPropertyName("aoa")]
        public float Aoa { get; set; }

        [JsonPropertyName("blister1")]
        public float Blister1 { get; set; }

        [JsonPropertyName("blister2")]
        public float Blister2 { get; set; }

        [JsonPropertyName("blister3")]
        public float Blister3 { get; set; }

        [JsonPropertyName("blister4")]
        public float Blister4 { get; set; }

        [JsonPropertyName("blister5")]
        public float Blister5 { get; set; }

        [JsonPropertyName("blister6")]
        public float Blister6 { get; set; }

        [JsonPropertyName("blister11")]
        public float Blister11 { get; set; }

        [JsonPropertyName("fuel_consume")]
        public float? FuelConsumption { get; set; }

        [JsonPropertyName("radio_altitude")]
        public float? RadioAltitude { get; set; }
    }
}
