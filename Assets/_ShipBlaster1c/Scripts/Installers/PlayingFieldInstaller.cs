using PlayingField;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayingFieldInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayingFieldView _playingFieldView;
        [SerializeField] private PlayingFieldConfig _playingFieldConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
            Container.Bind<PlayingFieldView>().FromInstance(_playingFieldView).AsSingle();
            Container.Bind<PlayingFieldConfig>().FromInstance(_playingFieldConfig).AsSingle();
        }
    }
}