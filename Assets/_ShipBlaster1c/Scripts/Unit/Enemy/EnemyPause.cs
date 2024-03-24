using System;
using GameStatus;

namespace Enemy
{
    public class EnemyPause : IDisposable
    {
        private readonly EnemyMovement _enemyMovement;
        private readonly SettingPause _settingPause;

        public EnemyPause(EnemyMovement enemyMovement,
                          SettingPause settingPause)
        {
            _enemyMovement = enemyMovement;
            _settingPause = settingPause;
        }

        public void Init()
            => _settingPause.Set += _enemyMovement.SetPause;

        public void Dispose()
            => _settingPause.Set -= _enemyMovement.SetPause;
    }
}