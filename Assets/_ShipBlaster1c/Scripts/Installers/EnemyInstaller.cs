using Enemy;
using Factory;
using Zenject;

namespace Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        private const int PoolLength = 5;
        
        public override void InstallBindings()
        {
            var pool = new Pool<EnemyView>(PoolLength);
            Container.Bind<Pool<EnemyView>>().FromInstance(pool).AsSingle();
        }
    }
}