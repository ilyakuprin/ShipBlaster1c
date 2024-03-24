using System;
using MainHero;
using Zenject;

namespace GameStatus
{
    public class EnablingPauseDeath : IInitializable, IDisposable
    {
        private readonly MainHeroHealth _mainHeroHealth;
        private readonly SettingPause _pauseState;

        public EnablingPauseDeath(MainHeroHealth mainHeroHealth,
                                  SettingPause pauseState)
        {
            _mainHeroHealth = mainHeroHealth;
            _pauseState = pauseState;
        }
        
        public void Initialize()
            => _mainHeroHealth.Dead += _pauseState.PauseOn;

        public void Dispose()
            => _mainHeroHealth.Dead -= _pauseState.PauseOn;
    }
}