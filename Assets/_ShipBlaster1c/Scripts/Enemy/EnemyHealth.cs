using System;

namespace Enemy
{
    public class EnemyHealth
    {
        public event Action Dead;
        public event Action TakenDamage;

        private const int MinHealth = 0;
        private int _currentHealth;

        public EnemyHealth(int startHealth)
        {
            _currentHealth = startHealth;
        }

        public void TakeDamage(int value)
        {
            if (value <= 0) return;

            _currentHealth -= value;
            
            if (_currentHealth <= MinHealth)
            {
                _currentHealth = MinHealth;
                Dead?.Invoke();
            }

            TakenDamage?.Invoke();
        }
    }
}