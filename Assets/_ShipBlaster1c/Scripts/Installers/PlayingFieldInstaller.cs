using PlayingField;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayingFieldInstaller : MonoInstaller
    {
        [SerializeField] private ScreenView _screenView;
        [SerializeField] private PlayingFieldConfig _playingFieldConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<ScreenView>().FromInstance(_screenView).AsSingle();
            Container.Bind<PlayingFieldConfig>().FromInstance(_playingFieldConfig).AsSingle();
        }
    }
}