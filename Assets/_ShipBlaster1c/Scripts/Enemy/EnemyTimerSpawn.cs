using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ScriptableObj;
using Zenject;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyTimerSpawn : IInitializable, IDisposable
    {
        private readonly EnemyFactory _makingEnemies;
        private readonly GettingSpawnPoint _gettingSpawnPoint;
        private readonly EnemyConfig _enemyConfig;

        private CancellationTokenSource _cts;

        public EnemyTimerSpawn(EnemyFactory makingEnemies,
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
            _cts.Cancel();
            _cts.Dispose();
        }

        private async UniTaskVoid Timer()
        {
            while (!_cts.IsCancellationRequested)
            {
                var timeWait = Random.Range(_enemyConfig.MinTimeoutSpawnInSec, _enemyConfig.MaxTimeoutSpawnInSec);
                await UniTask.WaitForSeconds(timeWait, false, PlayerLoopTiming.Update, _cts.Token);
                Spawn();
            }
        }

        private void Spawn()
        {
            var enemy = _makingEnemies.Get();
            enemy.transform.position = _gettingSpawnPoint.GetSpawnPoint();
        }
    }
}