using Factory;
using GameStatus;
using MainHero;
using ScriptableObj;
using StringValues;
using Unit;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySettingStartValues : MonoBehaviour, IInitializableValues
    {
        [SerializeField] private EnemyView _enemyView;
        
        private EnemyConfig _enemyConfig;
        private int _takingDamage;
        private ReturningEnemyInPool _returningEnemyInPool;
        private SettingPause _settingPause;

        private ObjectMovement _objectMovement;
        private TakingDamage _enemyTakingDamage;
        private Health _health;
        private EnemyReachingFinish _enemyReachingFinish;
        private EnemyPause _enemyPause;

        [Inject]
        public void Construct(EnemyConfig enemyConfig,
                              MainHeroConfig mainHeroConfig,
                              ReturningEnemyInPool returningEnemyInPool,
                              MainHeroHealth mainHeroHealth,
                              SettingPause settingPause)
        {
            _enemyConfig = enemyConfig;
            _takingDamage = mainHeroConfig.BulletDamage;
            _returningEnemyInPool = returningEnemyInPool;
            _settingPause = settingPause;
        }

        private void Awake()
        {
            InitMovement();
            InitHealth();
            InitTakingDamage();
            InitReachingFinish();
            InitSettingPause();
        }

        public void InitValues()
        {
            var speed = Random.Range(_enemyConfig.MinSpeed, _enemyConfig.MaxSpeed);
            _objectMovement.StartMove(speed);
            _enemyTakingDamage.StartDetectCollision();
            _enemyReachingFinish.StartDetectCollision();
        }

        private void InitMovement()
        {
            _objectMovement = new ObjectMovement(_enemyView.Rigidbody, Vector2.down);
            _objectMovement.Init();
        }

        private void InitHealth()
        {
            _health = new Health(_enemyConfig.Health);
        }

        private void InitTakingDamage()
        {
            _enemyTakingDamage = new TakingDamage(_takingDamage,
                                                  _enemyView.Collider,
                                                  LayerCaching.Bullet,
                                                  _health);
            _enemyTakingDamage.Init();
        }

        private void InitReachingFinish()
        {
            _enemyReachingFinish = new EnemyReachingFinish(_returningEnemyInPool, _enemyView, LayerCaching.Finish);
            _enemyReachingFinish.Init();
        }

        private void InitSettingPause()
        {
            _enemyPause = new EnemyPause(_objectMovement, _settingPause);
            _enemyPause.Init();
        }
    }
}