using Noyry.ThunderHud.Domain.Model.Abstract;

namespace Noyry.ThunderHud.UI.ConsoleRender
{
    public class ConsoleRendererConfig<T> where T : IVehicle
    {
        public ConsoleRendererConfig(IReadOnlyCollection<RenderObject<T>> renderObjects)
        {
            _renderObjects = renderObjects;
        }

        private IReadOnlyCollection<RenderObject<T>> _renderObjects;

        public IReadOnlyCollection<RenderObject<T>> GetRenderObjects() => _renderObjects;
    }
}
