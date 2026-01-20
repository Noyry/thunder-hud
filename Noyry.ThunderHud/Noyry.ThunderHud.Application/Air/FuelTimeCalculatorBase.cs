using Noyry.ThunderHud.Domain.Model.Air;
using System.Collections.Concurrent;

namespace Noyry.ThunderHud.Application.Air
{
    public abstract class FuelTimeCalculatorBase : IFuelTimeCalculator
    {
        private readonly ConcurrentQueue<Aircraft> _aircraftStates = new();

        private Aircraft? _currentSavedState;
        private TimeSpan? _lastCalculatedResult;

        protected abstract TimeSpan CalculateFuelResult(float fuelMass, float fuelSpent, TimeSpan timeSpan);
        protected abstract TimeOnly GetTime(Aircraft aircraft);

        private void UpdateFuelResult(TimeSpan timeSpan, Aircraft oldAircraftStateToCompare)
        {
            // we use float fuel value from indicators because of consumption spikes on int values
            var oldFuelMassProperty = oldAircraftStateToCompare?.Indicators?.TotalFuel;
            var fuelMassProperty = _currentSavedState?.Indicators?.TotalFuel;

            if (!(oldFuelMassProperty.HasValue && fuelMassProperty.HasValue))
            {
                return;
            }
            float oldFuelMass = oldFuelMassProperty.Value;
            float fuelMass = fuelMassProperty.Value;
            if (oldFuelMass < fuelMass)
            {
                return;
            }

            float fuelSpent = oldFuelMass - fuelMass;
            if (fuelSpent < 0.0001)
            {
                _lastCalculatedResult = TimeSpan.MaxValue;
                return;
            }

            _lastCalculatedResult = CalculateFuelResult(fuelMass, fuelSpent, timeSpan);
        }

        public TimeSpan? GetFuelTimeLeft(Aircraft aircraft)
        {
            if (_currentSavedState == null)
            {
                _currentSavedState = aircraft;
                _aircraftStates.Clear();
                return default;
            }

            var currentStateTime = GetTime(aircraft);
            var timeDiffernce = currentStateTime - GetTime(_currentSavedState);
            if (timeDiffernce < TimeSpan.Zero)
            {
                _currentSavedState = aircraft;
                _aircraftStates.Clear();
                return default;
            }

            //todo: solve math errors on every second calculations
            //keep last '_oldState' timestamp
            //keep last 5-10 objects of Indicators in some sort of buffer (Queue?)
            //when difference between oldest keep value and current time is equal or greater than target seconds - calculate
            //remove states that I do not need anymore
            if (timeDiffernce.TotalSeconds > 1)
            {
                _aircraftStates.Enqueue(_currentSavedState);
                _currentSavedState = aircraft;
            }

            if (_aircraftStates.TryPeek(out var oldestState))
            {
                var timeSpanForFuelCalculation = (currentStateTime - GetTime(oldestState));
                if (timeSpanForFuelCalculation.TotalSeconds > 2)
                {
                    if (_aircraftStates.TryDequeue(out var stateToCompare) && oldestState == stateToCompare)
                    {
                        UpdateFuelResult(timeSpanForFuelCalculation, stateToCompare);
                    }
                }

            }

            return _lastCalculatedResult;
        }
    }
}
