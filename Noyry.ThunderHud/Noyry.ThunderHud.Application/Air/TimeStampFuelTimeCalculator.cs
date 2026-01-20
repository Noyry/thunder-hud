using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application.Air
{
    public class TimeStampFuelTimeCalculator : FuelTimeCalculatorBase
    {
        protected override TimeSpan CalculateFuelResult(float currentFuelMass, float fuelSpent, TimeSpan timeSpan)
        {
            double fuelConsumption = timeSpan.TotalSeconds / fuelSpent;
            double totalMilisecondsLeft = currentFuelMass * fuelConsumption;
            if (totalMilisecondsLeft > int.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            return TimeSpan.FromSeconds(totalMilisecondsLeft);
        }

        protected override TimeOnly GetTime(Aircraft aircraft)
        {
            var result = new TimeOnly(0, aircraft.TimeStamp.Minute, aircraft.TimeStamp.Second, aircraft.TimeStamp.Millisecond);
            result = TimeOnly.FromDateTime(aircraft.TimeStamp.UtcDateTime);
            return result;
        }
    }
}
