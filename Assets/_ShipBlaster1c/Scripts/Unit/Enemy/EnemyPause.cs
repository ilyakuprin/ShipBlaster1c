using System;
using GameStatus;

namespace Enemy
{
    public class EnemyPause : IDisposable
    {
        private readonly ObjectMovement _objectMovement;
        private readonly SettingPause _settingPause;

        public EnemyPause(ObjectMovement objectMovement,
                          SettingPause settingPause)
        {
            _objectMovement = objectMovement;
            _settingPause = settingPause;
        }

        public void Init()
            => _settingPause.Set += _objectMovement.SetPause;

        public void Dispose()
            => _settingPause.Set -= _objectMovement.SetPause;
    }
}