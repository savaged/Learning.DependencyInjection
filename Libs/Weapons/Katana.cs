using Core;

namespace Weapons
{
    public class Katana : Weapon, IKatana
    {
        public override Effectiveness Deadliness => Effectiveness.Extreme;

    }
}
