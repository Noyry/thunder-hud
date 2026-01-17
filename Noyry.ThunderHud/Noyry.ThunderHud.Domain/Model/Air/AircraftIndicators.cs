namespace Noyry.ThunderHud.Domain.Model.Air
{
    public class AircraftIndicators
    {
        public float ExternalFuel { get; set; }

        public float InternalFuel { get; set; }

        public float Speed { get; set; }

        public float TotalFuel => InternalFuel + ExternalFuel;
    }
}
