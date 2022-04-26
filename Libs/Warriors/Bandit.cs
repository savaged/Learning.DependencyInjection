using Core;

namespace Warriors
{
    public class Bandit : Warrior, IWarrior
    {
        public override Effectiveness Skill => Effectiveness.Very;

    }
}
