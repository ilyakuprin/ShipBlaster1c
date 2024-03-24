using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

namespace Unit
{
    public abstract class DetectingCollision
    {
        private readonly Collider2D _collider;
        private readonly int _layerDetectingObj;
        
        private AsyncTriggerEnter2DTrigger _trigger;
        private CancellationToken _ct;
        private bool _isStarted;

        protected DetectingCollision(Collider2D collider,
                                     int layerDetectingObj)
        {
            _collider = collider;
            _layerDetectingObj = layerDetectingObj;
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

        protected abstract void Collide();

        private async UniTaskVoid DetectCollision()
        {
            _isStarted = true;

            var gameObj = _collider.gameObject;
            while (gameObj.activeInHierarchy)
            {
                var uniTask = _trigger.OnTriggerEnter2DAsync(_ct);
                await uniTask;

                if (uniTask.GetAwaiter().GetResult().gameObject.layer == _layerDetectingObj)
                {
                    Collide();
                }
            }

            _isStarted = false;
        }
    }
}