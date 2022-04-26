using Core;

namespace Warriors
{
    public class Bandit : Character, IWarrior
    {
        public override Effectiveness Skill => Effectiveness.Very;

    }
}
