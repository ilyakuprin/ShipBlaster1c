using System;
using Inputting;
using Enemy;
using MainHero;

namespace GameStatus
{
    public class SettingPause
    {
        public event Action<bool> Set;
        
        private readonly PlayerInput _playerInput;
        private readonly EnemySpawning _enemySpawning;
        private readonly Shooting _shooting;

        public SettingPause(PlayerInput playerInput,
                            EnemySpawning enemySpawning,
                            Shooting shooting)
        {
            _playerInput = playerInput;
            _enemySpawning = enemySpawning;
            _shooting = shooting;
        }

        public void PauseOn()
            => SetPause(true);
        
        public void PauseOff()
            => SetPause(true);
        
        private void SetPause(bool value)
        {
            _enemySpawning.SetPause(value);
            _playerInput.SetPause(value);
            _shooting.SetPause(value);
            
            Set?.Invoke(value);
        }
    }
}