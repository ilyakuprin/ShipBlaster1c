using UnityEngine;

namespace StringValues
{
    public class LayerCaching
    {
        private static string NameEnemy = "Enemy";
        
        public static int Enemy => LayerMask.NameToLayer(NameEnemy);
        public static int EnemyBitMask => LayerMask.GetMask(NameEnemy);
        public static int Bullet => LayerMask.NameToLayer("Bullet");
        public static int Finish => LayerMask.NameToLayer("Finish");
    }
}