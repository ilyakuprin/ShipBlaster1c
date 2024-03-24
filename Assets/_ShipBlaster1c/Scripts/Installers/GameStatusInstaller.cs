using GameStatus;
using Zenject;

namespace Installers
{
    public class GameStatusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SettingPause>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnablingPauseDeath>().AsSingle();
        }
    }
}