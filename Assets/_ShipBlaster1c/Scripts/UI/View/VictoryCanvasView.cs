using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class VictoryCanvasView : MonoBehaviour
    {
        [field: SerializeField] public Canvas VictoryCanvas { get; private set; }
        [field: SerializeField] public Button Restart { get; private set; }
    }
}