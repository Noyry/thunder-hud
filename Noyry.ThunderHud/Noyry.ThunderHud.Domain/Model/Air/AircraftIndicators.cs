namespace Noyry.ThunderHud.Domain.Model.Air
{
    public class AircraftIndicators(string name)
    {
        public string Name { get; set; } = name;

        public float ExternalFuel { get; set; }

        public float InternalFuel { get; set; }

        public float Speed { get; set; }

        public int ClockMinutes { get; set; }

        public int ClockSeconds {  get; set; }

        public float TotalFuel => InternalFuel + ExternalFuel;

        public float? FuelConsumption { get; set; }
    }
}
