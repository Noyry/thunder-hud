using Noyry.ThunderHud.Domain.Model.Air;
using System.ComponentModel.DataAnnotations;

namespace Noyry.ThunderHud.Application.Air
{
    public class TimeStampFuelTimeCalculator : FuelTimeCalculatorBase
    {
        protected override TimeSpan CalculateFuelResult(float currentFuelMass, float fuelSpent, TimeSpan timeSpan)
        {
            double fuelConsumption = timeSpan.TotalSeconds / fuelSpent;
            double totalSecondsLeft = currentFuelMass * fuelConsumption;
            if (totalSecondsLeft > int.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            return TimeSpan.FromSeconds(totalSecondsLeft);
        }

        protected override TimeOnly GetTime(Aircraft aircraft) => TimeOnly.FromDateTime(aircraft.Indicators.Timestamp.UtcDateTime);
    }
}
