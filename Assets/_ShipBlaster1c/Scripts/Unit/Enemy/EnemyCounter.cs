using System;
using ScriptableObj;
using Zenject;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyCounter : IInitializable, IDisposable
    {
        private readonly EnemySpawning _enemySpawning;
        private readonly EnemyConfig _enemyConfig;
        private int _counter;
        
        public int StartCount { get; private set; }

        public EnemyCounter(EnemySpawning enemySpawning,
                            EnemyConfig enemyConfig)
        {
            _enemySpawning = enemySpawning;
            _enemyConfig = enemyConfig;
        }
        
        public void Initialize()
        {
            StartCount = Random.Range(_enemyConfig.MinCount, _enemyConfig.MaxCount + 1);
            _enemySpawning.Spawned += Count;
        }

        public void Dispose()
        {
            _enemySpawning.Spawned -= Count;
        }

        private void Count()
        {
            _counter++;
            
            if (_counter == StartCount)
                _enemySpawning.Dispose();
        }
    }
}