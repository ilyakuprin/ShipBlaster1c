using Factory;
using UnityEngine;

namespace Bullet
{
    public class ReturningBulletInPool
    {
        private readonly Pool<BulletView> _pool;

        public ReturningBulletInPool(Pool<BulletView> pool)
        {
            _pool = pool;
        }

        public void Return(BulletView bullet)
        {
            bullet.transform.localPosition = Vector3.zero;
            _pool.Return(bullet);
        }
    }
}