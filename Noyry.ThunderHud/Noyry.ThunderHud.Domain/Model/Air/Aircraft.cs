using Noyry.ThunderHud.Domain.Model.Abstract;

namespace Noyry.ThunderHud.Domain.Model.Air
{
    public class Aircraft : IVehicle
    {
        public Aircraft(
            string name,
            AircraftIndicators indicators,
            AircraftState state,
            AircraftStaticInfo staticInfo,
            DateTimeOffset timeStamp)
        {
            Name = name;
            Indicators = indicators;
            State = state;
            StaticInfo = staticInfo;
            Timestamp = timeStamp;
        }

        public string Name { get; set; }

        public AircraftIndicators Indicators { get; set; }

        public AircraftState State { get; set; }

        public AircraftStaticInfo StaticInfo { get; set; }

        public AircraftCalculatedInfo? CalculatedInfo { get; set; }

        public DateTimeOffset Timestamp {  get; }
    }
}
