namespace Noyry.ThunderHud.Domain.Model.Air
{
    public class AircraftState
    {
        public int IndicatedSpeedKmPerHour { get; set; }
        public int TrueAirspeedKmPerHour { get; set; }
        public int AbsoluteHeightMeters { get; set; }
        public int FuelMassKg {  get; set; }
    }
}
