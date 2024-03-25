using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Enemy;
using MainHero;
using Zenject;

namespace GameStatus
{
    public class VictoryChecking : IInitializable, IDisposable
    {
        public event Action Won;
        
        private readonly EnemyCounter _enemyCounter;
        private readonly ReturningEnemyInPool _returningEnemyInPool;
        private readonly MainHeroHealth _health;
        private readonly SettingPause _settingPause;

        private int _counterReturned;
        private bool _isReturned;
        private CancellationTokenSource _cts;

        public VictoryChecking(EnemyCounter enemyCounter,
                                ReturningEnemyInPool returningEnemyInPool,
                                MainHeroHealth health,
                                SettingPause settingPause)
        {
            _enemyCounter = enemyCounter;
            _returningEnemyInPool = returningEnemyInPool;
            _health = health;
            _settingPause = settingPause;
        }

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            _returningEnemyInPool.Returned += SetReturned;
        }

        public void Dispose()
        {
            _returningEnemyInPool.Returned -= SetReturned;
            
            _cts.Cancel();
            _cts.Dispose();
        }

        private void SetReturned()
        {
            _counterReturned++;

            if (_counterReturned == _enemyCounter.StartCount)
                WaitTakenDmg().Forget();
        }

        private async UniTask WaitTakenDmg()
        {
            await UniTask.NextFrame(_cts.Token);

            if (_health.CurrentHealth > 0)
            {
                _settingPause.PauseOn();
                Won?.Invoke();
            }
        }
    }
}