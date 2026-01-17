using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Noyry.ThunderHud.Application.Aircraft;

namespace Noyry.ThunderHud.Application
{
    public class GameReaderApp
    {
        public GameReaderApp(IHostEnvironment environment, ILogger<GameReaderApp> logger, IAircraftStateService aircraftStateService)
        {
            _environment = environment;
            _logger = logger;
            _aircraftStateService = aircraftStateService;
        }

        private readonly IHostEnvironment _environment;
        private readonly ILogger _logger;
        private readonly IAircraftStateService _aircraftStateService;

        private async Task ReadGameIndicators(CancellationToken cancellationToken)
        {
            var delay = TimeSpan.FromMilliseconds(200);

            while (!cancellationToken.IsCancellationRequested)
            {
                var dto = await _aircraftStateService.GetAircraftStateAsync(cancellationToken);
                if (dto != null)
                {
                    Console.Clear();
                    Console.WriteLine($"Speed: {dto.SpeedKmPerHour} km\\h");
                    Console.WriteLine($"Timestamp: {DateTime.Now.ToString("HH:mm:ss:fff")}");
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
