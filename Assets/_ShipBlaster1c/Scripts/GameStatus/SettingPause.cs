using System;
using Inputting;
using Enemy;

namespace GameStatus
{
    public class SettingPause
    {
        public event Action<bool> Set;
        
        private readonly PlayerInput _playerInput;
        private readonly EnemySpawning _enemySpawning;

        public SettingPause(PlayerInput playerInput,
                            EnemySpawning enemySpawning)
        {
            _playerInput = playerInput;
            _enemySpawning = enemySpawning;
        }

        public void PauseOn()
            => SetPause(true);
        
        public void PauseOff()
            => SetPause(false);
        
        private void SetPause(bool value)
        {
            _enemySpawning.SetPause(value);
            _playerInput.SetPause(value);
            
            Set?.Invoke(value);
        }
    }
}