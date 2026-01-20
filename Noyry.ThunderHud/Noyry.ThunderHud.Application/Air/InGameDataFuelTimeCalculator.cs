using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application.Air
{
    public class InGameDataFuelTimeCalculator : IFuelTimeCalculator
    {
        public TimeSpan? GetFuelTimeLeft(Aircraft aircraft)
        {
            float fuelLevel = aircraft.Indicators.TotalFuel;
            if (fuelLevel < 0.0001)
            {
                return TimeSpan.Zero;
            }

            if (!aircraft.Indicators.FuelConsumption.HasValue)
            {
                return null;
            }

            float consumption = aircraft.Indicators.FuelConsumption.Value;
            if (consumption < 0.0001)
            {
                return TimeSpan.MaxValue;
            }

            var secondsLeft = fuelLevel / consumption;
            var result = TimeSpan.FromMinutes(secondsLeft);
            return result;

        }
    }
}
