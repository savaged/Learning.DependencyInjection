namespace Core
{
    public abstract class Weapon : IWeapon
    {
        public abstract Effectiveness Deadliness { get; }

        public void Hit(ICharacter target)
        {
            target?.Struck(this);
        }

    }
}
