using Unit;

namespace Enemy
{
    public class EnemyReachingFinish : DetectingCollision
    {
        private readonly ReturningEnemyInPool _returningEnemyInPool;
        private readonly EnemyView _enemy;
        
        public EnemyReachingFinish(ReturningEnemyInPool returningEnemyInPool,
                                   EnemyView enemy,
                                   int layerDetectingObj)
            : base(enemy.Collider,
                   layerDetectingObj)
        {
            _returningEnemyInPool = returningEnemyInPool;
            _enemy = enemy;
        }

        protected override void Collide()
        {
            _returningEnemyInPool.Return(_enemy);
        }
    }
}