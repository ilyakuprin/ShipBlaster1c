using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using StringValues;
using UnityEngine;

namespace Unit
{
    public class TakingDamage
    {
        private readonly int _damage;
        private readonly Collider2D _collider;
        private readonly Health _health;

        private AsyncTriggerEnter2DTrigger _trigger;
        private CancellationToken _ct;
        private int _layerDamagableObj;
        private bool _isStarted;

        public TakingDamage(int damage,
                            Collider2D collider,
                            int layerDamagableObj,
                            Health health)
        {
            _damage = damage;
            _collider = collider;
            _layerDamagableObj = layerDamagableObj;
            _health = health;
        }

        public void Init()
        {
            _trigger = _collider.GetAsyncTriggerEnter2DTrigger();
            _ct = _collider.GetCancellationTokenOnDestroy();
        }

        public void StartDetectCollision()
        {
            if (_isStarted) return;

            DetectCollision().Forget();
        }

        private async UniTaskVoid DetectCollision()
        {
            _isStarted = true;

            var gameObj = _collider.gameObject;
            while (gameObj.activeInHierarchy)
            {
                var uniTask = _trigger.OnTriggerEnter2DAsync(_ct);
                await uniTask;

                if (uniTask.GetAwaiter().GetResult().gameObject.layer == _layerDamagableObj)
                {
                    _health.TakeDamage(_damage);
                }
            }

            _isStarted = false;
        }
    }
}