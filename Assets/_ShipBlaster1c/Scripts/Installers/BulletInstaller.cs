using Bullet;
using Factory;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BulletInstaller : MonoInstaller
    {
        [SerializeField] private Transform _bulletParent;
        [SerializeField] private BulletConfig _bulletConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<BulletConfig>().FromInstance(_bulletConfig).AsSingle();
            
            Container.BindInterfacesAndSelfTo<Pool<BulletView>>()
                .FromInstance(new Pool<BulletView>(BulletConfig.PoolStartCapacity)).AsSingle();
            Container.BindInterfacesAndSelfTo<BulletFactory>().AsSingle()
                .WithArguments(_bulletConfig.Prefab, _bulletParent);
            Container.BindInterfacesAndSelfTo<ReturningBulletInPool>().AsSingle();
        }
    }
}