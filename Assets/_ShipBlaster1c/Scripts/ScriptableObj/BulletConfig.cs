using Bullet;
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        public const int PoolStartCapacity = 10;
        
        [field: SerializeField] public BulletView Prefab { get; private set; }
        [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; }
        [field: SerializeField, Range(1, 10)] public int Damage { get; private set; }
    }
}