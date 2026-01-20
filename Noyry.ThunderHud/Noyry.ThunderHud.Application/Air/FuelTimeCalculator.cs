using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application.Air
{
    public class FuelTimeCalculator : FuelTimeCalculatorBase
    {
        protected override TimeSpan CalculateFuelResult(float currentFuelMass, float fuelSpent, TimeSpan timeSpan)
        {
            double totalSeconds = timeSpan.TotalSeconds;
            double totalSecondsLeft = currentFuelMass * totalSeconds / fuelSpent;
            if (totalSecondsLeft > int.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

             return TimeSpan.FromSeconds(totalSecondsLeft);
        }

        protected override TimeOnly GetTime(Aircraft aircraft)
        {
            var aircraftIndicators = aircraft.Indicators;
            var result = new TimeOnly(0, aircraftIndicators.ClockMinutes, aircraftIndicators.ClockSeconds);
            return result;
        }
    }
}
