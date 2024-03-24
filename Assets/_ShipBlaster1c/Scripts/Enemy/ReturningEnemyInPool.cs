using Factory;

namespace Enemy
{
    public class ReturningEnemyInPool
    {
        private readonly Pool<EnemyView> _pool;

        public ReturningEnemyInPool(Pool<EnemyView> pool)
        {
            _pool = pool;
        }

        public void Return(EnemyView enemy)
        {
            _pool.Return(enemy);
        }
    }
}