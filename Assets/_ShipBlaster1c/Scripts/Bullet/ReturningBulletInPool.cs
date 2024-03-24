using Factory;

namespace Bullet
{
    public class ReturningBulletInPool
    {
        private readonly Pool<BulletView> _pool;

        public ReturningBulletInPool(Pool<BulletView> pool)
        {
            _pool = pool;
        }

        public void Return(BulletView enemy)
        {
            _pool.Return(enemy);
        }
    }
}