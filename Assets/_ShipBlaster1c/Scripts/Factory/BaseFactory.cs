using UnityEngine;
using Zenject;

namespace Factory
{
    public abstract class BaseFactory<T> where T : MonoBehaviour
    {
        private readonly DiContainer _container;
        private readonly T _prefab;
        private readonly Transform _parent;
        
        protected BaseFactory(DiContainer container,
                              T prefab,
                              Transform parent)
        {
            _container = container;
            _prefab = prefab;
            _parent = parent;
        }
        
        protected T GetCreateObject()
            => _container.InstantiatePrefabForComponent<T>(_prefab, Vector3.zero, Quaternion.identity, _parent);
    }
}
