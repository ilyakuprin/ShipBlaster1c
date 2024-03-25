using System;
using GameStatus;
using Zenject;

namespace UserInterface
{
    public class ShowingVictoryScreen : IInitializable, IDisposable
    {
        private readonly VictoryCanvasView _victoryCanvasView;
        private readonly VictoryChecking _victoryChecking;

        public ShowingVictoryScreen(VictoryCanvasView victoryCanvasView,
                                    VictoryChecking victoryChecking)
        {
            _victoryCanvasView = victoryCanvasView;
            _victoryChecking = victoryChecking;
        }

        public void Initialize()
            => _victoryChecking.Won += EnabledCanvas;

        public void Dispose()
            => _victoryChecking.Won -= EnabledCanvas;
        
        private void EnabledCanvas()
            => _victoryCanvasView.VictoryCanvas.gameObject.SetActive(true);
    }
}