using System.Threading;
using Bullet;
using Cysharp.Threading.Tasks;
using ScriptableObj;
using StringValues;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class Shooting : IInitializable
    {
        private readonly MainHeroConfig _mainHeroConfig;
        private readonly MainHeroView _heroView;
        private readonly BulletFactory _bulletFactory;

        private CancellationToken _ct;
        private bool _isPause;
        private int _enemyBitLayer;

        public Shooting(MainHeroConfig mainHeroConfig,
                        MainHeroView heroView,
                        BulletFactory bulletFactory)
        {
            _mainHeroConfig = mainHeroConfig;
            _heroView = heroView;
            _bulletFactory = bulletFactory;
        }

        public void Initialize()
        {
            _ct = _heroView.GetCancellationTokenOnDestroy();
            _enemyBitLayer = 1 << LayerCaching.Enemy;
            
            Shoot().Forget();
        }

        public void SetPause(bool value)
        {
            _isPause = value;
        }

        private async UniTask Shoot()
        {
            var hit = GetHit();
            while (!hit)
            {
                hit = GetHit();

#if UNITY_EDITOR
                Debug.DrawRay(_heroView.FirePoint.position,
                              Vector2.up * _mainHeroConfig.RadiusFire,
                              Color.red);
#endif
                
                await UniTask.NextFrame(_ct);
            }

            var bullet = _bulletFactory.Get();
            bullet.Rigidbody.transform.position = _heroView.FirePoint.position;
                
            Recharge().Forget();
        }
        
        private RaycastHit2D GetHit()
            => Physics2D.Raycast(_heroView.FirePoint.position,
                                 Vector2.up,
                                 _mainHeroConfig.RadiusFire,
                                 _enemyBitLayer);

        private async UniTask Recharge()
        {
            var timeRecharge = _mainHeroConfig.RechargeWeaponInSec;

            while (timeRecharge > 0)
            {
                timeRecharge -= Time.deltaTime;
                await UniTask.NextFrame(_ct);
                
                while (_isPause)
                    await UniTask.NextFrame(_ct);
            }
            
            Shoot().Forget();
        }
    }
}
