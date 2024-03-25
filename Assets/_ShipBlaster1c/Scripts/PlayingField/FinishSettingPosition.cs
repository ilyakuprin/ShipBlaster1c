using MainHero;
using UnityEngine;
using Zenject;

namespace PlayingField
{
    public class FinishSettingPosition : IInitializable
    {
        private readonly ScreenBoundsCalculation _screenBoundsCalculation;
        private readonly SpriteRenderer _finish;
        private readonly MainHeroView _heroView;

        public FinishSettingPosition(ScreenBoundsCalculation screenBoundsCalculation,
                                     SpriteRenderer finish,
                                     MainHeroView heroView)
        {
            _screenBoundsCalculation = screenBoundsCalculation;
            _finish = finish;
            _heroView = heroView;
        }

        public void Initialize()
        {
            SetLength();
            SetPosition();
        }

        private void SetPosition()
        {
            var transformFinish = _finish.transform;
            var newPosition = transformFinish.position;
            
            newPosition.y = _screenBoundsCalculation.UpperBorder
                            + _finish.bounds.size.y
                            + _heroView.SpriteRenderer.bounds.size.y / 2;
            newPosition.x = 0;
            
            transformFinish.position = newPosition;
        }

        private void SetLength()
        {
            var transformFinish = _finish.transform;
            var newScale = transformFinish.lossyScale;
            var sizeHeroX = _heroView.SpriteRenderer.bounds.size.x;
            newScale.x = _screenBoundsCalculation.RightBorder - _screenBoundsCalculation.LeftBorder + sizeHeroX;

            transformFinish.localScale = newScale;
        }
    }
}