using ScriptableObj;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySettingStartValues : MonoBehaviour
    {
        [SerializeField] private EnemyView _enemyView;
        
        private EnemyConfig _enemyConfig;
        private int _takingDamage;
        private ReturningEnemyInPool _returningEnemyInPool;

        private EnemyMovement _enemyMovement;
        private EnemyTakingDamage _enemyTakingDamage;
        private EnemyHealth _enemyHealth;
        private EnemyReachingFinish _enemyReachingFinish;
        
        [Inject]
        public void Construct(EnemyConfig enemyConfig,
                              MainHeroConfig mainHeroConfig,
                              ReturningEnemyInPool returningEnemyInPool)
        {
            _enemyConfig = enemyConfig;
            _takingDamage = mainHeroConfig.BulletDamage;
            _returningEnemyInPool = returningEnemyInPool;
        }

        private void Awake()
        {
            _enemyMovement =  new EnemyMovement(_enemyView.Rigidbody);
            _enemyMovement.Init();
            
            _enemyTakingDamage = new EnemyTakingDamage(_takingDamage, _enemyView);
            _enemyTakingDamage.Init();

            _enemyHealth = new EnemyHealth(_enemyConfig.Health);
            _enemyTakingDamage.Taken += _enemyHealth.TakeDamage;

            _enemyReachingFinish = new EnemyReachingFinish(_returningEnemyInPool, _enemyView);
            _enemyReachingFinish.Init();
        }

        public void Init()
        {
            var speed = Random.Range(_enemyConfig.MinSpeed, _enemyConfig.MaxSpeed);
            _enemyMovement.StartMove(speed);
            
            _enemyTakingDamage.StartDetectCollision();
            
            _enemyReachingFinish.StartDetectCollision();
        }
        
        private void OnDestroy()
        {
            _enemyTakingDamage.Taken -= _enemyHealth.TakeDamage; 
        }
    }
}