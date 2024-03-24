using System;
using Inputting;
using ScriptableObj;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class MainHeroMovement : IExecutive, IFixedTickable, IInitializable, IDisposable
    {
        public event Action Moved;
        
        private const float SpeedError = 0.001f;
        
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private readonly PlayerInput _input;
        private readonly ScreenBoundsCalculation _screenBoundsCalculation;
        
        private float _horizontalForce;
        private Vector2 _moveVelocity;

        public MainHeroMovement(MainHeroView mainHeroView,
                                MainHeroConfig mainHeroConfig, 
                                PlayerInput input,
                                ScreenBoundsCalculation screenBoundsCalculation)
        {
            _rigidbody = mainHeroView.Rigidbody;
            _speed = mainHeroConfig.Speed;
            _input = input;
            _screenBoundsCalculation = screenBoundsCalculation;
        }

        public void Initialize()
            => _input.Inputted += Execute;

        public void Dispose()
            => _input.Inputted -= Execute;

        public void Execute(InputData inputData)
        {
            _moveVelocity = inputData.Direction.normalized * _speed;
            
            if (IsMove())
                Moved?.Invoke();
        }

        public void FixedTick()
        {
            var targetPosition = _screenBoundsCalculation
                .GetClamp(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
            
            _rigidbody.MovePosition(targetPosition);
        } 

        private bool IsMove()
            => _moveVelocity.x is > SpeedError or < -SpeedError ||
               _moveVelocity.y is > SpeedError or < -SpeedError;
    }
}