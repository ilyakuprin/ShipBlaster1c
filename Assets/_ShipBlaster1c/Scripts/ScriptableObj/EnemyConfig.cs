using Enemy;
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public const int PoolStartCapacity = 5;
        
        [field: SerializeField] public EnemyView Prefab { get; private set; }
        [field: SerializeField, Range(0.1f, 10f)] public float MinSpeed { get; private set; }
        [field: SerializeField, Range(0.1f, 10f)] public float MaxSpeed { get; private set; }
        [field: SerializeField, Range(1f, 10f)] public float MinTimeoutSpawnInSec { get; private set; }
        [field: SerializeField, Range(1f, 10f)] public float MaxTimeoutSpawnInSec { get; private set; }
        [field: SerializeField, Range(1, 100)] public int MinCount { get; private set; }
        [field: SerializeField, Range(1, 100)] public int MaxCount { get; private set; }
        [field: SerializeField, Range(1, 20)] public int Health { get; private set; }

        private void OnValidate()
        {
            if (MinSpeed >= MaxSpeed)
                MinSpeed = MaxSpeed;
            
            if (MinTimeoutSpawnInSec >= MaxTimeoutSpawnInSec)
                MinTimeoutSpawnInSec = MaxTimeoutSpawnInSec;
            
            if (MinCount >= MaxCount)
                MinCount = MaxCount;
        }
    }
}