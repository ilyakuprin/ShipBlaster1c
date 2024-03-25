using MainHero;
using PlayingField;
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
        [SerializeField] private FinishView _finishView;
        
        public override void InstallBindings()
        {
            Container.Bind<MainHeroView>().FromInstance(_mainHeroView).AsSingle();
            Container.Bind<MainHeroConfig>().FromInstance(_mainHeroConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<MainHeroMovement>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScreenBoundsCalculation>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainHeroTakingDamage>().AsSingle()
                .WithArguments(_finishView.Collider, LayerCaching.Enemy);
            Container.BindInterfacesAndSelfTo<MainHeroHealth>().AsSingle()
                .WithArguments(_mainHeroConfig.Health);
            Container.BindInterfacesAndSelfTo<Shooting>().AsSingle();
            Container.BindInterfacesAndSelfTo<FinishSettingPosition>().AsSingle()
                .WithArguments(_finishView.SpriteRenderer);
        }
    }
}