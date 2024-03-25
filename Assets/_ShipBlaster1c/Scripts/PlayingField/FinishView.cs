using UnityEngine;

namespace PlayingField
{
    public class FinishView : MonoBehaviour
    {
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    }
}