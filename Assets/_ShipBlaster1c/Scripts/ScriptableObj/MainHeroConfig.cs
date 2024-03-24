using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "MainHeroConfig", menuName = "Configs/MainHeroConfig")]
    public class MainHeroConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; }
        [field: SerializeField, Range(0.1f, 5f)] public float RechargeWeaponInSec { get; private set; }
        [field: SerializeField, Range(1, 50)] public int Health { get; private set; }
        [field: SerializeField, Range(0.1f, 20f)] public float RadiusFire { get; private set; }
    }
}