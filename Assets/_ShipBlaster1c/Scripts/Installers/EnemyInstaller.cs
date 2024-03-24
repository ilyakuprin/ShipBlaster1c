using Enemy;
using Factory;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private Transform _parent;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<Pool<EnemyView>>()
                .FromInstance(new Pool<EnemyView>(EnemyConfig.PoolStartCapacity)).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle().WithArguments(_enemyConfig.Prefab, _parent);
            Container.BindInterfacesAndSelfTo<GettingSpawnPoint>().AsSingle();
            Container.BindInterfacesAndSelfTo<ReturningEnemyInPool>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawning>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyCounter>().AsSingle();
        }
    }
}