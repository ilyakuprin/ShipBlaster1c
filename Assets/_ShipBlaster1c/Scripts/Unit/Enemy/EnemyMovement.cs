using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement
    {
        private readonly Rigidbody2D _rigidbody;
        private CancellationToken _ct;
        private float _speed;

        private bool _isMoved;
        private bool _isPause;

        public EnemyMovement(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Init()
        {
            _ct = _rigidbody.GetCancellationTokenOnDestroy();
        }

        public void StartMove(float speed)
        {
            if (_isMoved) return;
            
            _speed = speed;
            Move().Forget();
        }

        public void SetPause(bool value)
        {
            if (_rigidbody.gameObject.activeInHierarchy)
                _isPause = value;
        } 

        private async UniTask Move()
        {
            _isMoved = true;
            var gameObj = _rigidbody.gameObject;
            
            while (gameObj.activeInHierarchy)
            {
                _rigidbody.MovePosition(_rigidbody.position + Vector2.down * (_speed * Time.fixedDeltaTime));
                await UniTask.WaitForFixedUpdate(_ct);

                while (_isPause)
                    await UniTask.NextFrame();
            }

            _isMoved = false;
        }
    }
}