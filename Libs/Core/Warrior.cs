using System;

namespace Core
{
    public abstract class Warrior : IWarrior
    {
        public Warrior()
        {
            LifeCount = (int)Appearance.Strong;
            Weapon = EmptyWeapon.Default;
        }

        public abstract Effectiveness Skill { get; }

        public Appearance Appearance => GetAppearance(LifeCount);

        public bool IsDead => Appearance == Appearance.Dead;

        public IWeapon Weapon { get; set; }

        public int LifeCount { get; protected set; }

        public IWarrior Opponent { get; private set; }

        public void Attack(IWarrior opponent)
        {
            if (opponent == null || IsDead) return;
            Opponent = opponent;
            Weapon.Hit(Opponent);
        }

        public virtual void Struck(IWeapon with)
        {
            if (with == null) return;

            LifeCount -= Damage(with);

            Injury?.Invoke(this, new InjuryEventArgs(Appearance));

            if (LifeCount <= (int)Appearance.Dead)
            {
                Dead?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler<InjuryEventArgs> Injury;

        public event EventHandler Dead;

        public override string ToString()
        {
            return GetType().Name;
        }

        private static Appearance GetAppearance(int lifeCount)
        {
            Appearance value = Appearance.Strong;
            switch (lifeCount)
            {
                case int n when n <= (int)Appearance.Dead:
                    value = Appearance.Dead;
                    break;
                case int n when n <= (int)Appearance.Expiring:
                    value = Appearance.Expiring;
                    break;
                case int n when n <= (int)Appearance.Weak:
                    value = Appearance.Weak;
                    break;
            }
            return value;
        }

        private static int Damage(IWeapon with)
        {
            return (int)(with?.Deadliness ?? Effectiveness.None);
        }

    }
}
