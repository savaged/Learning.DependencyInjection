using Core;
using Weapons;

namespace Warriors
{
    public class Bandit : Character, IBandit
    {
        public Bandit(IShuriken weapon)
            : base(Effectiveness.Very, weapon)
        { }

    }
}
