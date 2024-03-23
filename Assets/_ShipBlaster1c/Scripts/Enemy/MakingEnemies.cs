using Factory;
using Zenject;

namespace Enemy
{
    public class MakingEnemies : IInitializable
    {
        private readonly EnemyFactory<EnemyView> _enemyFactory;
        private readonly Pool<EnemyView> _pool;
        private readonly GettingSpawnPoint _gettingSpawnPoint;

        public MakingEnemies(EnemyFactory<EnemyView> enemyFactory,
                             Pool<EnemyView> pool,
                             GettingSpawnPoint gettingSpawnPoint)
        {
            _enemyFactory = enemyFactory;
            _pool = pool;
            _gettingSpawnPoint = gettingSpawnPoint;
        }

        public void Initialize()
        {
            for (var i = 0; i < _pool.Count; i++)
            {
                _pool.Return(_enemyFactory.Get());
            }
        }

        public void Create()
        {
            if (!_pool.TryGet(out var obj))
            {
                obj = _enemyFactory.Get();
            }

            obj.transform.position = _gettingSpawnPoint.GetSpawnPoint();
        }
    }
}
