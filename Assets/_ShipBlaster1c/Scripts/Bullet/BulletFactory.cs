using Factory;
using UnityEngine;
using Zenject;

namespace Bullet
{
    public class BulletFactory : BaseFactory<BulletView>, IInitializable
    {
        private readonly Pool<BulletView> _pool;
        
        public BulletFactory(DiContainer container,
                             BulletView prefab,
                             Transform parent,
                             Pool<BulletView> pool)
            : base(container,
                   prefab,
                   parent)
        {
            _pool = pool;
        }
        
        public void Initialize()
            => FillStartPool();

        public BulletView Get()
        {
            if (!_pool.TryGet(out var obj))
            {
                obj = GetCreateObject();
            }

            obj.SettingStartValues.InitValues();

            return obj;
        }

        private void FillStartPool()
        {
            for (var i = 0; i < _pool.Capacity; i++)
            {
                var obj = GetCreateObject();
                _pool.Return(obj);
            }
        }
    }
}