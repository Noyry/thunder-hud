using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Noyry.ThunderHud.Application.Air;
using Noyry.ThunderHud.Application.Interface;
using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application
{
    public class GameReaderApp
    {
        public GameReaderApp(
            IHostEnvironment environment,
            ILogger<GameReaderApp> logger,
            IAircraftStateService aircraftStateService,
            IRenderer<Aircraft> renderer)
        {
            _environment = environment;
            _logger = logger;
            _aircraftStateService = aircraftStateService;
            _renderer = renderer;
        }

        private readonly IHostEnvironment _environment;
        private readonly ILogger _logger;
        private readonly IAircraftStateService _aircraftStateService;
        private readonly IRenderer<Aircraft> _renderer;

        private async Task ReadGameIndicators(CancellationToken cancellationToken)
        {
            var delay = TimeSpan.FromMilliseconds(200);
            Console.CursorVisible = false;

            while (!cancellationToken.IsCancellationRequested)
            {
                var dto = await _aircraftStateService.GetAircraftStateAsync(cancellationToken);
                if (dto != null)
                {
                    var aircraft = new Aircraft(
                        "name",
                        new AircraftIndicators(),
                        dto,
                        new AircraftStaticInfo());
                    
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
