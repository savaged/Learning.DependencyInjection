using System;

namespace Core
{
    public interface ICharacter
    {
        Effectiveness Skill { get; }
        IWeapon Weapon { get; set; }
        ICharacter Opponent { get; }
        void Struck(IWeapon with);
        event EventHandler<InjuryEventArgs> Injury;
        event EventHandler Dead;
    }
}
