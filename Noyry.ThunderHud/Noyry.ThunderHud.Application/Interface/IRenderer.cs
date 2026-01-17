using Noyry.ThunderHud.Domain.Model.Abstract;

namespace Noyry.ThunderHud.Application.Interface
{
    public interface IRenderer<T> where T : IVehicle
    {
        Task Render(T vehicle, CancellationToken cancellationToken);
    }
}
