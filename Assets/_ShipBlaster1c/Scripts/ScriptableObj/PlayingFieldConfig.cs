using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "PlayingFieldConfig", menuName = "Configs/PlayingFieldConfig")]
    public class PlayingFieldConfig : ScriptableObject
    {
        [field: Tooltip("Height from the bottom of the screen in MainHero. Bottom + MainHero * value"),
                SerializeField, Range(1f, 3f)] public float FinishLineHeightInMainHero { get; private set; }
    }
}