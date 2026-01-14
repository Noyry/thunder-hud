using Noyry.ThunderHud.Domain;

namespace Noyry.ThunderHud.Application.Aircraft
{
    public interface IAircraftIndicatorService
    {
        Task<AircraftIndicators> GetAircraftIndicatorsAsync(CancellationToken cancellationToken);
    }
}
