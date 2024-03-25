using System;
using Factory;

namespace Enemy
{
    public class ReturningEnemyInPool
    {
        public event Action Returned;
        
        private readonly Pool<EnemyView> _pool;

        public ReturningEnemyInPool(Pool<EnemyView> pool)
        {
            _pool = pool;
        }

        public void Return(EnemyView enemy)
        {
            _pool.Return(enemy);
            Returned?.Invoke();
        }
    }
}