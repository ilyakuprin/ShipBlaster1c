using UnityEngine;

namespace PlayingField
{
    public class PlayingFieldView : MonoBehaviour
    {
        [SerializeField] private RectTransform[] _spawnPoints;

        public int LengthSpawnPoints
            => _spawnPoints.Length;

        public RectTransform GetSpawnPoint(int index)
            => _spawnPoints[index];
    }
}