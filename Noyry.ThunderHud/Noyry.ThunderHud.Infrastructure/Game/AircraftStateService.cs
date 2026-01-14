using Microsoft.Extensions.Configuration;
using Noyry.ThunderHud.Application.Aircraft;
using Noyry.ThunderHud.Domain;
using Noyry.ThunderHud.Infrastructure.Game.YourNamespace.Dtos;
using System.Text.Json;

namespace Noyry.ThunderHud.Infrastructure.Game
{
    public class AircraftStateService : IAircraftStateService
    {
        public AircraftStateService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public async Task<AircraftState> GetAircraftStateAsync(CancellationToken cancellationToken)
        {
            string serviceAddress = _configuration["GameReaderApp:GameInfoSourceAddress"] ?? throw new Exception("Game Service Address is missing");
            string indicatorsSubAddress = _configuration["GameReaderApp:StateSubAddress"] ?? throw new Exception("State SubAddress is missing");
            string totalAddress = $"{serviceAddress}/{indicatorsSubAddress}";
            string responseBody = await _httpClient.GetStringAsync(totalAddress, cancellationToken);
            if (responseBody != null)
            {
                var dto = JsonSerializer.Deserialize<AircraftStateDto>(responseBody);
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
