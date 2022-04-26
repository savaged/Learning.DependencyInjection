using Core;

namespace Warriors
{
    public class Samurai : Warrior, IWarrior
    {
        public Samurai()
        {
            LifeCount = (int)Appearance.VeryStrong;
        }

        public override Effectiveness Skill => Effectiveness.Extreme;

    }
}
