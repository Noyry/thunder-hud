using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application.Air
{
    internal class FuelTimeCalculator
    {
        private Aircraft? _currentSavedState;
        private Aircraft? _stateMinusOne;
        private TimeSpan? _lastCalculatedResult;

        private static TimeOnly GetTime(AircraftIndicators aircraftIndicators)
        {
            var result = new TimeOnly(0, aircraftIndicators.ClockMinutes, aircraftIndicators.ClockSeconds);
            return result;
        }

        private void UpdateFuelResult(TimeSpan timeSpan)
        {
            var oldFuelMassProperty = _stateMinusOne?.State?.FuelMassKg;
            var fuelMassProperty = _currentSavedState?.State?.FuelMassKg;

            if (!(oldFuelMassProperty.HasValue && fuelMassProperty.HasValue))
            {
                return;
            }
            int oldFuelMass = oldFuelMassProperty.Value;
            int fuelMass = fuelMassProperty.Value;
            if (oldFuelMass < fuelMass)
            {
                return;
            }

            int fuelSpent = oldFuelMass - fuelMass;
            if (fuelSpent == 0)
            {
                _lastCalculatedResult = TimeSpan.MaxValue;
                return;
            }

            double totalSecondsLeft = fuelMass * timeSpan.TotalSeconds / fuelSpent;
            if (totalSecondsLeft > int.MaxValue)
            {
                _lastCalculatedResult = TimeSpan.MaxValue;
                return;
            }

            _lastCalculatedResult = TimeSpan.FromSeconds(totalSecondsLeft);
        }

        public TimeSpan? GetFuelTimeLeft(Aircraft aircraft)
        {
            if (_currentSavedState == null)
            {
                _currentSavedState = aircraft;
                return default;
            }

            var timeDiffernce = GetTime(aircraft.Indicators) - GetTime(_currentSavedState.Indicators);
            if (timeDiffernce < TimeSpan.Zero)
            {
                _currentSavedState = aircraft;
                _stateMinusOne = null;
                return default;
            }

            //todo: solve math errors on every second calculations
            //keep last '_oldState' timestamp
            //keep last 5-10 objects of Indicators in some sort of buffer (Queue?)
            //when difference between oldest keep value and current time is equal or greater than target seconds - calculate
            //remove states that I do not need anymore
            if (timeDiffernce.TotalSeconds > 4)
            {
                _stateMinusOne = _currentSavedState;
                _currentSavedState = aircraft;
                UpdateFuelResult(timeDiffernce);
            }
            
            return _lastCalculatedResult;
        }
    }
}
