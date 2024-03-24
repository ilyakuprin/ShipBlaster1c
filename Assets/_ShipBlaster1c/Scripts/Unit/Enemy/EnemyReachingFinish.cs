using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using StringValues;

namespace Enemy
{
    public class EnemyReachingFinish
    {
        private readonly ReturningEnemyInPool _returningEnemyInPool;
        private readonly EnemyView _enemy;
        
        private AsyncTriggerEnter2DTrigger _trigger;
        private CancellationToken _ct;
        private int _layerFinish;
        private bool _isStarted;

        public EnemyReachingFinish(ReturningEnemyInPool returningEnemyInPool,
                                   EnemyView enemy)
        {
            _returningEnemyInPool = returningEnemyInPool;
            _enemy = enemy;
        }
        
        public void Init()
        {
            _trigger = _enemy.Rigidbody.GetAsyncTriggerEnter2DTrigger();
            _ct = _enemy.Rigidbody.GetCancellationTokenOnDestroy();
            
            _layerFinish = LayerCaching.Finish;
        }
        
        public void StartDetectCollision()
        {
            if (_isStarted) return;
            
            DetectCollision().Forget();
        } 
        
        private async UniTaskVoid DetectCollision()
        {
            _isStarted = true;
            
            var gameObj = _enemy.Rigidbody.gameObject;
            while (gameObj.activeInHierarchy)
            {
                var uniTask = _trigger.OnTriggerEnter2DAsync(_ct);
                await uniTask;
                if (uniTask.GetAwaiter().GetResult().gameObject.layer == _layerFinish)
                {
                    _returningEnemyInPool.Return(_enemy);
                }
            }

            _isStarted = false;
        }
    }
}