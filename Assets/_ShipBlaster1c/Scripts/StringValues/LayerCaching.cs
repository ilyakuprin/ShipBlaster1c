using UnityEngine;

namespace StringValues
{
    public class LayerCaching
    {
        public static int Enemy => LayerMask.NameToLayer("Enemy");
        public static int Bullet => LayerMask.NameToLayer("Bullet");
        public static int Finish => LayerMask.NameToLayer("Finish");
    }
}