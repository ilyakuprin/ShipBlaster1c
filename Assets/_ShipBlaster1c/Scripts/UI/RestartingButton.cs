using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace UserInterface
{
    public class RestartingButton : IInitializable, IDisposable
    {
        private readonly DefeatCanvasView _defeatCanvasView;
        private readonly VictoryCanvasView _victoryCanvasView;

        public RestartingButton(DefeatCanvasView defeatCanvasView,
                             VictoryCanvasView victoryCanvasView)
        {
            _defeatCanvasView = defeatCanvasView;
            _victoryCanvasView = victoryCanvasView;
        }

        public void Initialize()
        {
            _defeatCanvasView.Restart.onClick.AddListener(Restart);
            _victoryCanvasView.Restart.onClick.AddListener(Restart);
        }

        public void Dispose()
        {
            _defeatCanvasView.Restart.onClick.RemoveListener(Restart);
            _victoryCanvasView.Restart.onClick.RemoveListener(Restart);
        }

        private static void Restart()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}