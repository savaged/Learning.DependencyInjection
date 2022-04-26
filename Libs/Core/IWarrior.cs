using System;

namespace Core
{
    public interface IWarrior
    {
        Effectiveness Skill { get; }
        IWeapon Weapon { get; set; }
        IWarrior Opponent { get; }
        void Attack(IWarrior opponent);
        void Struck(IWeapon with);
        event EventHandler<InjuryEventArgs> Injury;
        event EventHandler Dead;
    }
}
