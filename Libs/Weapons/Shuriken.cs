using Core;

namespace Weapons
{
    public class Shuriken : Weapon, IShuriken
    {
        public override Effectiveness Deadliness => Effectiveness.Slight;

    }
}
