using System;
using Unit;

namespace Enemy
{
    public class EnemyDeath : IDisposable
    {
        private readonly EnemyView _enemyView;
        private readonly ReturningEnemyInPool _returningEnemyInPool;
        private readonly Health _health;

        public EnemyDeath(EnemyView enemyView,
                          ReturningEnemyInPool returningEnemyInPool,
                          Health health)
        {
            _enemyView = enemyView;
            _returningEnemyInPool = returningEnemyInPool;
            _health = health;
        }

        public void Init()
            => _health.Dead += ReturnEnemy;

        public void Dispose()
            => _health.Dead -= ReturnEnemy;

        private void ReturnEnemy()
            => _returningEnemyInPool.Return(_enemyView);
    }
}