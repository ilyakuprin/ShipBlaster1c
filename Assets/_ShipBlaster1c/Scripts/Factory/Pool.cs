using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class Pool<T> where T : MonoBehaviour
    {
        private readonly List<T> _pool;
        
        public Pool(int startLengthPool)
        {
            _pool = new List<T>(startLengthPool);
        }
        
        public int Capacity => _pool.Capacity;
        private int Count => _pool.Count;

        public void Return(T obj)
        {
            SetActiveGameObj(obj, false);
            
            if (!TryReturn(obj))
                Expand(obj);
        }
        
        public bool TryGet(out T obj)
        {
            for (var i = 0; i < Count; i++)
            {
                if (!_pool[i]) continue;
                
                SetActiveGameObj(_pool[i], true);
                obj = _pool[i];
                _pool[i] = null;
                return true;
            }

            obj = default;
            return false;
        }

        private bool TryReturn(T obj)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_pool[i]) continue;
                
                _pool[i] = obj;
                return true;
            }

            return false;
        }

        private void Expand(T obj)
            => _pool.Add(obj);
        
        private static void SetActiveGameObj(T obj, bool value)
            => obj.gameObject.SetActive(value);
    }
}