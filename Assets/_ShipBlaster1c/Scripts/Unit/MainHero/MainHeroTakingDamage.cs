using Unit;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class MainHeroTakingDamage : TakingDamage, IInitializable
    {
        private const int Damage = 1;
        
        public MainHeroTakingDamage(Collider2D collider, int layerDamagableObj, MainHeroHealth health)
            : base(Damage, collider, layerDamagableObj, health)
        {
        }

        public void Initialize()
        {
            Init();
            StartDetectCollision();
        }
    }
}