using System;

namespace Core
{
    public interface ICharacter
    {
        Effectiveness Skill { get; }
        uint LifeCount { get; }
        ICharacter Opponent { get; }
        void Struck(IWeapon with);
        event EventHandler<InjuryEventArgs> Injury;
        event EventHandler Dead;
    }
}
