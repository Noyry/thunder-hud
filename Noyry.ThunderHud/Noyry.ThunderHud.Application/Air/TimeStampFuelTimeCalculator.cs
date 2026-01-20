using Noyry.ThunderHud.Domain.Model.Air;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noyry.ThunderHud.Application.Air
{
    public class TimeStampFuelTimeCalculator : IFuelTimeCalculator
    {
        private Aircraft? _currentSavedState;
        private Aircraft? _stateMinusOne;
        private TimeSpan? _lastCalculatedResult;

        private static TimeOnly GetTime(Aircraft aircraft)
        {
            var result = new TimeOnly(0, aircraft.TimeStamp.Minute, aircraft.TimeStamp.Second, aircraft.TimeStamp.Millisecond);
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

            int totalSeconds = timeSpan.Minutes * 60 + timeSpan.Seconds;
            // todo: we can use multiply and division by 1024 here %)
            int totalMiliseconds = totalSeconds * 1000 + timeSpan.Milliseconds;
            long totalSecondsLeft = fuelMass * totalMiliseconds / (fuelSpent * 1000);
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

            var timeDiffernce = GetTime(aircraft) - GetTime(_currentSavedState);
            if (timeDiffernce < TimeSpan.Zero)
            {
                _currentSavedState = aircraft;
                _stateMinusOne = null;
                return default;
            }

            //todo: looks like need base class for this one and FuelTimeCalculator
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
