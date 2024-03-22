using UnityEngine;

namespace PlayingField
{
    public class ScreenView : MonoBehaviour
    {
        [field: SerializeField] public Camera Camera { get; private set; }
    }
}