using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class DefeatCanvasView : MonoBehaviour
    {
        [field: SerializeField] public Canvas DefeatCanvas { get; private set; }
        [field: SerializeField] public Button Restart { get; private set; }
    }
}