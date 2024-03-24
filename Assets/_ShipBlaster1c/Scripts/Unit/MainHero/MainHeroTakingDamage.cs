using Unit;
using UnityEngine;
using Zenject;

namespace MainHero
{
    public class MainHeroTakingDamage : TakingDamage, IInitializable
    {
        private const int Damage = 1;
        
        public MainHeroTakingDamage(Collider2D collider,
                                    int layerDetectingObj,
                                    MainHeroHealth health)
            : base(Damage,
                   collider,
                   layerDetectingObj,
                   health)
        {
        }

        public void Initialize()
        {
            Init();
            StartDetectCollision();
        }
    }
}