namespace Noyry.ThunderHud.Domain
{
    public class AircraftIndicators
    {
        public float ExternalFuel { get; set; }

        public float InternalFuel { get; set; }

        public float Speed { get; set; }

        public float TotalFuel => InternalFuel + ExternalFuel;
    }
}
