using ScriptableObj;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class ScreenBoundsCalculation : IInitializable
    {
        private static readonly Vector3 LowerLeftCorner = new Vector3(0, 0, 0);
        private static readonly Vector3 LowerRightCorner = new Vector3(1, 0, 0);
        
        private readonly Camera _camera;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly PlayingFieldConfig _playingFieldConfig;
        
        private float _leftBorder;
        private float _rightBorder;
        private float _bottomBorder;
        private float _upperBorder;

        public ScreenBoundsCalculation(Camera camera,
                                       MainHeroView mainHero,
                                       PlayingFieldConfig playingFieldConfig)
        {
            _camera = camera;
            _spriteRenderer = mainHero.SpriteRenderer;
            _playingFieldConfig = playingFieldConfig;
        }

        public void Initialize()
            => Calculate();

        public Vector2 GetClamp(Vector2 targetPosition)
        {
            targetPosition.x = Mathf.Clamp(targetPosition.x, _leftBorder, _rightBorder);
            targetPosition.y = Mathf.Clamp(targetPosition.y, _bottomBorder, _upperBorder);
            return targetPosition;
        }

        private void Calculate()
        {
            var bounds = _spriteRenderer.bounds;
            var sizeY = bounds.size.y;
            var halfPlayerSizeX = bounds.size.x / 2;
            var halfPlayerSizeY = sizeY / 2;

            var leftBottomCorner = _camera.ViewportToWorldPoint(LowerLeftCorner);
            
            _leftBorder = leftBottomCorner.x + halfPlayerSizeX;
            _rightBorder = _camera.ViewportToWorldPoint(LowerRightCorner).x - halfPlayerSizeX;
            _bottomBorder = leftBottomCorner.y + halfPlayerSizeY;
            _upperBorder = (leftBottomCorner.y + sizeY * _playingFieldConfig.FinishLineHeightInMainHero)
                           - halfPlayerSizeY;
        }
    }
}