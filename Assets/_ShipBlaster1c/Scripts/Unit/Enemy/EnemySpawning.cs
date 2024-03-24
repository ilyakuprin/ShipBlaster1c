using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ScriptableObj;
using Zenject;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawning : IInitializable, IDisposable
    {
        public event Action Spawned; 
        
        private readonly EnemyFactory _makingEnemies;
        private readonly GettingSpawnPoint _gettingSpawnPoint;
        private readonly EnemyConfig _enemyConfig;

        private CancellationTokenSource _cts;
        private bool _isPause;

        public EnemySpawning(EnemyFactory makingEnemies,
                               GettingSpawnPoint gettingSpawnPoint,
                               EnemyConfig enemyConfig)
        {
            _makingEnemies = makingEnemies;
            _gettingSpawnPoint = gettingSpawnPoint;
            _enemyConfig = enemyConfig;
        }

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            Timer().Forget();
        }

        public void Dispose()
        {
            if (_cts.IsCancellationRequested) return;

            _cts.Cancel();
            _cts.Dispose();
        }

        public void SetPause(bool value)
            => _isPause = value;

        private async UniTaskVoid Timer()
        {
            while (!_cts.IsCancellationRequested)
            {
                var timeWait = Random.Range(_enemyConfig.MinTimeoutSpawnInSec, _enemyConfig.MaxTimeoutSpawnInSec);
                await UniTask.WaitForSeconds(timeWait, false, PlayerLoopTiming.Update, _cts.Token);
                
                while (_isPause)
                    await UniTask.NextFrame();
                
                Spawn();
            }
        }

        private void Spawn()
        {
            var enemy = _makingEnemies.Get();
            enemy.transform.position = _gettingSpawnPoint.GetSpawnPoint();
            
            Spawned?.Invoke();
        }
    }
}