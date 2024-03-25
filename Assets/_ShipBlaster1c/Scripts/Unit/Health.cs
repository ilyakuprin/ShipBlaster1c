using System;

namespace Unit
{
    public class Health
    {
        private const int MinHealth = 0;
        
        public event Action Dead;
        public event Action<int> TakenDamage;
        
        public int CurrentHealth { get; private set; }

        public void SetHealth(int startHealth)
        {
            CurrentHealth = startHealth;
        }

        public void TakeDamage(int value)
        {
            if (value <= 0) return;

            CurrentHealth -= value;
            
            if (CurrentHealth <= MinHealth)
            {
                CurrentHealth = MinHealth;
                Dead?.Invoke();
            }

            TakenDamage?.Invoke(CurrentHealth);
        }
    }
}