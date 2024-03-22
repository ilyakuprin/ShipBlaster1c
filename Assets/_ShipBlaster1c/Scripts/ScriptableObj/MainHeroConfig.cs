using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "MainHeroConfig", menuName = "Configs/MainHeroConfig")]
    public class MainHeroConfig : ScriptableObject
    {
        [field: SerializeField, Range(0.1f, 10f)] public float Speed { get; private set; }
    }
}