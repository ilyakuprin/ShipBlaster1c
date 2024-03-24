using Factory;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyFactory: BaseFactory<EnemyView>, IInitializable
    {
        private readonly Pool<EnemyView> _pool;
        
        public EnemyFactory(DiContainer container,
                            EnemyView prefab,
                            Transform parent,
                            Pool<EnemyView> pool) 
            : base(container,
                   prefab,
                   parent)
        {
            _pool = pool;
        }

        public void Initialize()
            => FillStartPool();

        public EnemyView Get()
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