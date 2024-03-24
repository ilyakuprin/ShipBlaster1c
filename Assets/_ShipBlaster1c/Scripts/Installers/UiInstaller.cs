using GameStatus;
using UnityEngine;
using UserInterface;
using Zenject;

namespace Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private GameProcessCanvasView _gameProcessCanvasView;
        [SerializeField] private DefeatCanvasView _defeatCanvasView;
        [SerializeField] private VictoryCanvasView _victoryCanvasView;
        
        public override void InstallBindings()
        {
            Container.Bind<GameProcessCanvasView>().FromInstance(_gameProcessCanvasView).AsSingle();
            Container.Bind<DefeatCanvasView>().FromInstance(_defeatCanvasView).AsSingle();
            Container.Bind<VictoryCanvasView>().FromInstance(_victoryCanvasView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<ChangingHealthMainHero>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShowingDefeatScreen>().AsSingle();
            Container.BindInterfacesAndSelfTo<RestartingButton>().AsSingle();
        }
    }
}