using UnityEngine;

namespace MainHero
{
    public class MainHeroView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
        [field: SerializeField] public Transform FirePoint { get; private set; }
    }
}