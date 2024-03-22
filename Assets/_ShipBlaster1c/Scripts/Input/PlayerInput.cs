using System;
using Zenject;

namespace _ShipBlaster1c.Scripts.Inputting
{
    public abstract class PlayerInput : ITickable
    {
        public event Action<InputData> Inputted;
        private InputData _inputData;
        private bool _isPause;

        public void Tick()
        {
            if (_isPause) return;

            _inputData = GetInputData();
            
            Inputted?.Invoke(_inputData);
        }

        public void SetPause(bool value)
            => _isPause = value;

        protected abstract InputData GetInputData();
    }
}
