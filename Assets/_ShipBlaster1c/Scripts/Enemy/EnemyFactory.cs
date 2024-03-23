using Factory;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyFactory<T> : BaseFactory<T> where T : MonoBehaviour
    {
        public EnemyFactory(DiContainer container, T prefab, Transform parent) : base(container, prefab, parent)
        {
        }

        public T Get()
        {
            var obj = GetCreateObject();

            return obj;
        }
    }
}