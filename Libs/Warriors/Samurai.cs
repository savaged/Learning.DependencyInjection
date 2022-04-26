using Core;
using Weapons;

namespace Warriors
{
    public class Samurai : Character, ISamurai
    {
        public Samurai(IKatana weapon)
            : base(Effectiveness.Very, weapon)
        { }

    }
}
