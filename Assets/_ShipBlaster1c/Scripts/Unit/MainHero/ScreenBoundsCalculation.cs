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
        
        private float _bottomBorder;
        
        public float LeftBorder { get; private set; }
        public float RightBorder { get; private set; }
        public float UpperBorder{ get; private set; } 

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
            targetPosition.x = Mathf.Clamp(targetPosition.x, LeftBorder, RightBorder);
            targetPosition.y = Mathf.Clamp(targetPosition.y, _bottomBorder, UpperBorder);
            return targetPosition;
        }

        private void Calculate()
        {
            var bounds = _spriteRenderer.bounds;
            var sizeY = bounds.size.y;
            var halfPlayerSizeX = bounds.size.x / 2;
            var halfPlayerSizeY = sizeY / 2;

            var leftBottomCorner = _camera.ViewportToWorldPoint(LowerLeftCorner);
            
            LeftBorder = leftBottomCorner.x + halfPlayerSizeX;
            RightBorder = _camera.ViewportToWorldPoint(LowerRightCorner).x - halfPlayerSizeX;
            _bottomBorder = leftBottomCorner.y + halfPlayerSizeY;
            UpperBorder = (leftBottomCorner.y + sizeY * _playingFieldConfig.FinishLineHeightInMainHero)
                           - halfPlayerSizeY;
        }
    }
}