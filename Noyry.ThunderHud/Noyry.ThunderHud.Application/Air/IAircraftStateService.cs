using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application.Air
{
    public interface IAircraftStateService
    {
        Task<AircraftState> GetAircraftStateAsync(CancellationToken cancellationToken);
    }
}
