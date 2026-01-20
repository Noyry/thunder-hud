using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Noyry.ThunderHud.Application.Air;
using Noyry.ThunderHud.Application.Common;
using Noyry.ThunderHud.Application.UserInterface;
using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application
{
    public class GameReaderApp
    {
        public GameReaderApp(
            IHostEnvironment environment,
            ILogger<GameReaderApp> logger,
            IAircraftStateService aircraftStateService,
            IAircraftIndicatorService aircraftIndicatorService,
            IRenderer<Aircraft> renderer,
            IFuelTimeCalculator fuelTimeCalculator,
            IDateTimeProvider dateTimeProvider)
        {
            _environment = environment;
            _logger = logger;
            _aircraftStateService = aircraftStateService;
            _aircraftIndicatorService = aircraftIndicatorService;
            _renderer = renderer;
            _fuelTimeCalculator = fuelTimeCalculator;
            _dateTimeProvider = dateTimeProvider;
        }

        private readonly IHostEnvironment _environment;
        private readonly ILogger _logger;
        private readonly IAircraftStateService _aircraftStateService;
        private readonly IAircraftIndicatorService _aircraftIndicatorService;
        private readonly IRenderer<Aircraft> _renderer;
        private readonly IFuelTimeCalculator _fuelTimeCalculator;
        private readonly IDateTimeProvider _dateTimeProvider;

        private async Task ReadGameIndicators(CancellationToken cancellationToken)
        {
            var delay = TimeSpan.FromMilliseconds(200);
            Console.CursorVisible = false;

            while (!cancellationToken.IsCancellationRequested)
            {
                var stateTask = _aircraftStateService.GetAircraftStateAsync(cancellationToken);
                var indicatorsTask = _aircraftIndicatorService.GetAircraftIndicatorsAsync(cancellationToken);
                await Task.WhenAll(stateTask, indicatorsTask);
                var state = stateTask.Result;
                var indicators = indicatorsTask.Result;

                if (state != null && indicators != null)
                {
                    var aircraft = new Aircraft(
                        indicators.Name,
                        indicators,
                        state,
                        new AircraftStaticInfo(),
                        _dateTimeProvider.GetTime());

                    var fuelLeft = _fuelTimeCalculator.GetFuelTimeLeft(aircraft);
                    aircraft.CalculatedInfo = new AircraftCalculatedInfo
                    {
                        FuelLeft = fuelLeft
                    };

                    await _renderer.Render(aircraft, cancellationToken);
                }
                await Task.Delay(delay, cancellationToken);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return ReadGameIndicators(cancellationToken);
        }
    }
}
