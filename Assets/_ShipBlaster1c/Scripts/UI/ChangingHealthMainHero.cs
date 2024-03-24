using System;
using MainHero;
using ScriptableObj;
using Zenject;

namespace UserInterface
{
    public class ChangingHealthMainHero : IInitializable, IDisposable
    {
        private const string FormatHealth = "Здоровье: {0}";

        private readonly MainHeroHealth _health;
        private readonly MainHeroConfig _heroConfig;
        private readonly GameProcessCanvasView _gameProcessCanvasView;

        public ChangingHealthMainHero(MainHeroHealth health,
                                      GameProcessCanvasView gameProcessCanvasView,
                                      MainHeroConfig heroConfig)
        {
            _health = health;
            _gameProcessCanvasView = gameProcessCanvasView;
            _heroConfig = heroConfig;
        }

        public void Initialize()
        {
            Change(_heroConfig.Health);
            _health.TakenDamage += Change;
        }

        public void Dispose()
        {
            _health.TakenDamage -= Change;
        }

        private void Change(int currentHealth)
        {
            _gameProcessCanvasView.HealthText.text = string.Format(FormatHealth, currentHealth);
        }
    }
}