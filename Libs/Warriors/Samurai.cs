using Core;

namespace Warriors
{
    public class Samurai : Warrior, IWarrior
    {
        public override Effectiveness Skill => Effectiveness.Extreme;

    }
}
