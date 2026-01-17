using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Noyry.ThunderHud.Application.Air;
using Noyry.ThunderHud.Domain.Model.Air;
using Noyry.ThunderHud.Infrastructure.Game.YourNamespace.Dtos;
using System.Text.Json;

namespace Noyry.ThunderHud.Infrastructure.Game
{
    public class AircraftStateService : IAircraftStateService
    {
        public AircraftStateService(IConfiguration configuration, HttpClient httpClient, ILogger<AircraftStateService> logger)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _logger = logger;
        }

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<AircraftStateService> _logger;

        public async Task<AircraftState> GetAircraftStateAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            string serviceAddress = _configuration["GameReaderApp:GameInfoSourceAddress"] ?? throw new Exception("Game Service Address is missing");
            string indicatorsSubAddress = _configuration["GameReaderApp:StateSubAddress"] ?? throw new Exception("State SubAddress is missing");
            string totalAddress = $"{serviceAddress}/{indicatorsSubAddress}";
            var configRead = DateTime.UtcNow;
            var cofigurationReadTime = configRead - now;

            _logger.LogTrace("Config reading time {time}", cofigurationReadTime);
            
            now = DateTime.UtcNow;
            string responseBody = await _httpClient.GetStringAsync(totalAddress, cancellationToken);
            var responseGot = DateTime.UtcNow;
            var responseReadTime = responseGot - now;

            _logger.LogTrace("Localhost response time {time}", responseReadTime);

            if (responseBody != null)
            {
                now = DateTime.UtcNow;
                var dto = JsonSerializer.Deserialize<AircraftStateDto>(responseBody);
                var deserialization = DateTime.UtcNow;
                var deserializationTime = deserialization - now;

                _logger.LogTrace("Deserialization response time {time}", deserializationTime);

                if (dto != null)
                {
                    AircraftState result = new()
                    {
                        SpeedKmPerHour = dto.IndicatedAirspeedKmPerHour
                    };
                    return result;
                }
            }

            throw new Exception("Failed to deserialize Aircraft State");
        }
    }
}
