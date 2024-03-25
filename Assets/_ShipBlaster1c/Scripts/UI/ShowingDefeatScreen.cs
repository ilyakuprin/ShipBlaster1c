using System;
using MainHero;
using Zenject;

namespace UserInterface
{
    public class ShowingDefeatScreen : IInitializable, IDisposable
    {
        private readonly MainHeroHealth _mainHeroHealth;
        private readonly DefeatCanvasView _defeatCanvasView;

        public ShowingDefeatScreen(MainHeroHealth mainHeroHealth,
                                   DefeatCanvasView defeatCanvasView)
        {
            _mainHeroHealth = mainHeroHealth;
            _defeatCanvasView = defeatCanvasView;
        }

        public void Initialize()
            => _mainHeroHealth.Dead += EnabledCanvas;

        public void Dispose()
            => _mainHeroHealth.Dead -= EnabledCanvas;

        private void EnabledCanvas()
            => _defeatCanvasView.DefeatCanvas.gameObject.SetActive(true);
    }
}