using PlayingField;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class GettingSpawnPoint : IInitializable
    {
        private readonly PlayingFieldView _playingFieldView;
        private readonly Camera _camera;
        
        private Vector3[] _spawnPoints;

        public GettingSpawnPoint(PlayingFieldView playingFieldView,
                                 Camera camera)
        {
            _playingFieldView = playingFieldView;
            _camera = camera;
        }

        public void Initialize()
            => FillArraySpawnWorldPosition();

        public Vector3 GetSpawnPoint()
            => _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        private void FillArraySpawnWorldPosition()
        {
            var length = _playingFieldView.LengthSpawnPoints;
            _spawnPoints = new Vector3[length];

            for (var i = 0; i < length; i++)
            {
                var position = _camera.ScreenToWorldPoint(_playingFieldView.GetSpawnPoint(i).position);
                position.z = 0;
                _spawnPoints[i] = position;
            }
        }
    }
}