using Noyry.ThunderHud.Domain;

namespace Noyry.ThunderHud.Application.Aircraft
{
    public interface IAircraftStateService
    {
        Task<AircraftState> GetAircraftStateAsync(CancellationToken cancellationToken);
    }
}
