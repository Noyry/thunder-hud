using Noyry.ThunderHud.Domain.Model.Air;

namespace Noyry.ThunderHud.Application.Air
{
    public interface IFuelTimeCalculator
    {
        TimeSpan? GetFuelTimeLeft(Aircraft aircraft);
    }
}
