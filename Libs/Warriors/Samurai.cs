using Core;

namespace Warriors
{
    public class Samurai : Character, IWarrior
    {
        public override Effectiveness Skill => Effectiveness.Extreme;

    }
}
