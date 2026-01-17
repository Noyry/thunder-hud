using Noyry.ThunderHud.Domain.Model.Abstract;

namespace Noyry.ThunderHud.UI
{
    public class RenderObject<T>(Func<T, string> getTextFunc) where T : IVehicle
    {
        public Func<T, string> GetText { get; } = getTextFunc;
    }
}
