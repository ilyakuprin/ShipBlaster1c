using System.Linq;
using Inputting;
using Zenject;

namespace Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind(new[] { typeof(PlayerInput) }.Concat(typeof(KeyboardInput).GetInterfaces()))
                .To<KeyboardInput>().AsSingle();
        }
    }
}