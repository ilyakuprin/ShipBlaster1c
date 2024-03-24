using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;

namespace Bullet
{
    public class RemovingMissedBullet
    {
        private readonly ReturningBulletInPool _returningBulletInPool;
        private readonly BulletView _bulletView;

        private AsyncBecameInvisibleTrigger _invisible;
        private CancellationToken _ct;

        private bool _isChecking;
        
        public RemovingMissedBullet(ReturningBulletInPool returningBulletInPool,
                                    BulletView bulletView)
        {
            _returningBulletInPool = returningBulletInPool;
            _bulletView = bulletView;
        }

        public void Init()
        {
            _ct = _bulletView.GetCancellationTokenOnDestroy();
            _invisible = _bulletView.GetAsyncBecameInvisibleTrigger();
        }

        public void StartCheck()
        {
            if (!_isChecking)
                RemoveInvisible().Forget();
        }

        private async UniTask RemoveInvisible()
        {
            _isChecking = true;
            
            var uniTask = _invisible.OnBecameInvisibleAsync(_ct);
            await uniTask;
            
            _returningBulletInPool.Return(_bulletView);

            _isChecking = false;
        }
    }
}