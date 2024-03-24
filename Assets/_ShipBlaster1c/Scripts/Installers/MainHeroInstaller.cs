using MainHero;
using ScriptableObj;
using StringValues;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainHeroInstaller : MonoInstaller
    {
        [SerializeField] private MainHeroView _mainHeroView;
        [SerializeField] private MainHeroConfig _mainHeroConfig;
        
        
        public override void InstallBindings()
        {
            Container.Bind<MainHeroView>().FromInstance(_mainHeroView).AsSingle();
            Container.Bind<MainHeroConfig>().FromInstance(_mainHeroConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<MainHeroMovement>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScreenBoundsCalculation>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainHeroTakingDamage>().AsSingle()
                .WithArguments(_mainHeroView.Finish, LayerCaching.Enemy);
            Container.BindInterfacesAndSelfTo<MainHeroHealth>().AsSingle()
                .WithArguments(_mainHeroConfig.Health);
        }
    }
}