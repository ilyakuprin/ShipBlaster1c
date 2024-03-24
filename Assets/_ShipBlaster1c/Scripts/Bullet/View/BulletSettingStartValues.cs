using Enemy;
using Factory;
using GameStatus;
using ScriptableObj;
using StringValues;
using UnityEngine;
using Zenject;

namespace Bullet
{
    public class BulletSettingStartValues : MonoBehaviour, IInitializableValues
    {
        [SerializeField] private BulletView _bulletView;

        private BulletConfig _bulletConfig;
        private ReturningBulletInPool _returningBulletInPool;
        private SettingPause _settingPause;
        
        private ObjectMovement _objectMovement;
        private BulletCollision _bulletCollision;
        private RemovingMissedBullet _removingMissedBullet;
        private MovementObjPause _movementObjPause;
        
        [Inject]
        public void Construct(BulletConfig bulletConfig,
                              ReturningBulletInPool returningBulletInPool,
                              SettingPause settingPause)
        {
            _bulletConfig = bulletConfig;
            _returningBulletInPool = returningBulletInPool;
            _settingPause = settingPause;
        }
        
        private void Awake()
        {
            InitMovement();
            InitBulletCollision();
            InitRemovingMissedBullet();
            InitMovementObjPause();
        }

        public void InitValues()
        {
            _objectMovement.StartMove(_bulletConfig.Speed);
            _bulletCollision.StartDetectCollision();
            _removingMissedBullet.StartCheck();
        }

        private void InitMovement()
        {
            _objectMovement = new ObjectMovement(_bulletView.Rigidbody, Vector2.up);
            _objectMovement.Init();
        }

        private void InitBulletCollision()
        {
            _bulletCollision = new BulletCollision(_returningBulletInPool, _bulletView, LayerCaching.Enemy);
            _bulletCollision.Init();
        }

        private void InitRemovingMissedBullet()
        {
            _removingMissedBullet = new RemovingMissedBullet(_returningBulletInPool, _bulletView);
            _removingMissedBullet.Init();
        }

        private void InitMovementObjPause()
        {
            _movementObjPause = new MovementObjPause(_objectMovement, _settingPause);
            _movementObjPause.Init();
        }
    }
}