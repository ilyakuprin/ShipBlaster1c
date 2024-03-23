using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    }
}
