using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using StringValues;

namespace Enemy
{
    public class EnemyTakingDamage
    {
        public event Action<int> Taken;

        private readonly int _damage;
        private readonly EnemyView _enemy;
        
        private AsyncTriggerEnter2DTrigger _trigger;
        private CancellationToken _ct;
        private int _layerBullet;
        private bool _isStarted;

        public EnemyTakingDamage(int damage,
                                 EnemyView enemy)
        {
            _damage = damage;
            _enemy = enemy;
        }
        
        public void Init()
        {
            _trigger = _enemy.Rigidbody.GetAsyncTriggerEnter2DTrigger();
            _ct = _enemy.GetCancellationTokenOnDestroy();
            
            _layerBullet = LayerCaching.Bullet;
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
                if (uniTask.GetAwaiter().GetResult().gameObject.layer == _layerBullet)
                {
                    Taken?.Invoke(_damage);
                }
            }

            _isStarted = false;
        }
    }
}