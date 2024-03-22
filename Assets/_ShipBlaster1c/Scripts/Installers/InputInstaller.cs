using System.Linq;
using _ShipBlaster1c.Scripts.Inputting;
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