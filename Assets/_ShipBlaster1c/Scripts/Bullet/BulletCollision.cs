using Unit;

namespace Bullet
{
    public class BulletCollision : DetectingCollision
    {
        private readonly ReturningBulletInPool _returningBulletInPool;
        private readonly BulletView _bullet;
        
        public BulletCollision(ReturningBulletInPool returningBulletInPool,
                               BulletView bullet,
                               int layerDetectingObj)
            : base(bullet.Collider,
                   layerDetectingObj)
        {
            _returningBulletInPool = returningBulletInPool;
            _bullet = bullet;
        }

        protected override void Collide()
        {
            _returningBulletInPool.Return(_bullet);
        }
    }
}