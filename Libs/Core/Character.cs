using System;

namespace Core
{
    public abstract class Character : ICharacter
    {
        public Character(
            Effectiveness skill,
            IWeapon weapon)
        {
            LifeCount = (uint)Appearance.Strong;
            Skill = skill;
            Weapon = weapon ?? EmptyWeapon.Default;
        }

        public Effectiveness Skill { get; }

        public uint LifeCount { get; private set; }

        public ICharacter Opponent { get; private set; }

        public void Attack(ICharacter opponent)
        {
            if (opponent == null) return;
            Opponent = opponent;
            Weapon.Hit(Opponent);
        }

        public virtual void Struck(IWeapon with)
        {
            if (with == null) return;

            LifeCount -= Damage(with);

            Injury?.Invoke(this, new InjuryEventArgs(GetAppearance(LifeCount)));

            if (LifeCount <= (uint)Appearance.Dead)
            {
                Dead?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler<InjuryEventArgs> Injury;

        public event EventHandler Dead;

        protected IWeapon Weapon { get; }

        public override string ToString()
        {
            return GetType().Name;
        }

        private static Appearance GetAppearance(uint lifeCount)
        {
            Appearance value = Appearance.Strong;
            switch (lifeCount)
            {
                case uint n when n <= (uint)Appearance.Dead:
                    value = Appearance.Dead;
                    break;
                case uint n when n <= (uint)Appearance.Expiring:
                    value = Appearance.Expiring;
                    break;
                case uint n when n <= (uint)Appearance.Weak:
                    value = Appearance.Weak;
                    break;
            }
            return value;
        }

        private static uint Damage(IWeapon with)
        {
            return (uint)(with?.Deadliness ?? Effectiveness.None);
        }

    }
}
