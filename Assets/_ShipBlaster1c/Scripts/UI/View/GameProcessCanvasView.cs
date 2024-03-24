using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class GameProcessCanvasView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI HealthText { get; private set; }
    }
}