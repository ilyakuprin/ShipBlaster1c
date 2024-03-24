using TMPro;
using UnityEngine;

namespace UserInterface
{
    public class GameProcessCanvasView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI HealthText { get; private set; }
    }
}