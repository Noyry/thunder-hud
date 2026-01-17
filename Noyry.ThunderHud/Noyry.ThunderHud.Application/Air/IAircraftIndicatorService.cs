using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application.Air
{
    public interface IAircraftIndicatorService
    {
        Task<AircraftIndicators> GetAircraftIndicatorsAsync(CancellationToken cancellationToken);
    }
}
