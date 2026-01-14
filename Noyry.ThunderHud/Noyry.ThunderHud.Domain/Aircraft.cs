namespace Noyry.ThunderHud.Domain
{
    public class Aircraft
    {
        public Aircraft(
            string name,
            AircraftIndicators indicators,
            AircraftState state,
            AircraftStaticInfo staticInfo)
        {
            Name = name;
            Indiators = indicators;
            State = state;
            StaticInfo = staticInfo;
        }

        public string Name { get; set; }

        public AircraftIndicators Indiators { get; set; }

        public AircraftState State { get; set; }

        public AircraftStaticInfo StaticInfo { get; set; }
    }
}
