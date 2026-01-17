using Microsoft.Extensions.Configuration;
using Noyry.ThunderHud.Application.Air;
using Noyry.ThunderHud.Domain.Model.Air;
using System.Text.Json;

namespace Noyry.ThunderHud.Infrastructure.Game
{
    public class AircraftIndicatorsService : IAircraftIndicatorService
    {
        public AircraftIndicatorsService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public async Task<AircraftIndicators> GetAircraftIndicatorsAsync(CancellationToken cancellationToken)
        {
            string serviceAddress = _configuration["GameReaderApp:GameInfoSourceAddress"] ?? throw new Exception("Game Service Address is missing");
            string indicatorsSubAddress = _configuration["GameReaderApp:IndicatorsSubAddress"] ?? throw new Exception("Indicators SubAddress is missing");
            string totalAddress = $"{serviceAddress}/{indicatorsSubAddress}";
            string responseBody = await _httpClient.GetStringAsync(totalAddress, cancellationToken);

            if (responseBody != null)
            {
                var dto = JsonSerializer.Deserialize<AircraftIndicatorsDto>(responseBody);
                if (dto != null)
                {
                    AircraftIndicators result = new()
                    {
                        Speed = dto.Speed
                    };
                    return result;
                }
            }

            throw new Exception("Failed to deserialize Aircraft Indicators");
        }
    }
}
