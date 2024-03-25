using Unit;
using Zenject;

namespace MainHero
{
    public class MainHeroHealth : Health, IInitializable
    {
        private readonly int _startHealth;
        
        public MainHeroHealth(int startHealth)
        {
            _startHealth = startHealth;
        }

        public void Initialize()
            => SetHealth(_startHealth);
    }
}