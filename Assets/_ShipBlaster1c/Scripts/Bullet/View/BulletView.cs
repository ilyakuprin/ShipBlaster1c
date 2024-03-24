using UnityEngine;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        [field: SerializeField] public Collider2D Collider { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public BulletSettingStartValues SettingStartValues { get; private set; }
    }
}