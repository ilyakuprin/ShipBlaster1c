using UnityEngine;

namespace Unit
{
    public class TakingDamage : DetectingCollision
    {
        private readonly int _damage;
        private readonly Health _health;

        public TakingDamage(int damage,
                            Collider2D collider,
                            int layerDetectingObj,
                            Health health)
            : base(collider,
                   layerDetectingObj)
        {
            _damage = damage;
            _health = health;
        }

        protected override void Collide()
        {
            _health.TakeDamage(_damage);
        }
    }
}